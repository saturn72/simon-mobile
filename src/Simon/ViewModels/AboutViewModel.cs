using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Simon.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public GameViewModel()
        {
            Title = "Simon";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}