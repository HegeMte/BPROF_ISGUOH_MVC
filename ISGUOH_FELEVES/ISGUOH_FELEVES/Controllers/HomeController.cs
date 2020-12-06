using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ISGUOH_FELEVES.Controllers
{
    public class HomeController : Controller
    {
        static bool voltemar = true;
        PlayerLogic playerlogic;
        LeagueLogic leaguelogic;
        TeamLogic teamlogic;

        public HomeController(PlayerLogic playerlogic, LeagueLogic leaguelogic, TeamLogic teamlogic)
        {
            this.playerlogic = playerlogic;
            this.leaguelogic = leaguelogic;
            this.teamlogic = teamlogic;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }


        //DATA
  
        [HttpGet]
        public IActionResult Data()
        {
            return View();
        }

        //GENERATE DATA
        [HttpGet]
        public IActionResult GenerateData()
        {
            

            if (voltemar)
            {
                League L = new League { LeagueID = "Premier Leauge", Country = "England" };
                leaguelogic.AddLeague(L);

                Team t = new Team { TeamID = "Liverpool", City = "Liverpool", LeagueID = L.LeagueID };
                teamlogic.AddTeam(t);

                Team ta = new Team { TeamID = "Chelsea", City = "London", LeagueID = L.LeagueID };
                teamlogic.AddTeam(ta);

                Player p = new Player { PlayerName = "Van Dijk", TeamID = t.TeamID, Nationality = "Netherland", Rating = 90, WeakFoot = 2 };
                p.IgazolasSzama = Guid.NewGuid().ToString();
                playerlogic.AddPlayer(p);

                //----------------------------------------------------------------------------------------------------------------------------

                League L1 = new League { LeagueID = "MB1", Country = "Hungary" };
                leaguelogic.AddLeague(L1);

                Team t1 = new Team { TeamID = "Kaposvár", City = "Kaposvár", LeagueID = L1.LeagueID };
                teamlogic.AddTeam(t1);

                Player p1 = new Player { PlayerName = "Ács Péter", TeamID = t1.TeamID, Nationality = "Hungary", Rating = 76, WeakFoot = 5 };
                p1.IgazolasSzama = Guid.NewGuid().ToString();
                playerlogic.AddPlayer(p1);

                //----------------------------------------------------------------------------------------------------------------------------

                League L2 = new League { LeagueID = "Seria A", Country = "Italy" };
                leaguelogic.AddLeague(L2);

                Team t2 = new Team { TeamID = "Juventus", City = "Torino", LeagueID = L2.LeagueID };
                teamlogic.AddTeam(t2);

                Player p2 = new Player { PlayerName = "Cristano Ronaldo", TeamID = t2.TeamID, Nationality = "Portugal", Rating = 94, WeakFoot = 5 };
                p2.IgazolasSzama = Guid.NewGuid().ToString();
                playerlogic.AddPlayer(p2);

                voltemar = false;
            }

            
            

            return RedirectToAction(nameof(Index));
        }

        //----------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------


        //PLAYER
        public IActionResult AddPlayer(string id)
        {
            return View(nameof(AddPlayer),id);
        }

        [HttpPost]

       public IActionResult AddPlayer(Player p)
        {
            p.IgazolasSzama = Guid.NewGuid().ToString();
            playerlogic.AddPlayer(p);

            return View(nameof(ListPlayers), teamlogic.GetTeam(p.TeamID).Jatekosok);
        }

        [HttpGet]
        public IActionResult ListAllPlayer()
        {

            return View(nameof(ListPlayers),playerlogic.GetAllPlayers());
        }


        [HttpGet]
        public IActionResult ListPlayers(string id)
        {

            return View(nameof(ListPlayers),teamlogic.GetTeam(id).Jatekosok);
        }

        [HttpGet]

        public IActionResult UpdatePlayer(string id)
        {

            return View(nameof(UpdatePlayer), playerlogic.GetPlayer(id));
        }

        [HttpPost]

        public IActionResult UpdatePlayer(Player p)
        {
            playerlogic.UpdatePlayer(p.IgazolasSzama, p);

            return View(nameof(ListPlayers), playerlogic.PlayersFromThisTeam(p.TeamID));
        }

        //----------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------


        //League
        public IActionResult AddLeague()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddLeague(League l)
        {
            leaguelogic.AddLeague(l);

            return RedirectToAction(nameof(ListLeague));
        }

        [HttpGet]
        public IActionResult ListLeague()
        {
            return View(leaguelogic.GetAllLeague());
        }

        [HttpGet]
        public IActionResult LeagueTeamList(string id)
        {

            return View(nameof(ListTeams), leaguelogic.GetTeams(id));
        }


        [HttpGet]
        public IActionResult UpdateLeague(string id)
        {

            return View(nameof(UpdateLeague),leaguelogic.GetLeague(id));
        }

        [HttpPost]
        public IActionResult UpdateLeague(League L)
        {
            leaguelogic.UpdateLeague(L.LeagueID, L);

            return View(nameof(ListLeague),leaguelogic.GetAllLeague());
        }

        //----------------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------------


        //TEAM
        public IActionResult AddTeam(string id)
        {
            return View(nameof(AddTeam),id);
        }

        [HttpPost]

        public IActionResult AddTeam(Team t)
        {

            teamlogic.AddTeam(t);
            League L = leaguelogic.GetLeague(t.LeagueID);
            //L.Teams.Add(t);
            //return RedirectToAction(nameof(LeagueTeamList), L.LeagueID);
            //return RedirectToAction(nameof(ListTeams),L.Teams);
            return View(nameof(ListTeams), leaguelogic.GetTeams(t.LeagueID));
        }

        [HttpGet]
        public IActionResult ListTeams()
        {
            return View(teamlogic.GetAllTeam());
        }

        [HttpGet]
        public IActionResult UpdateTeam(string id)
        {

            return View(nameof(UpdateTeam),teamlogic.GetTeam(id));
        }


        [HttpPost]
        public IActionResult UpdateTeam(Team t)
        {
            teamlogic.UpdateTeam(t.TeamID, t);


            return View(nameof(ListTeams), teamlogic.GetTeamsfromLeague(t.LeagueID));
        }


        //----------------------------------------------------------------------------------------------------------------------------
        //NON CRUD

        public IActionResult Stat()
        {
            Stat s = new Stat();

            s.LegnagyobbLiga = leaguelogic.LegNagyobbLiga();
            s.MaxRatingJatekos = playerlogic.MaxRatedPlayer();
            s.JatekosokSzama = playerlogic.PlayerCount();
            s.LeagueCount = leaguelogic.LeagueCount();




            return View(s);

        }
















    }
}
