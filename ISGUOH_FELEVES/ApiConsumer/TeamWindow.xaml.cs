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
    /// Interaction logic for TeamWindow.xaml
    /// </summary>
    public partial class TeamWindow : Window
    {
        string League;
        string token;
        public TeamWindow()
        {
            InitializeComponent();


        }

       

        public TeamWindow(string LeagueID,string token)
        {
            this.token = token;
            this.League = LeagueID;
            InitializeComponent();
            GetTeams(LeagueID);



        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            AddTeamWindow addteamwindow = new AddTeamWindow(League,token);
            addteamwindow.Show();
            this.Close();
        }


        public async Task GetTeams(string League)
        {
            Teamgrid.ItemsSource = null;
            RestService restservice = new RestService("https://mlszproject.azurewebsites.net/", $"/Team/GetAllTeamFromLeague/{League}",token);



            IEnumerable<Team> team = await restservice.Get<Team>();
            Teamgrid.ItemsSource = team;

            Teamgrid.SelectedIndex = 0;

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            GetTeams(League);
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            EditTeamWindow editwindow = new EditTeamWindow(Teamgrid.SelectedItem as Team, token );
            editwindow.Show();
            this.Close();
        }

        private async void Delete(object sender, RoutedEventArgs e)
        {
            if ((Teamgrid.SelectedItem as Team) != null)
            {
                RestService restservice = new RestService("https://mlszproject.azurewebsites.net/", "/Team",token);
                restservice.Delete((Teamgrid.SelectedItem as Team).TeamID);
            }
            
        }

        private void ListPlayers(object sender, RoutedEventArgs e)
        {
            PlayersWindow playersWindow = new PlayersWindow(Teamgrid.SelectedItem as Team,token);
            playersWindow.Show();
            this.Close();



        }
    }
}
