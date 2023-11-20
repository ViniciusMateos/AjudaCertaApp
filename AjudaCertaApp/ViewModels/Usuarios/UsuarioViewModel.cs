using AjudaCertaApp.Models;
using AjudaCertaApp.Models.Enuns;
using AjudaCertaApp.Services.Pessoas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AjudaCertaApp.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private PessoaService pService;
        public ICommand DirecionarCadastroCommand { get; set; }
        public ICommand DirecionarLoginCommand { get; set; }
        public ICommand DirecionarCadastroDoador1Command { get; set; }
        public ICommand VoltarCommand { get; set; }
        public UsuarioViewModel()
        {
            pService = new PessoaService();
            InicializarCommands();
            _ = ObterFisicaJuridica();
        }

        public void InicializarCommands()
        {
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
            DirecionarLoginCommand = new Command(async () => await DirecionarParaLogin());
            DirecionarCadastroDoador1Command = new Command(async () => await DirecionarParaCadastroDoador1());
            VoltarCommand = new Command(async () => await Voltar());
        }

        #region AtributosPropriedades

        private string nome = string.Empty; // ctrl + r, e

        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private DateTime datanasc = DateTime.Now;
        public DateTime Datanasc
        {
            get { return datanasc; }
            set
            {
                datanasc = value;
                OnPropertyChanged();
            }
        }

        private string genero = string.Empty;
        public string Genero
        {
            get { return genero; }
            set
            {
                genero = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<FisicaJuridica> listaFisicaJuridica;
        public ObservableCollection<FisicaJuridica> ListaFisicaJuridica
        {
            get { return listaFisicaJuridica; }
            set
            {
                if (value != null)
                {
                    listaFisicaJuridica = value;
                    OnPropertyChanged();
                }
            }
        }

        private FisicaJuridica fisicaJuridicaSelecionado;
        public FisicaJuridica FisicaJuridicaSelecionado
        {
            get { return fisicaJuridicaSelecionado; }
            set
            {
                if (value != null)
                {
                    fisicaJuridicaSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Métodos
        public async Task ObterFisicaJuridica()
        {
            try
            {
                ListaFisicaJuridica = new ObservableCollection<FisicaJuridica>();
                ListaFisicaJuridica.Add(new FisicaJuridica() { Id = 1, Descricao = "Pessoa Física" });
                ListaFisicaJuridica.Add(new FisicaJuridica() { Id = 2, Descricao = "Pessoa Jurídica" });
                OnPropertyChanged(nameof(ListaFisicaJuridica));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.CadastroEscolha());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaLogin()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PopToRootAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task Voltar()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastroDoador1()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.DoadorCadastro1());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        #endregion
    }
}
