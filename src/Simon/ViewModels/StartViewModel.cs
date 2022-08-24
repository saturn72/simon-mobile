using Simon.Services;
using Simon.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Simon.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        public Command StartCommand { get; }

        public StartViewModel()
        {
            StartCommand = new Command(OnStartClicked);
        }

        private async void OnStartClicked(object obj)
        {
            GameManager.CreateGame();
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(GamePage)}");
        }
    }
}
