using AngleSharp;
using AngleSharp.Dom;
using System;
using Laba6.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    class Parser
    {
        public async void Parse(string url)
        {
            IElement value;
            var context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            var doc = await context.OpenAsync(url);
            var aList = doc.QuerySelectorAll("div.product-name[itemprop=name] > a").Select(elem => doc.Origin + elem.GetAttribute("href"));
            Laptop nb;
            foreach (var a in aList)
            {
                //Console.WriteLine($"Ссылка на продукт: {a}");
                doc = await context.OpenAsync(a);
                nb = new Laptop();
                value = doc.QuerySelector("h1.title-detail[itemprop=name]");
                nb.Name = value.TextContent;

                IElement price = doc.QuerySelector("span.text-brand");
                nb.Price = price.TextContent;

                IElement cores = doc.QuerySelector("div.product-article > span");
                nb.Article = cores.TextContent;

                var id = Guid.NewGuid();
                nb.Id = id;

                using (var db = new Entitiess())
                {
                    //db.Laptop.Add(nb);
                    //db.SaveChanges();

                   var existingRecord = db.Laptop.FirstOrDefault(x => x.Article == nb.Article);
                   if (existingRecord != null)
                   {
                        break;
                   }
                   else
                    {
                        db.Laptop.Add(nb);
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}

