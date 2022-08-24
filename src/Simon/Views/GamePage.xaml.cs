using System;
using System.Timers;
using System.Threading;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simon.Views
{
    public partial class GamePage : ContentPage, IDisposable
    {
        private readonly ICollection<Stream> _streams;
        private readonly IDictionary<string, ISimpleAudioPlayer> _players;
        private readonly ISimpleAudioPlayer _buzzer;

        public GamePage()
        {
            _streams = new List<Stream>();
            _players = new Dictionary<string, ISimpleAudioPlayer>(StringComparer.InvariantCultureIgnoreCase)
            {
               ["red"] = CreatePlayer("tone1.mp3"),
               ["green"] = CreatePlayer("tone2.mp3"),
               ["yellow"] = CreatePlayer("tone3.mp3"),
               ["blue"] = CreatePlayer("tone4.mp3"),
            };
            _buzzer = CreatePlayer("buzzer.mp3");

            InitializeComponent();
        }

        private ISimpleAudioPlayer CreatePlayer(string file)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var p = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            var stream = assembly.GetManifestResourceStream("Simon.assets." + file);
            _streams.Add(stream);
            p.Load(stream);
            return p;
        }

        private void RedImageButton_Clicked(object sender, EventArgs e)
        {
            HandleButtonClick(sender, "red");
        }
        private void GreenImageButton_Clicked(object sender, EventArgs e)
        {
            HandleButtonClick(sender, "green");
        }
        private void YellowImageButton_Clicked(object sender, EventArgs e)
        {
            HandleButtonClick(sender, "yellow");
        }

        private void BlueImageButton_Clicked(object sender, EventArgs e)
        {
            HandleButtonClick(sender, "blue");
        }
        private void HandleButtonClick(object sender, string color)
        {
            var ib = sender as ImageButton;
            ib.Source = color + "light.png";

            var p = _players[color];
            Task.Run(() =>
            {
                p.Play();
                Thread.Sleep((int)p.Duration + 300);
               p.Stop();
            });

            ib.Source = color + "dark.png";
        }


        public void Dispose()
        {
            foreach (var s in _streams)
                s.Dispose();

            _buzzer.Dispose();
            foreach (var p in _players)
                p.Value.Dispose();
        }
    }
}