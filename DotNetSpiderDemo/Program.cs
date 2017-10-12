using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Core.Scheduler;
using System;
using System.Security.Policy;

namespace DotNetSpiderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CrawlerPagesWithoutTraverse();
            Console.ReadKey();
        }

        public static void CrawlerPagesWithoutTraverse()
        {
            var site = new DotnetSpider.Core.Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            site.AddStartUrl("https://movie.douban.com/top250");
            Spider spider = Spider.Create(site,
                "DOUBAN_" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                new QueueDuplicateRemovedScheduler(),
                new DouBanPageProcessor())
                .AddPipeline(new DouBanPipeline());
            spider.ThreadNum = 2;
            spider.EmptySleepTime = 3000;

            // 启动爬虫
            spider.Run();
        }
    }
}
