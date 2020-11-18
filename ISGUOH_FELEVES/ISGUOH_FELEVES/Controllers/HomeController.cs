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

        public IActionResult AddPlayer()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddPlayer(Player p)
        {
            p.IgazolasSzama = Guid.NewGuid().ToString();
            playerlogic.AddPlayer(p);

            return RedirectToAction(nameof(List));
        }



        [HttpGet]
        public IActionResult List()
        {
            return View(playerlogic.GetAllPlayers());
        }



    }
}
