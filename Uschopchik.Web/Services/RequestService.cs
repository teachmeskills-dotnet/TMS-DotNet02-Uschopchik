using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Uschopchik.Web.Interfaces;
using Uschopchik.Web.Models;

namespace Uschopchik.Web.Services
{
    public class RequestService : IRequestService
    {
        public async Task<MusixMatchModel> GetDataAsync(string text)
        {
            const string webApi = "http://api.musixmatch.com";
            return await webApi.AppendPathSegments("ws", "1.1", "track.search")
                .SetQueryParams(new { apikey = "5b86287ec6291f8d5460e86827bbacd7", q_lyrics = text })
                .GetAsync()
                .ReceiveJson<MusixMatchModel>();
        }
    }
}
