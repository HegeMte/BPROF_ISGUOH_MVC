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

        }

        private void AddTeam(object sender, RoutedEventArgs e)
        {
            AddTeamWindow addteamwindow = new AddTeamWindow(League);
            addteamwindow.Show();
            this.Close();
        }

        private void ListTeams(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
