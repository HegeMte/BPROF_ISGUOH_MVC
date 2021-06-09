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
        public TeamWindow()
        {
            InitializeComponent();


        }

       

        public TeamWindow(string LeagueID)
        {
            this.League = LeagueID;
            InitializeComponent();
            GetTeams(LeagueID);



        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            AddTeamWindow addteamwindow = new AddTeamWindow(League);
            addteamwindow.Show();
            this.Close();
        }


        public async Task GetTeams(string League)
        {
            Teamgrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", $"/Team/GetAllTeamFromLeague/{League}");



            IEnumerable<Team> team = await restservice.Get<Team>();
            Teamgrid.ItemsSource = team;

            Teamgrid.SelectedIndex = 0;

        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
            GetTeams(League);
        }
    }
}
