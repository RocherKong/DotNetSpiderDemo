using DotnetSpider.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text;
using DotnetSpider.Core;
using System.Linq;

namespace DotNetSpiderDemo
{
    public class DouBanPipeline : BasePipeline
    {
        public override void Process(ResultItems[] resultItems)
        {
            foreach (var resultItem in resultItems)
            {
                int count = 0;
                StringBuilder builder = new StringBuilder();
                foreach (var entry in resultItem.Results["MovieResult"])
                {
                    count++;
                    builder.Append($" [MovieResult {count}] {entry.Name}");
                    Console.WriteLine($" [MovieResult {count}] {entry.Name}");
                }
            }


        }
    }
}
