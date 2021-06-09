using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApp.Controllers
{
    [Route("Team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        TeamLogic logic;

        public TeamController(TeamLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeleteTeam(string uid)
        {
            logic.DeleteTeamUid(uid);
        }

        [HttpGet("{uid}")]
        public Team GetTeam(string uid)
        {
            return logic.GetTeam(uid);
        }


        [HttpGet]
        public IEnumerable<Team> GetAllTeam()
        {
            return logic.GetAllTeam();
        }


        [HttpPost]
        public void AddTeam([FromBody] Team team)
        {
            logic.AddTeam(team);
        }

        [HttpPut("{oldid}")]
        public void UpdateTeam(string oldid, [FromBody] Team team)
        {
            logic.UpdateTeam(oldid, team);
        }

    }
}
