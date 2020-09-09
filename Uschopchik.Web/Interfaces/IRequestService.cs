using System.Threading.Tasks;
using Uschopchik.Web.Models;

namespace Uschopchik.Web.Interfaces
{
    public interface IRequestService
    {
        Task<MusixMatchModel> GetDataAsync(string text);
    }
}
