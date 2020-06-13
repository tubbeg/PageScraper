using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PageScraper.Hubs
{
    public class ScraperHub : Hub
    {
        public ScraperHub()
        {

        }

        public async Task ReceiveUrl(string pageUrl)
        {
            await Clients.All.SendAsync("ScrapeResult", pageUrl);
        }
    }
}
