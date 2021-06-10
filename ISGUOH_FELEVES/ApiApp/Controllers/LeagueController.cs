using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Authorize]
    [Route("League")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        LeagueLogic logic;

        public LeagueController(LeagueLogic logic)
        {
            this.logic = logic;
        }


        [HttpDelete("{uid}")]
        public void DeleteLeague(string uid)
        {
            logic.DeleteLeague(uid);
        }

        
        [HttpGet("{uid}")]
        public League GetLeague(string uid)
        {
             return logic.GetLeague(uid);
        }

       
        [HttpGet]
        public IEnumerable<League> GetAllLeague()
        {
           return logic.GetAllLeague();
        }


        [HttpPost]
        public void AddLeague([FromBody] League league)
        {
             logic.AddLeague(league);
        }

        [HttpPut("{oldid}")]
        public void UpdateLeague(string oldid,[FromBody] League league)
        {
            logic.UpdateLeague(oldid,league);
        }

        //[HttpGet("{leagueid}")]
        //public IEnumerable<Team> TeamList(string leagueid)
        //{
        //     return logic.GetTeams(leagueid);
        //}
    }
}
