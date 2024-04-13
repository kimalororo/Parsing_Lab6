using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba6
{
    class Smartphone
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public string Price { get; set; }

        public string GetInfo() 
        {
            return $"\n Артикул: {Article},\n Название: {Name},\n Цена: {Price} \n";
        }
    }
}
