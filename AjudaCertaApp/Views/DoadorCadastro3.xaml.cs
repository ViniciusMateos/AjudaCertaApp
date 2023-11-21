using AjudaCertaApp.ViewModels.Usuarios;

namespace AjudaCertaApp.Views;

public partial class DoadorCadastro3 : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	public DoadorCadastro3()
	{
		InitializeComponent();

		usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
}