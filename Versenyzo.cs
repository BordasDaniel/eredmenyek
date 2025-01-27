using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eredmenyek
{
    class Versenyzo
    {
        // Olyan osztályt amiben csak propery-k vannak, rekordnak hívjuk.
        public int Sorszaszam { get; set; }
        public string Nev { get; set; }
        public int Feladat1 { get; set; }
        public int Feladat2 { get; set; }
        public int Feladat3 { get; set; }


        public Versenyzo() { }


        public Versenyzo(int sorszaszam, string nev, int feladat1, int feladat2, int feladat3)
        {
            Sorszaszam = sorszaszam;
            Nev = nev;
            Feladat1 = feladat1;
            Feladat2 = feladat2;
            Feladat3 = feladat3;
        }

        //public Versenyzo(string sor)
        //{
        //    string[] adatok = sor.Split(';');
        //    Sorszaszam = int.Parse(adatok[0]);
        //    Nev = adatok[1];
        //    Feladat1 = int.Parse(adatok[2]);
        //    Feladat2 = int.Parse(adatok[3]);
        //    Feladat3 = int.Parse(adatok[4]);
        //}

        public override string ToString()
        {
            return Nev;
        }
    }
}
