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
        if (pfpj.SelectedIndex == 0)
        {
            etCpf.IsVisible = true;
            lblCpf.IsVisible = true;
            etCnpj.IsVisible = false;
            lblCnpj.IsVisible = false;
        }
        else if(pfpj.SelectedIndex == 1)
        {
            etCpf.IsVisible = false;
            lblCpf.IsVisible = false;
            etCnpj.IsVisible = true;
            lblCnpj.IsVisible = true;
        }
    }
}