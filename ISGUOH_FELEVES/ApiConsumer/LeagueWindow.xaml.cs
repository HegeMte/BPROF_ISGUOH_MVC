using Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for LeagueWindow.xaml
    /// </summary>
    public partial class LeagueWindow : Window
    {
        string token;
        public LeagueWindow(string token)
        {
            InitializeComponent();
            this.token = token;
            GetLeagues();
        }

        private void Addleague(object sender, RoutedEventArgs e)
        {
            AddLeagueWindow addwindow = new AddLeagueWindow(token);
            addwindow.Show();
            

           
            this.Close();
        }

        public async Task GetLeagues()
        {
            Leaguegrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/League", token);

            IEnumerable<League> allleagues = await restservice.Get<League>();

            Leaguegrid.ItemsSource = null;
            restservice = new RestService("https://localhost:5001/", "/League", token);
            allleagues = await restservice.Get<League>();

            Leaguegrid.ItemsSource = allleagues;
            Leaguegrid.SelectedIndex = 0;
        }

        private async void DeleteLeague(object sender, RoutedEventArgs e)
        {

            if (Leaguegrid.SelectedItem as League != null)
            {
                RestService restService = new RestService("https://localhost:5001/", "/League", token);
                restService.Delete<string>((Leaguegrid.SelectedItem as League).LeagueID);

                Leaguegrid.ItemsSource = null;

                //update
                RestService rest = new RestService("https://localhost:5001/", "/League", token);
                IEnumerable<League> alleagues = await rest.Get<League>();

                Leaguegrid.ItemsSource = alleagues;
            }

        }

        private void EditLeague(object sender, RoutedEventArgs e)
        {
            EditLeagueWindow edit = new EditLeagueWindow(Leaguegrid.SelectedItem as League, token);
            edit.Show();
            this.Close();
        }

        private async void Refresh(object sender, RoutedEventArgs e)
        {
            Leaguegrid.ItemsSource = null;
            RestService restservice = new RestService("https://localhost:5001/", "/League", token);

            IEnumerable<League> allleagues =  await restservice.Get<League>();

            Leaguegrid.ItemsSource = null;
            restservice = new RestService("https://localhost:5001/", "/League", token);
            allleagues = await restservice.Get<League>();

            Leaguegrid.ItemsSource = allleagues;
            Leaguegrid.SelectedIndex = 0;


        }

        private void ListTeams(object sender, RoutedEventArgs e)
        {
            TeamWindow tw = new TeamWindow((Leaguegrid.SelectedItem as League).LeagueID,token);
            tw.Show();
            this.Close();
        }
    }
}
