using System.ComponentModel;
using Xamarin.Forms;
using xapp.ViewModels;

namespace xapp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}