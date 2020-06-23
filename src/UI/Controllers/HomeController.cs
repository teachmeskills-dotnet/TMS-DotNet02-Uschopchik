using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using BLL.Models;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Search(string text)
        {
            [HttpGet]
            public IActionResult Action()
            {
                return View();
            }
            [HttpPost]
            async Task<MusixMatchModel> GetDataAsync(string text)
            {
                return await "http://api.musixmatch.com"
                    .AppendPathSegments("ws", "1.1", "track.search")
                    .SetQueryParams(new { apikey = "5b86287ec6291f8d5460e86827bbacd7", q_lyrics = text })
                    .GetAsync()
                    .ReceiveJson<MusixMatchModel>();
            }
        }
    }
}
