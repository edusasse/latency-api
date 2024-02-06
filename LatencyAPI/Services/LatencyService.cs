using LatencyAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace LatencyAPI.Services
{
    public class LatencyService : ILatencyService
    {
        static HttpClient client = new HttpClient();

        public async Task<string> TestLatencyPostAsync(string requestUri, int numCalls, int delayInMillis)
        {
            if (string.IsNullOrEmpty(requestUri))
            {
                throw new ArgumentException("URL parameter is missing.");
            }

            try
            {
                long totalLatency = 0;
                var latenciesArray = new List<long>();

                for (int i = 0; i < numCalls; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();

                    HttpResponseMessage response = await client.GetAsync(requestUri);

                    stopwatch.Stop();

                    if (response.IsSuccessStatusCode)
                    {
                        long latency = stopwatch.ElapsedMilliseconds;
                        totalLatency += latency;
                        latenciesArray.Add(latency);
                    }
                    else
                    {
                        throw new HttpRequestException("Failed to fetch URL.");
                    }

                    await Task.Delay(delayInMillis); // Adding delay between calls
                }

                long averageLatency = totalLatency / numCalls;

                var responseData = new
                {
                    latencies = latenciesArray,
                    average_latency = averageLatency
                };

                return JsonConvert.SerializeObject(responseData);
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException("Error while fetching URL.", e);
            }
            catch (TaskCanceledException e)
            {
                throw new TaskCanceledException("Task was canceled.", e);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred.", e);
            }
        }
    }
}
