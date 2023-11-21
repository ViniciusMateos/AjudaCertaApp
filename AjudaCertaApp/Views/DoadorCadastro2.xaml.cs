using AjudaCertaApp.Models;
using AjudaCertaApp.ViewModels.Usuarios;

namespace AjudaCertaApp.Views;

public partial class DoadorCadastro2 : ContentPage
{
	UsuarioViewModel usuarioViewModel;
	Pessoa pessoaAcadastrar;
	Usuario usuarioAcadastrar;
	public DoadorCadastro2(Pessoa p, Usuario u)
	{
		InitializeComponent();
		pessoaAcadastrar = p;
		usuarioAcadastrar = u;
		usuarioViewModel = new UsuarioViewModel();
		BindingContext = usuarioViewModel;
	}
}