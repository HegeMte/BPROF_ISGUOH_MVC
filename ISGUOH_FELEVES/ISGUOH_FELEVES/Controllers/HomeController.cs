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
        public IActionResult ListPlayers(string id)
        {

            return View(nameof(ListPlayers),teamlogic.GetTeam(id).Jatekosok);
        }


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










       






    }
}
