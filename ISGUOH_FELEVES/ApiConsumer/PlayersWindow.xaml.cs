using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for PlayersWindow.xaml
    /// </summary>
    public partial class PlayersWindow : Window
    {
        Team team;
        string token;

        public PlayersWindow()
        {
            InitializeComponent();
        }
        public PlayersWindow(Team team, string token)
        {
            this.team = team;
            this.token = token;
            InitializeComponent();
            GetPlayers(team.TeamID);
        }

        ///PlayersFromTeam/{teamid}

        public async Task GetPlayers(string Team)
        {
            Playergrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", $"/Player/PlayersFromTeam/{Team}",token);



            IEnumerable<Player> players = await restservice.Get<Player>();
            Playergrid.ItemsSource = players;

            Playergrid.SelectedIndex = 0;

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            GetPlayers(team.TeamID);
        }

        private void AddPlayer(object sender, RoutedEventArgs e)
        {
            AddPlayerWindow addPlayerWindow = new AddPlayerWindow(team,token);
            addPlayerWindow.Show();
            this.Close();
        }

        private void EditPlayer(object sender, RoutedEventArgs e)
        {
            EditPlayerWindow editwindow = new EditPlayerWindow(Playergrid.SelectedItem as Player, team,token);
            editwindow.Show();
            this.Close();
        }

        private async void DeletePlayer(object sender, RoutedEventArgs e)
        {
            if ((Playergrid.SelectedItem as Player) != null)
            {
                RestService restservice = new RestService("https://localhost:5001/", "/Player",token);
                restservice.Delete((Playergrid.SelectedItem as Player).IgazolasSzama);
            }
        }
    }
}
