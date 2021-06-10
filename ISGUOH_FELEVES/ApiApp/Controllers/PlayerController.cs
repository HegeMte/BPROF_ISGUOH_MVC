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
    [Route("Player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        PlayerLogic logic;

        public PlayerController(PlayerLogic logic)
        {
            this.logic = logic;
        }

        [HttpDelete("{uid}")]
        public void DeletePlayer(string uid)
        {
            logic.DeletePlayer(uid);
        }

        [HttpGet("{uid}")]
        public Player GetPlayer(string uid)
        {
            return logic.GetPlayer(uid);
        }


        [HttpGet]
        public IEnumerable<Player> GetAllPlayer()
        {
            return logic.GetAllPlayers();
        }


        [HttpPost]
        public void AddPlayer([FromBody] Player player)
        {
            logic.AddPlayer(player);
        }

        [HttpPut("{oldid}")]
        public void UpdatePlayer(string oldid, [FromBody] Player player)
        {
            logic.UpdatePlayer(oldid, player);
        }


        [HttpGet("PlayersFromTeam/{teamid}")]
        public IEnumerable<Player> GetPlayersFromTeam(string teamid)
        {

            return logic.PlayersFromThisTeam(teamid);
        }
    }
}
