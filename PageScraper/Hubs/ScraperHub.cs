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
            //int x = 0;
            //Int32.TryParse(indexMessage, out x);
            var scraper = new WebScraper();
            var res = await scraper.Scrape(pageUrl);
            scraper.LoadDocument(res);
            var list = scraper.GetAllImageSources();
            var item = list.First();
            //var item = list.ElementAt(new Random().Next(0, 100));
            /*foreach(string s in list)
            {
                await Clients.All.SendAsync("ScrapeResult", s);
            }*/
            await Clients.All.SendAsync("ScrapeResult", item);
        }
    }
}
