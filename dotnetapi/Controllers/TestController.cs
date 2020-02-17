using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dotnetapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("You are Connected");
        }

        [HttpGet("getplayers")]
        public ActionResult GetPlayers()
        {
            return Ok(new[] { "TestPlayer1", "TestPlayer2", "TestPlayer3" });
        }

        [HttpGet("getuserrankings")]
        public ActionResult GetUserRankings()
        {
            var userRankings = new List<UserRanking>()
            {
                new UserRanking {Username = "TestPlayer1", Ranking = 1},
                new UserRanking {Username = "TestPlayer2", Ranking = 2},
                new UserRanking {Username = "TestPlayer3", Ranking = 3}
            };
            return Ok(userRankings);
        }

        [HttpPost("getiteminfo/{id}")]
        public ActionResult GetBalance(int id)
        {
            var item = new ItemInfo
            {
                Id = 12245,
                Name = "Diamond",
                Description = "Currency used to purchase additional items",
                Value = 1,
                ItemDetail = new ItemDetail
                {
                    Minimum = 0,
                    Maximum = 100000,
                    MoreDescription = "Game item only. Non refundable."
                }
            };
            return Ok(item);
        }


        [HttpPost("getbalance")]
        public ActionResult GetBalance(GetBalanceRequest request)
        {
            var balance = new PlayerBalance {DiamondBalance = 100, StarBalance = 1000};
            return Ok(balance);
        }

       

    }

    public class ItemInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public ItemDetail ItemDetail { get; set; }
    }

    public class ItemDetail
    {
        public string MoreDescription { get; set; }
        public int Minimum { get; set; }
        public decimal Maximum { get; set; }
    }

    public class UserRanking
    {
        public string Username { get; set; }
        public int Ranking { get; set; }
    }

    public class PlayerBalance
    {
        public int StarBalance { get; set; }
        public int DiamondBalance { get; set; }
    }

    public class GetBalanceRequest
    {
        public int Id { get; set; }
    }
}
