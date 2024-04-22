// See https://aka.ms/new-console-template for more information

namespace WebCrawler;
public class Program
{
    static async Task Main(string[] args)
    {
        // Display the number of command line arguments.
        var temp = new WebCrawler();
        await temp.StartWebCrawlAsync();
    }
}