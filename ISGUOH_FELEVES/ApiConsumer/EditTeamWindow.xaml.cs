﻿using Models;
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
    /// Interaction logic for EditTeamWindow.xaml
    /// </summary>
    public partial class EditTeamWindow : Window
    {
        Team preTeam;
        string token;

        public EditTeamWindow(Team team,string token)
        {
            InitializeComponent();
            this.token = token;
            this.preTeam = team;
            TeamName.Content = team.TeamID;
            Country.Text = team.City;

        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Team modteam = new Team()
            {
                LeagueID = preTeam.LeagueID,
                City = Country.Text,
                TeamID = preTeam.TeamID,
                //Jatekosok = preTeam.Jatekosok
                
            };

            RestService restservice = new RestService("https://mlszproject.azurewebsites.net/", "/Team",token);
            restservice.Put<string, Team>(preTeam.TeamID, modteam);

            TeamWindow teamWindow = new TeamWindow(modteam.LeagueID,token);
            teamWindow.Show();
            this.Close();

        }
    }
}
