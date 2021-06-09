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
    /// Interaction logic for EditLeagueWindow.xaml
    /// </summary>
    public partial class EditLeagueWindow : Window
    {
        League l;
        public EditLeagueWindow(League l)
        {
            InitializeComponent();
            this.l = l;
            Country.Text = l.Country;
            LeagueName.Content = l.LeagueID;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            RestService restService = new RestService("https://localhost:5001/", "/League");


            League league = new League() { Country = Country.Text, LeagueID = LeagueName.Content.ToString() };

            restService.Put<string, League>(l.LeagueID, league);

            LeagueWindow leagueWindow = new LeagueWindow();
            leagueWindow.Show();
            this.Close();


        }
    }
}
