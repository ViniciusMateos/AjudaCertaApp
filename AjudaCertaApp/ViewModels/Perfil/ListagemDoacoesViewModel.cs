using AjudaCertaApp.Models;
using AjudaCertaApp.Models.Enuns;
using AjudaCertaApp.Services.Doacoes;
using AjudaCertaApp.Services.Pessoas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjudaCertaApp.ViewModels.Perfil
{
    public class ListagemDoacoesViewModel : BaseViewModel
    {
        private DoacaoService dService;
        private PessoaService pService;
        private string _token;
        public ObservableCollection<Models.Doacao> Doacoes { get; set; }
        public ListagemDoacoesViewModel()
        {
            _token = Preferences.Get("UsuarioToken", string.Empty);
            dService = new DoacaoService(_token);
            pService = new PessoaService(_token);
            Doacoes = new ObservableCollection<Models.Doacao>();

            _ = ObterDoacoes();
        }

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
        #endregion
    }
}
