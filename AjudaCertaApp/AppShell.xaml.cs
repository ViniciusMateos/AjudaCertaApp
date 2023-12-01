using AjudaCertaApp.Models;

namespace AjudaCertaApp
{
    public partial class AppShell : Shell
    {
        Pessoa pessoaLogada;
        public AppShell(Pessoa pessoalogada)
        {
            InitializeComponent();
            pessoaLogada = pessoalogada;
            
            if(pessoaLogada.Tipo == Models.Enuns.TipoPessoaEnum.ONG) 
            {
                btnPostar.IsVisible = true;
                BtnDoar.IsVisible = false;
            }
            else if(pessoaLogada.Tipo == Models.Enuns.TipoPessoaEnum.DOADOR)
            {
                btnPostar.IsVisible = false;
                BtnDoar.IsVisible = true;
            }
            else if(pessoaLogada.Tipo == Models.Enuns.TipoPessoaEnum.BENEFICIARIO)
            {
                btnPostar.IsVisible = false;
                BtnDoar.IsVisible = false;
            }
        }
    }
}
