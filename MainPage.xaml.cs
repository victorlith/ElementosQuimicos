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
            await DisplayAlert("Info", "Developer by @yLith", "OK");
        }
    }

}
