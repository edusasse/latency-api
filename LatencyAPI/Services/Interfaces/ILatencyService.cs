using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace LatencyAPI.Services.Interfaces
{
    public interface ILatencyService
    {
        Task<string> TestLatencyPostAsync(string requestUri);
    }
}
