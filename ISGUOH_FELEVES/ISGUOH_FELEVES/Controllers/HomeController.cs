using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;

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




    }
}
