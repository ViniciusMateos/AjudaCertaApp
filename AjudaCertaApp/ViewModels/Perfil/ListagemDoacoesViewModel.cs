using AjudaCertaApp.Models;
using AjudaCertaApp.Models.Enuns;
using AjudaCertaApp.Services.Doacoes;
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
                    OnPropertyChanged(nameof(Doacoes));
                }
                else if(p.Tipo == TipoPessoaEnum.DOADOR)
                {
                    Doacoes = await dService.GetDoacoesByPessoa();
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
