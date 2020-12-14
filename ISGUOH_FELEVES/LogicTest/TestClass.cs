using NUnit.Framework;
using System;
using Moq;
using Repository;
using Models;
using System.Collections.Generic;
using System.Linq;
using Logic;

namespace LogicTest
{
    [TestFixture]
    public class TestClass
    {
        //::::::::::::::::::::::::::::::::::::::::::::::::::::CRUD TEST :::::::::::::::::::::::::::::::::::::::::::::::::::::::::

        [Test]
        public void GetAllPlayerTEST() 
        {

            //ARRANGE
            Mock<IRepository<Player>> mockedRepo = new Mock<IRepository<Player>>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player(){PlayerName = "Van Dijk", Nationality = "Netherland", Rating = 90, WeakFoot = 2  },
                new Player(){PlayerName = "Ács Péter",Nationality = "Hungary", Rating = 76, WeakFoot = 5  },
                new Player () {PlayerName = "Cristano Ronaldo",Nationality = "Portugal", Rating = 94, WeakFoot = 5 }

            };

            List<Player> expectedPlayers = new List<Player>() { players[0], players[1], players[2] };


            mockedRepo.Setup(repo => repo.Read()).Returns(players.AsQueryable());
            PlayerLogic playerlogic = new PlayerLogic(mockedRepo.Object);

            //ACT

            var result = playerlogic.GetAllPlayers();


            //ASSERT
            Assert.That(result.Count, Is.EqualTo(expectedPlayers.Count));
            Assert.That(result, Is.EquivalentTo(expectedPlayers));

        }


        [Test]

        public void GetOnePlayerTEST()
        {
            Mock<IRepository<Player>> mockedRepo = new Mock<IRepository<Player>>(MockBehavior.Loose);


            Player player = new Player() { IgazolasSzama = Guid.NewGuid().ToString(), PlayerName = "Van Dijk", Nationality = "Netherland", Rating = 90, WeakFoot = 2 };
            Player expectedPlayer = new Player()
            {
                IgazolasSzama = player.IgazolasSzama,
                PlayerName = player.PlayerName,
                Nationality = player.Nationality,
                Rating = player.Rating,
                WeakFoot = player.WeakFoot
            };

            mockedRepo.Setup(repo => repo.Read(player.IgazolasSzama)).Returns(expectedPlayer);
            PlayerLogic playerlogic = new PlayerLogic(mockedRepo.Object);


            //ACT
            var result = playerlogic.GetPlayer(player.IgazolasSzama);

            //ASSERT
            Assert.That(result, Is.EqualTo(expectedPlayer));
                
        }

        [Test]

        public void LeagueAddTEST()
        {
            //ARRANGE
            Mock<IRepository<League>> leagueRepo = new Mock<IRepository<League>>();
            League league = new League { LeagueID = "Seria A", Country = "Italy" };
            
            leagueRepo.Setup(repo => repo.Add(It.IsAny<League>()));
            LeagueLogic leagueLogic = new LeagueLogic(leagueRepo.Object);
            //ACT
            leagueLogic.AddLeague(league);


            leagueRepo.Verify(repo => repo.Add(league), Times.Once);

        }

        [Test]
        public void UpdateTeamTEST()
        {
            //ARRANGE
            Mock<IRepository<Team>> teamrepo = new Mock<IRepository<Team>>();
            Team team = new Team { TeamID = "Juventus", City = "Torino" };

            teamrepo.Setup(repo => repo.Update(It.IsAny<string>(), It.IsAny<Team>()));
            TeamLogic teamlogic = new TeamLogic(teamrepo.Object);


            //Act
            teamlogic.UpdateTeam(team.TeamID, team);

            teamrepo.Verify(repo => repo.Update(team.TeamID, team), Times.Once);
        }



        [Test]
        public void DeletePlayerTEST()
        {
            Mock<IRepository<Player>> playerrepo = new Mock<IRepository<Player>>();
            Player player = new Player {IgazolasSzama=Guid.NewGuid().ToString() ,PlayerName = "Ács Péter",Nationality = "Hungary", Rating = 76, WeakFoot = 5 };

            playerrepo.Setup(repo => repo.Delete(It.IsAny<Player>()));
            PlayerLogic playerLogic = new PlayerLogic(playerrepo.Object);


            //ACT
            playerLogic.DeletePlayer(player.IgazolasSzama);


            playerrepo.Verify(repo => repo.Delete(player.IgazolasSzama),Times.Once);
        }


        //::::::::::::::::::::::::::::::::::::::::::::::::::::NON-CRUD TEST :::::::::::::::::::::::::::::::::::::::::::::::::::::::::


        [Test]

        public void PlayerCountTest()
        {
            Mock<IRepository<Player>> mockedRepo = new Mock<IRepository<Player>>(MockBehavior.Loose);


            List<Player> playerlist = new List<Player>()
            {
                new Player() { IgazolasSzama= Guid.NewGuid().ToString(),
                    PlayerName = "Van Dijk",  Nationality = "Netherland", Rating = 90, WeakFoot = 2 /*,Csapat = teamlist[0]*/},

                new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Ács Péter",
                    Nationality = "Hungary", Rating = 76, WeakFoot = 5, /*Csapat =teamlist[1]*/ },

                new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Cristano Ronaldo",
                    Nationality = "Portugal", Rating = 94, WeakFoot = 5, /*Csapat =teamlist[2]*/}
            };

            mockedRepo.Setup(repo => repo.Read());
            var expected = playerlist.Count;
            StatLogic stl = new StatLogic(mockedRepo.Object);

            var result = stl.PlayerCount(playerlist);


            Assert.That(result, Is.EqualTo(expected));

        }




        [Test]

        public void TeamAVGPlayerTest()
        {
            Mock<IRepository<Player>> mockedPlayerRepo = new Mock<IRepository<Player>>(MockBehavior.Loose);
            Mock<IRepository<Team>> mockedTeamRepo = new Mock<IRepository<Team>>(MockBehavior.Loose);

            List<Team> teamlist = new List<Team>()
            {

                    new Team () { TeamID = "Liverpool", City = "Liverpool"},
                    new Team () { TeamID = "Kaposvár", City = "Kaposvár"},
                    new Team() { TeamID = "Juventus", City = "Torino"}
            };


            List<Player> playerlist = new List<Player>()
            {
                    new Player() { IgazolasSzama= Guid.NewGuid().ToString(),
                        PlayerName = "Van Dijk", TeamID = teamlist[0].TeamID, Nationality = "Netherland", Rating = 90, WeakFoot = 2 /*,Csapat = teamlist[0]*/},

                    new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Ács Péter",
                        TeamID = teamlist[1].TeamID, Nationality = "Hungary", Rating = 76, WeakFoot = 5, /*Csapat =teamlist[1]*/ },

                    new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Cristano Ronaldo",
                        TeamID =teamlist[2].TeamID, Nationality = "Portugal", Rating = 94, WeakFoot = 5, /*Csapat =teamlist[2]*/}
            };

            mockedPlayerRepo.Setup(repo => repo.Read()).Returns(playerlist.AsQueryable());
            mockedTeamRepo.Setup(repo => repo.Read()).Returns(teamlist.AsQueryable());
            var expected = teamlist[2].TeamID;
            StatLogic statlogic = new StatLogic(mockedPlayerRepo.Object, mockedTeamRepo.Object);

            var result = statlogic.TeamAVGPlayer(playerlist, teamlist);


            Assert.That(result, Is.EqualTo(expected));

        }
















        //Mock<IRepository<Player>> playerrepo;
        //Mock<IRepository<Team>> teamrepo;
        //Mock<IRepository<League>> leaguerepo;
        //string ExpectedLeagueName;

        //private StatLogic CreateLogicWithMocks()
        //{
        //    playerrepo = new Mock<IRepository<Player>>();
        //    teamrepo = new Mock<IRepository<Team>>();
        //    leaguerepo = new Mock<IRepository<League>>();

        //    League L1 = new League() { LeagueID = "Premier Leauge", Country = "England" };
        //    League L2 = new League() { LeagueID = "MB1", Country = "Hungary" };
        //    League L3 = new League() { LeagueID = "Seria A", Country = "Italy" };
        //    List<League> leaguelist = new List<League>() { L1, L2, L3 };

        //    List<Team> teamlist = new List<Team>()
        //    {

        //        new Team () { TeamID = "Liverpool", City = "Liverpool", LeagueID =  L1.LeagueID },
        //        new Team () { TeamID = "Kaposvár", City = "Kaposvár", LeagueID = L2.LeagueID },
        //        new Team() { TeamID = "Juventus", City = "Torino", LeagueID = L3.LeagueID }
        //    };


        //    List<Player> playerlist = new List<Player>()
        //    {
        //        new Player() { IgazolasSzama= Guid.NewGuid().ToString(),
        //            PlayerName = "Van Dijk", TeamID = teamlist[0].TeamID, Nationality = "Netherland", Rating = 90, WeakFoot = 2 /*,Csapat = teamlist[0]*/},

        //        new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Ács Péter",
        //            TeamID = teamlist[1].TeamID, Nationality = "Hungary", Rating = 76, WeakFoot = 5, /*Csapat =teamlist[1]*/ },

        //        new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Cristano Ronaldo",
        //            TeamID =teamlist[2].TeamID, Nationality = "Portugal", Rating = 94, WeakFoot = 5, /*Csapat =teamlist[2]*/}
        //    };


        //    ExpectedLeagueName = L3.LeagueID;

        //    leaguerepo.Setup(repo => repo.Read()).Returns(leaguelist.AsQueryable());
        //    teamrepo.Setup(repo => repo.Read()).Returns(teamlist.AsQueryable());

        //    playerrepo.Setup(repo => repo.Read()).Returns(playerlist.AsQueryable());


        //    return new StatLogic(playerrepo.Object, teamrepo.Object, leaguerepo.Object);
        //}



        //[Test]

        //public void RemelemMukodikTest()
        //{
        //    var logic = CreateLogicWithMocks();
        //    var LeagueName = logic.LigaAVGPlayer();


        //    Assert.That(LeagueName, Is.EqualTo(ExpectedLeagueName));


        //}
















        //[Test]
        //public void LigaAVGPlayerTEST()
        //{
        //    Mock<IRepository<Player>> playerrepo = new Mock<IRepository<Player>>();
        //    Mock<IRepository<Team>> teamrepo = new Mock<IRepository<Team>>();
        //    Mock<IRepository<League>> leaguerepo = new Mock<IRepository<League>>();

        //    List<League> leaguelist = new List<League>()
        //    {
        //        new League ()  { LeagueID = "Premier Leauge", Country = "England" },
        //        new League () { LeagueID = "MB1", Country = "Hungary" },
        //        new League() { LeagueID = "Seria A", Country = "Italy" }


        //    };

        //    List<Team> teamlist = new List<Team>()
        //    {

        //        new Team () { TeamID = "Liverpool", City = "Liverpool", LeagueID = leaguelist[0].LeagueID },
        //        new Team () { TeamID = "Kaposvár", City = "Kaposvár", LeagueID = leaguelist[1].LeagueID },
        //        new Team() { TeamID = "Juventus", City = "Torino", LeagueID = leaguelist[2].LeagueID }
        //    };


        //    List<Player> playerlist = new List<Player>()
        //    {
        //        new Player() { IgazolasSzama= Guid.NewGuid().ToString(),
        //            PlayerName = "Van Dijk", TeamID = teamlist[0].TeamID, Nationality = "Netherland", Rating = 90, WeakFoot = 2 /*,Csapat = teamlist[0]*/},

        //        new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Ács Péter",
        //            TeamID = teamlist[1].TeamID, Nationality = "Hungary", Rating = 76, WeakFoot = 5, /*Csapat =teamlist[1]*/ },

        //        new Player () { IgazolasSzama= Guid.NewGuid().ToString(), PlayerName = "Cristano Ronaldo",
        //            TeamID =teamlist[2].TeamID, Nationality = "Portugal", Rating = 94, WeakFoot = 5, /*Csapat =teamlist[2]*/}
        //    };


        //    leaguerepo.Setup(repo => repo.Read()).Returns(leaguelist.AsQueryable());
        //    teamrepo.Setup(repo => repo.Read()).Returns(teamlist.AsQueryable());
        //    playerrepo.Setup(repo => repo.Read()).Returns(playerlist.AsQueryable());
        //    StatLogic statlogic = new StatLogic(playerrepo.Object, teamrepo.Object, leaguerepo.Object);

        //    var expected = leaguelist[2].LeagueID;
        //    var result = statlogic.LigaAVGPlayer();

        //    Assert.That(result, Is.EqualTo(expected));


        //}


    }
}
