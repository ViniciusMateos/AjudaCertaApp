using AjudaCertaApp.ViewModels.Usuarios;

namespace AjudaCertaApp.Views;

public partial class BeneficiarioCadastro3 : ContentPage
{
    UsuarioViewModel usuarioViewModel;
    public BeneficiarioCadastro3()
	{
		InitializeComponent();

        usuarioViewModel = new UsuarioViewModel();
        BindingContext = usuarioViewModel;
    }
}