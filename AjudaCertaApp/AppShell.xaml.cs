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
            }
            else 
            {
                btnPostar.IsVisible = false; 
            }
        }
    }
}
