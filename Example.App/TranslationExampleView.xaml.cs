namespace Example.App;

public partial class TranslationExampleView : ContentPage
{
    private readonly TranslationExampleViewModel _viewModel;
    public TranslationExampleView(TranslationExampleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        _viewModel.OnAppearing();
        base.OnAppearing();
    }
}
