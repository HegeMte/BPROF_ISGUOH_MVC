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
    /// Interaction logic for AddPlayerWindow.xaml
    /// </summary>
    public partial class AddPlayerWindow : Window
    {
        Team team;
        string token;
        
        public AddPlayerWindow(Team team,string token)
        {
            this.token = token;
            this.team = team;
            InitializeComponent();
            PlayerTeamID.Content = team.TeamID;
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            Player player = new Player()
            {
                PlayerName = PlayerName.Text,
                TeamID = team.TeamID,
                WeakFoot = Convert.ToInt32(PlayerWeakFoot.Value),
                Rating = Convert.ToInt32(PlayerRating.Value),
                Nationality = PlayerNationality.Text

            };


            RestService restService = new RestService("https://localhost:5001/", "/Player",token);
            restService.Post<Player>(player);

            PlayersWindow playersWindow = new PlayersWindow(team,token);
            playersWindow.Show();
            this.Close();

        }
    }
}
