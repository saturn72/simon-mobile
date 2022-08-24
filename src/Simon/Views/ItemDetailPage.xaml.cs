using Simon.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Simon.Views
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