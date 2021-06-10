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
    /// Interaction logic for AddTeamWindow.xaml
    /// </summary>
    public partial class AddTeamWindow : Window
    {
        private string leagueid;
        string token;
        public AddTeamWindow(string leagueid,string token)
        {
            this.token = token;
            this.leagueid = leagueid;
            InitializeComponent();
        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            Team team = new Team()
            {
                City = City.Text.ToString(),
                TeamID = TeamName.Text.ToString(),
                LeagueID = leagueid.ToString()
            };

            RestService restService = new RestService("https://mlszproject.azurewebsites.net/", "/Team",token);
            restService.Post<Team>(team);

            TeamWindow teamWindow = new TeamWindow(leagueid,token);
            teamWindow.Show();
            this.Close();
        }
    }
}
