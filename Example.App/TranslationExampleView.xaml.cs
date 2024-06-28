namespace Example.App;

public partial class TranslationExampleView : ContentPage
{
    public TranslationExampleView(TranslationExampleViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
