using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for EditPlayerWindow.xaml
    /// </summary>
    public partial class EditPlayerWindow : Window
    {
        Player player;
        Team team;
        string token;
        public EditPlayerWindow(Player player,Team team,string token)
        {
            this.team = team;
            this.player = player;
            this.token = token;
            InitializeComponent();
            PlayerName.Text = player.PlayerName;
            PlayerRating.Value = player.Rating;
            PlayerNationality.Text = player.Nationality;
            PlayerWeakFoot.Value = player.WeakFoot;
            PlayerTeamID.Content = player.TeamID;
        }

        private void EditPlayer(object sender, RoutedEventArgs e)
        {
            Player modplayer = new Player()
            {
                IgazolasSzama = player.IgazolasSzama,
                PlayerName = PlayerName.Text,
                Rating= Convert.ToInt32(PlayerRating.Value),
                Nationality = PlayerNationality.Text,
                WeakFoot =Convert.ToInt32(PlayerWeakFoot.Value),
                TeamID = PlayerTeamID.Content.ToString()


            };

            RestService restservice = new RestService("https://localhost:5001/", "/Player",token);
            restservice.Put<string, Player>(player.IgazolasSzama, modplayer);

          

            PlayersWindow playersWindow = new PlayersWindow(team,token);
            playersWindow.Show();
            this.Close();
        }
    }
}
