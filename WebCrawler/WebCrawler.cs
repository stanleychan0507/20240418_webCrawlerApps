using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.JavaScript;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;


namespace WebCrawler
{
    class WebCrawler
    {

        public async Task StartWebCrawlAsync()
        {
            Console.OutputEncoding  = Encoding.Unicode;
            Console.ForegroundColor = ConsoleColor.Yellow;
            

            var            url          = "https://www.srleng.edu.mo/";
            var            httpClient   = new HttpClient();
            var            html         = await httpClient.GetStringAsync(url);

            var response = await httpClient.GetAsync(url);
            var header   = response.Content.Headers;
            Console.WriteLine(header);

            var            htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var divs =
                    htmlDocument.DocumentNode.Descendants("div")
                                .Where(node => node.GetAttributeValue("class", "").Equals("announcementscroll")).ToList();
            foreach (var div in divs)
            {
                var result = div.Descendants("ul").FirstOrDefault().InnerText;
                Console.WriteLine(result);
            }
        }
    }
}
