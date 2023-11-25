using AjudaCertaApp.ViewModels.Posts;

namespace AjudaCertaApp.Views;

public partial class FeedView : TabbedPage
{
	ListagemPostViewModel viewModel;
	public FeedView()
	{
		InitializeComponent();
		
		viewModel = new ListagemPostViewModel();
		BindingContext = viewModel;
	}
}