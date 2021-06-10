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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApiConsumer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;


        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            RestService restservice = new RestService("https://localhost:5001/", "/Auth");

            TokenViewModel tokenviewmodel = await restservice.Put<TokenViewModel, LoginViewModel>(
            new LoginViewModel()
            {
                Username = UserName.Text,
                Password = Password.Password

            });
            token = tokenviewmodel.Token;

            if (token != null)
            {
                LeagueWindow leagueWindow = new LeagueWindow(token);
                leagueWindow.Show();
                this.Close();
            }

        }
    }
}
