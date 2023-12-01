using AjudaCertaApp.Models;
using AjudaCertaApp.Services.Doacoes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudaCertaApp.ViewModels.Doacao
{
    public class DoacaoViewModel : BaseViewModel
    {
        private DoacaoService dService;

        public DoacaoViewModel() 
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            dService = new DoacaoService(token);
            _ = ObterConteudoDoacao();
            _ = ObterTipoProduto();
            _ = ObterGenero();
            _ = ObterFaixaEtaria();
        }

        #region AtributosPropriedades

        #region Pickers
        private ObservableCollection<ConteudoDoacao> listaConteudoDoacao;
        public ObservableCollection<ConteudoDoacao> ListaConteudoDoacao { 
            get { return listaConteudoDoacao; }
            set 
            {
                if(value != null)
                {
                    listaConteudoDoacao = value;
                    OnPropertyChanged();
                }
            }
        }

        private ConteudoDoacao conteudoDoacaoSelecionado;
        public ConteudoDoacao ConteudoDoacaoSelecionado
        {
            get { return conteudoDoacaoSelecionado; }
            set 
            {
                if(value != null)
                {
                    conteudoDoacaoSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<TipoProduto> listaTipoProduto;
        public ObservableCollection<TipoProduto> ListaTipoProduto
        {
            get { return listaTipoProduto; }
            set
            {
                if (value != null)
                {
                    listaTipoProduto = value;
                    OnPropertyChanged();
                }
            }
        }

        private TipoProduto tipoProdutoSelecionado;
        public TipoProduto TipoProdutoSelecionado
        {
            get { return tipoProdutoSelecionado; }
            set
            {
                if(value != null)
                {
                    tipoProdutoSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Genero> listaGenero;
        public ObservableCollection<Genero> ListaGenero
        {
            get { return listaGenero; }
            set
            {
                if (value != null)
                {
                    listaGenero = value;
                    OnPropertyChanged();
                }
            }
        }

        private Genero listaGeneroSelecionado;
        public Genero ListaGeneroSelecionado
        {
            get { return listaGeneroSelecionado; }
            set
            {
                if (value != null)
                {
                    listaGeneroSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<FaixaEtaria> listaFxEtaria;
        public ObservableCollection<FaixaEtaria> ListaFxEtaria
        {
            get { return listaFxEtaria; }
            set
            {
                if (value != null)
                {
                    listaFxEtaria = value;
                    OnPropertyChanged();
                }
            }
        }

        private FaixaEtaria fxEtariaSelecionado;
        public FaixaEtaria FxEtariaSelecionado
        {
            get { return fxEtariaSelecionado; }
            set
            {
                if (value != null)
                {
                    fxEtariaSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        private string nome;
        public string Nome 
        { 
            get { return nome; }
            set 
            {
                nome = value; OnPropertyChanged();
            }
        }

        private string descricao;
        public string Descricao
        {
            get { return descricao; }
            set
            {
                descricao = value; OnPropertyChanged();
            }
        }

        private DateTime dataValidade;
        public DateTime DataValidade
        {
            get { return dataValidade; }
            set
            {
                dataValidade = value; OnPropertyChanged();
            }
        }

        private string medida;
        public string Medida
        {
            get { return medida; }
            set
            {
                medida = value; OnPropertyChanged();
            }
        }

        private string condicao;
        public string Condicao
        {
            get { return condicao; }
            set
            {
                condicao = value; OnPropertyChanged();
            }
        }

        private string tamanho;
        public string Tamanho
        {
            get { return tamanho; }
            set
            {
                tamanho = value; OnPropertyChanged();
            }
        }

        private double valor;
        public double Valor
        {
            get { return valor; }
            set
            {
                valor = value; OnPropertyChanged();
            }
        }
        #endregion

        #region Métodos

        #region Pickers
        public async Task ObterConteudoDoacao()
        {
            try
            {
                ListaConteudoDoacao = new ObservableCollection<ConteudoDoacao>();
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 0, Descricao = "Dinheiro" });
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 1, Descricao = "Produto" });
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 2, Descricao = "Mobilia" });
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 3, Descricao = "Roupa" });
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 4, Descricao = "Eletrodomestico" });
                ListaConteudoDoacao.Add(new ConteudoDoacao() { Id = 5, Descricao = "Cesta Básica" });

                OnPropertyChanged(nameof(ListaConteudoDoacao));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ObterTipoProduto()
        {
            ListaTipoProduto = new ObservableCollection<TipoProduto>();
            ListaTipoProduto.Add(new TipoProduto() { Id = 1, Descricao = "Alimento" });
            ListaTipoProduto.Add(new TipoProduto() { Id = 2, Descricao = "Limpeza" });
            ListaTipoProduto.Add(new TipoProduto() { Id = 3, Descricao = "Higiene" });
            OnPropertyChanged(nameof(ListaTipoProduto));
        }
        public async Task ObterGenero()
        {
            try
            {
                ListaGenero = new ObservableCollection<Genero>();
                ListaGenero.Add(new Genero() { Id = 2, Descricao = "Masculino" });
                ListaGenero.Add(new Genero() { Id = 1, Descricao = "Feminino" });
                OnPropertyChanged(nameof(ListaGenero));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async Task ObterFaixaEtaria()
        {
            try
            {
                ListaFxEtaria = new ObservableCollection<FaixaEtaria>();
                ListaFxEtaria.Add(new FaixaEtaria() { Id = 1, Descricao = "Adulto" });
                ListaFxEtaria.Add(new FaixaEtaria() { Id = 2, Descricao = "Infantil" });
                OnPropertyChanged(nameof(ListaFxEtaria));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        #endregion

        
        #endregion
    }
}
