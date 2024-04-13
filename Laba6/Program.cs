using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace Laba6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser(); ;
            string url = @"https://2droida.ru/catalog/noutbuki/noutbuki-honor";
            parser.Parse(url);
            var db = new Entitiess();
            foreach (var t in db.Laptop)
                Console.WriteLine("{0}\n\t{1}\n\t{2}\n", t.Article, t.Name, t.Price);
            Console.ReadLine();
        }
    }
}
