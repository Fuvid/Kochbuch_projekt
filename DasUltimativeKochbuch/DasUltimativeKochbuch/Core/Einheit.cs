using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasUltimativeKochbuch.Core
{
    public class Einheit
    {
        public string name   {get;set;}
      //  public string beschr {get;set;}

        public override string ToString()
        {
            return name;
        }
        public Einheit(string n) {
            this.name = n;
        }
        //public Einheit(string n, string beschr): this(n)
        //{
        //    this.beschr = beschr;
        //}
    }
}
