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
    /// Interaction logic for AddLeagueWindow.xaml
    /// </summary>
    public partial class AddLeagueWindow : Window
    {
        public AddLeagueWindow()
        {
            InitializeComponent();
        }

        private void AddLeague(object sender, RoutedEventArgs e)
        {
            League league = new League
            {

                LeagueID = LeagueName.Text.ToString(),
                Country = Country.Text.ToString()

            };


            RestService restservice = new RestService("https://localhost:5001/", "/League");
            restservice.Post<League>(league);

            LeagueWindow lwindow = new LeagueWindow();
            lwindow.Show();
            this.Close();
        }
    }
}
