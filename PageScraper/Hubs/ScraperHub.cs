using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebScraperApp;

namespace PageScraper.Hubs
{
    public class ScraperHub : Hub
    {
        public ScraperHub()
        {
        }

        public async Task ReceiveUrl(string pageUrl)
        {
            /*
            var scraper = new WebScraper();
            var res = await scraper.Scrape(pageUrl);
            scraper.LoadDocument(res);
            var list = scraper.GetAllImageSources();
            await Clients.All.SendAsync("ScrapeResult", pageUrl);*/
            await Clients.All.SendAsync("ScrapeResult", pageUrl);
        }
    }
}
