using AjudaCertaApp.ViewModels.Usuarios;

namespace AjudaCertaApp.Views;

public partial class BeneficiarioCadastro2 : ContentPage
{
    UsuarioViewModel usuarioViewModel;

    public BeneficiarioCadastro2()
	{
		InitializeComponent();

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
}