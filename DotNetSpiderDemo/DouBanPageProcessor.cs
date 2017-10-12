using DotnetSpider.Core.Processor;
using System;
using System.Collections.Generic;
using System.Text;
using DotnetSpider.Core;
using DotnetSpider.Core.Selector;

namespace DotNetSpiderDemo
{
    public class DouBanPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            var totalMoviesElements = page.Selectable.SelectList(Selectors.XPath("//div[@class='item']")).Nodes();
            var results = new List<Movie>();
            foreach (var movieelement in totalMoviesElements)
            {
                var movie = new Movie();
                movie.Name = movieelement.Select(Selectors.XPath(".//span[@class='title']")).GetValue();
                decimal.TryParse( movieelement.Select(Selectors.XPath(".//span[@class='rating_num']")).GetValue(),out decimal score);
                movie.Score = score;
                movie.Description= movieelement.Select(Selectors.XPath(".//span[@class='inq']")).GetValue();
                results.Add(movie);

            }

            page.AddResultItem("MoviesResult", results);

            // Add target requests to scheduler. 解析需要采集的URL
            foreach (var url in page.Selectable.SelectList(Selectors.XPath("//div[@class='paginator']")).Links().Nodes())
            {
                page.AddTargetRequest(new Request(url.GetValue(), null));
            }
        }
    }
}
