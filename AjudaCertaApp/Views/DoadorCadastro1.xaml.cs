using AjudaCertaApp.Models;
using AjudaCertaApp.ViewModels.Usuarios;

namespace AjudaCertaApp.Views;

public partial class DoadorCadastro1 : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	public DoadorCadastro1()
	{
		InitializeComponent();
		usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}


    private void pfpj_SelectedIndexChanged(object sender, EventArgs e)
    {
        FisicaJuridica fj = new FisicaJuridica() { Id = 1, Descricao = "Pessoa Física" };
        if (pfpj.SelectedIndex == 0)
        {
            etCpf.IsVisible = true;
            lblCpf.IsVisible = true;
        }
        else
        {
            etCpf.IsVisible = false;
            lblCpf.IsVisible = false;
        }
    }
}