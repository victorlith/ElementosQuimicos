using ElementosQuimicos.ModelViews;

namespace ElementosQuimicos
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new  ElementoQuimicoViewModel();
            //frameElemento.BackgroundColor = Color.FromArgb("#F355B6");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
           
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Sobre", "Developer by @yLith\n\nInfo:\nExistem cerca 118 elementos quimicos, para buscar o elemento desejedo " +
                "basta digitar o número \"Atômico\"", "OK");
        }
    }

}
