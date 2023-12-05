using AjudaCertaApp.Models;
using AjudaCertaApp.Models.Enuns;
using AjudaCertaApp.Services.Agendas;
using AjudaCertaApp.Services.Doacoes;
using AjudaCertaApp.Services.ItemDoacao;
using AjudaCertaApp.Services.ItemDoacaoDoado;
using AjudaCertaApp.Services.Pessoas;
using AjudaCertaApp.Services.Usuarios;
using AjudaCertaApp.Views.Usuarios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AjudaCertaApp.ViewModels.Perfil
{
    public class ListagemDoacoesViewModel : BaseViewModel
    {
        private DoacaoService dService;
        private UsuarioService uService;
        private PessoaService pService;
        private string _token;
        public ObservableCollection<Models.Doacao> Doacoes { get; set; }
        public ListagemDoacoesViewModel()
        {
            _token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(_token);
            dService = new DoacaoService(_token);
            pService = new PessoaService(_token);
            Doacoes = new ObservableCollection<Models.Doacao>();

            _ = ObterDoacoes();
            CarregarUsuario();
            InicializarCommands();
        }

        public void InicializarCommands()
        {
            AlterarFotoCommand = new Command(async () => AlterarFoto());
        }

        public ICommand AlterarFotoCommand { get; set; }

        #region AtributosPropriedades

        private bool roupa;
        public bool Roupa
        {
            get { return roupa; }
            set
            {
                roupa = value;
                OnPropertyChanged();
            }
        }

        private bool dinheiro;
        public bool Dinheiro
        {
            get { return dinheiro; }
            set
            {
                dinheiro = value;
                OnPropertyChanged();
            }
        }

        private bool mobilia;
        public bool Mobilia
        {
            get { return mobilia; }
            set
            {
                mobilia = value;
                OnPropertyChanged();
            }
        }

        private bool eletrodomestico;
        public bool Eletrodomestico
        {
            get { return eletrodomestico; }
            set 
            {
                eletrodomestico = value;
                OnPropertyChanged();
            }
        }

        private bool produto;
        public bool Produto
        {
            get { return produto; }
            set
            {
                produto = value;
                OnPropertyChanged();
            }
        }

        private bool quantidade;
        public bool Quantidade
        {
            get { return quantidade; }
            set
            {
                quantidade = value;
                OnPropertyChanged();
            }
        }

        private bool descricao;
        public bool Descricao
        {
            get { return descricao; }
            set
            {
                descricao = value;
                OnPropertyChanged();
            }
        }

        private ImageSource fonteImagem;

        public ImageSource FonteImagem
        {
            get { return fonteImagem; }
            set
            {
                fonteImagem = value;
                OnPropertyChanged();
            }
        }

        private byte[] foto;

        public byte[] Foto
        {
            get => foto;
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Métodos
        public async Task ObterDoacoes()
        {
            try
            {
                Pessoa p = await pService.GetPessoaPorUsuarioAsync();

                if (p.Tipo == TipoPessoaEnum.ONG)
                {
                    Doacoes = await dService.GetDoacoesAsync();

                    AgendaService ags = new(_token);

                    foreach (var d in Doacoes)
                    {
                        d.Agenda = new();
                        d.Agenda = await ags.GetAgendaPorId(d.AgendaId);

                        if(d.Dinheiro != 0)
                        {
                            Dinheiro = true;

                            Descricao = false;
                            Produto = false;
                            Eletrodomestico = false;
                            Roupa = false;
                            Mobilia = false;
                            Quantidade = false;
                        }
                        else 
                        {
                            Dinheiro = false;

                            ItemDoacaoDoadoService idds = new(_token);
                            d.ItemDoacaoDoados = new();
                            d.ItemDoacaoDoados.Add(await idds.GetPorIdDoacao(d.Id));

                            d.ItemDoacaoDoados.First().ItemDoacao = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Produtos = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Roupas = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Mobilias = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Eletrodomesticos = new();

                            ItemDoacaoService ids = new(_token);
                            d.ItemDoacaoDoados.First().ItemDoacao = await ids.GetPorId(d.ItemDoacaoDoados.First().ItemDoacaoId);

                            if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.PRODUTO)
                            {
                                d.ItemDoacaoDoados.First().ItemDoacao.Produtos.Add(await ids.GetProdutoPorId(d.ItemDoacaoDoados.First().ItemDoacaoId));
                                Produto = true;
                                Descricao = true;
                                Eletrodomestico = false;
                                Roupa = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.ROUPA)
                            {
                                d.ItemDoacaoDoados.First().ItemDoacao.Roupas.Add(await ids.GetRoupaPorId(d.ItemDoacaoDoados.First().ItemDoacaoId));
                                Descricao = true;
                                Roupa = true;
                                Produto = false;
                                Eletrodomestico = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.MOBILIA)
                            {
                                d.ItemDoacaoDoados.First().ItemDoacao.Mobilias.Add(await ids.GetMobiliaPorId(d.ItemDoacaoDoados.First().ItemDoacaoId));
                                Descricao = true;
                                Mobilia = true;
                                Produto = false;
                                Eletrodomestico = false;
                                Roupa = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                            {
                                d.ItemDoacaoDoados.First().ItemDoacao.Eletrodomesticos.Add(await ids.GetEletrodomesticoPorId(d.ItemDoacaoDoados.First().ItemDoacaoId));
                                Descricao = true;
                                Eletrodomestico = true;
                                Produto = false;
                                Roupa = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                        }
                    }
                   OnPropertyChanged(nameof(Doacoes));
                }
                else if(p.Tipo == TipoPessoaEnum.DOADOR)
                {
                    Doacoes = await dService.GetDoacoesByPessoa();

                    AgendaService ags = new(_token);

                    foreach (var d in Doacoes)
                    {
                        d.Agenda = new();
                        d.Agenda = await ags.GetAgendaPorId(d.AgendaId);

                        if (d.Dinheiro != null)
                        {
                            Dinheiro = true;

                            Descricao = false;
                            Produto = false;
                            Eletrodomestico = false;
                            Roupa = false;
                            Mobilia = false;
                            Quantidade = false;
                        }
                        else
                        {
                            Dinheiro = false;

                            ItemDoacaoDoadoService idds = new(_token);
                            d.ItemDoacaoDoados = new();
                            d.ItemDoacaoDoados.Add(await idds.GetPorIdDoacao(d.Id));

                            d.ItemDoacaoDoados.First().ItemDoacao = new();

                            ItemDoacaoService ids = new(_token);
                            d.ItemDoacaoDoados.First().ItemDoacao = await ids.GetPorId(d.ItemDoacaoDoados.First().ItemDoacaoId);
                            d.ItemDoacaoDoados.First().ItemDoacao.Produtos = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Roupas = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Mobilias = new();
                            d.ItemDoacaoDoados.First().ItemDoacao.Eletrodomesticos = new();

                            if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.PRODUTO)
                            {
                                Produto = true;
                                Descricao = true;
                                Eletrodomestico = false;
                                Roupa = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.ROUPA)
                            {
                                Descricao = true;
                                Roupa = true;
                                Produto = false;
                                Eletrodomestico = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.MOBILIA)
                            {
                                Descricao = true;
                                Mobilia = true;
                                Produto = false;
                                Eletrodomestico = false;
                                Roupa = false;
                                Quantidade = true;
                            }
                            else if (d.ItemDoacaoDoados.First().ItemDoacao.TipoItem == TipoItemEnum.ELETRODOMESTICO)
                            {
                                Descricao = true;
                                Eletrodomestico = true;
                                Produto = false;
                                Roupa = false;
                                Mobilia = false;
                                Quantidade = true;
                            }
                        }
                    }
                    
                    OnPropertyChanged(nameof(Doacoes));
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AlterarFoto()
        {
            try
            {
                Application.Current.MainPage = new AlterarFotoPerfil();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async void CarregarUsuario()
        {
            try
            {
                int usuarioId = Preferences.Get("UsuarioId", 0);
                Usuario u = await uService.GetUsuarioAsync(usuarioId);
                Pessoa p = await pService.GetPessoaPorUsuarioAsync();

                Foto = u.Foto;

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #endregion
    }
}
