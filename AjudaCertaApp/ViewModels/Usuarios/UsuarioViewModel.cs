using AjudaCertaApp.Models;
using AjudaCertaApp.Models.Enuns;
using AjudaCertaApp.Services;
using AjudaCertaApp.Services.Pessoas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AjudaCertaApp.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private PessoaService pService;
        private ViaCEPServices vcService;
        public ICommand DirecionarCadastroCommand { get; set; }
        public ICommand DirecionarLoginCommand { get; set; }
        public ICommand DirecionarCadastroDoador1Command { get; set; }
        public ICommand DirecionarCadastroDoador2Command { get; set; }
        public ICommand DirecionarCadastroDoador3Command { get; set; }


        public ICommand DirecionarCadastroBeneficiario1Command { get; set; }
        public ICommand DirecionarCadastroBeneficiario2Command { get; set; }
        public ICommand DirecionarCadastroBeneficiario3Command { get; set; }
        public ICommand VoltarCommand { get; set; }
        public UsuarioViewModel()
        {
            pService = new PessoaService();
            vcService = new ViaCEPServices();
            InicializarCommands();
            _ = ObterFisicaJuridica();
        }

        public void InicializarCommands()
        {
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
            DirecionarLoginCommand = new Command(async () => await DirecionarParaLogin());
            DirecionarCadastroDoador1Command = new Command(async () => await DirecionarParaCadastroDoador1());
            DirecionarCadastroDoador2Command = new Command(async () => await DirecionarParaCadastroDoador2());
            DirecionarCadastroDoador3Command = new Command(async () => await DirecionarParaCadastroDoador3());

            DirecionarCadastroBeneficiario1Command = new Command(async () => await DirecionarParaCadastroBeneficiario1());
            DirecionarCadastroBeneficiario2Command = new Command(async () => await DirecionarParaCadastroBeneficiario2());
            DirecionarCadastroBeneficiario3Command = new Command(async () => await DirecionarParaCadastroBeneficiario3());
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

        private string username = string.Empty;

        public string Username { get { return username;  }
            set 
            {
                username = value;
                OnPropertyChanged();
            }
                }

        private string email = string.Empty;

        public string Email { get { return email; }
            set 
            {
                email = value; 
                OnPropertyChanged(); 
            }
                }
        
        private string cpf = string.Empty;
        public string Cpf
        {
            get { return cpf; }
            set 
            { 
                cpf = value; 
                OnPropertyChanged(); 
            }
        }

        private string cnpj = string.Empty;
        public string Cnpj
        {
            get { return cnpj; }
            set
            {
                cnpj = value;
                OnPropertyChanged();
            }
        }
        
        private string telefone = string.Empty;
        public string Telefone
        {
            get { return telefone; }
            set
            {
                telefone = value;
                OnPropertyChanged();
            }
        }

        private string cep = string.Empty;
        public string Cep { get { return cep; }
            set 
            {
                cep = value;
                OnPropertyChanged();
            }
        }

        private string rua = string.Empty;
        public string Rua { get { return rua; }
        set 
            {
                rua = value;
                OnPropertyChanged();
            }
        }

        private string bairro = string.Empty;
        public string Bairro { get { return bairro; }
            set 
            {
                bairro = value;
                OnPropertyChanged();
            }
        }

        private string cidade = string.Empty;
        public string Cidade { get { return cidade; }
            set 
            {
                cidade = value;
                OnPropertyChanged();
            }
        }
        
        private string estado = string.Empty;
        public string Estado
        {
            get { return estado; }
            set
            {
                estado = value;
                OnPropertyChanged();
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

        public async Task DirecionarParaCadastroDoador2()
        {
            try
            {
                Pessoa p = new Pessoa();
                p.Nome = Nome;
                p.DataNasc = Convert.ToDateTime(Datanasc);
                p.fisicaJuridica = (FisicaJuridicaEnum)fisicaJuridicaSelecionado.Id;
                p.Tipo = TipoPessoaEnum.DOADOR;
                p.Username = Username;
                if(fisicaJuridicaSelecionado.Id == 1)
                {
                    p.Documento = Cpf;
                }
                else if(fisicaJuridicaSelecionado.Id == 2)
                {
                    p.Documento = Cnpj;
                }

                Usuario u = new Usuario();
                u.Email = Email;

                //#region Validações
                //if (Nome == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Preencha o campo nome.", "Ok");
                //}
                //else if (Username == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Preencha o campo usuário.", "Ok");
                //}
                //else if (Email == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Preencha o campo nome.", "Ok");
                //}
                //else if (Telefone == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Preencha o campo nome.", "Ok");
                //}
                //else if (Datanasc == DateTime.Now)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Escolha sua data de nascimento.", "Ok");
                //}
                //else if (Telefone == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "Preencha o campo nome.", "Ok");
                //}
                //else if (Cpf == string.Empty && Cnpj == string.Empty)
                //{
                //    await Application.Current.MainPage
                //    .DisplayAlert("Atenção", "É necessário informar seu CPF/CNPJ.", "Ok");
                //}
                //else
                //#endregion

                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.DoadorCadastro2(p, u));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastroDoador3()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.DoadorCadastro3());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }


        public async Task DirecionarParaCadastroBeneficiario1()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.BeneficiarioCadastro1());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastroBeneficiario2()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.BeneficiarioCadastro2());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastroBeneficiario3()
        {
            try
            {
                await Application.Current.MainPage
                    .Navigation.PushAsync(new Views.BeneficiarioCadastro3());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }


        public async Task PreencherEndereço()
        {
            try
            {
                // inserir mascara no textinputlayout do cep "xxxxx-xxx"
                string cepDigitado = Cep.Trim( new Char[] {'-'});
                if(cepDigitado.Length != 8) 
                {
                    int ceep = Convert.ToInt32(cepDigitado);
                    ViaCEPModel objectResult = Search.ByZipCode(ceep);
                    if (objectResult != null)
                    {
                        Rua = objectResult.Address1;
                        Bairro = objectResult.Neighborhood;
                        Cidade = objectResult.City;
                        Estado = objectResult.State;
                    }
                }
                else
                    await Application.Current.MainPage
                        .DisplayAlert("Atenção", "O CEP digitado não é válido.", "Ok");
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
