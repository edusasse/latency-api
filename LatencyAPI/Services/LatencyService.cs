using LatencyAPI.Services.Interfaces;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace LatencyAPI.Services
{
    public class LatencyService : ILatencyService
    {
        static HttpClient client = new HttpClient();

       
       public async Task<string> TestLatencyPostAsync(string requestUri)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            HttpResponseMessage response = await client.GetAsync(requestUri);

            stopwatch.Stop();

            // Return the elapsed time in milliseconds as a string
            return stopwatch.ElapsedMilliseconds.ToString();
        }
 
    }
}
