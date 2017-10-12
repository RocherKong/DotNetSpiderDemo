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
                results.Add(movie);

            }

            page.AddResultItem("MoviesResult", results);
        }
    }
}
