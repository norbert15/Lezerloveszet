using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lezerloveszet
{
    class JatekosLovese
    {
        int loves_azon;
        string nev;
        double x_koor;
        double y_koor;

        public JatekosLovese(string nev, double x_koor, double y_koor, int loves_azon)
        {
            this.Nev = nev;
            this.X_koor = x_koor;
            this.Y_koor = y_koor;
            this.Loves_azon = loves_azon;
        }

        //6.feladat
        public double Tavolsag(double x_kozeppont, double y_kozeppont)
        {
            double dx = x_kozeppont - x_koor;
            double dy = y_kozeppont - y_koor;
            return Math.Round(Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)), 2);
        }

        //8.feladat
        public double Pontszam(double x_kozeppont, double y_kozeppont)
        {
            double pontszam = 10 - Tavolsag(x_kozeppont, y_kozeppont);
            return pontszam > 0 ? pontszam : 0;
        }

        public string Nev { get => nev; set => nev = value; }
        public double X_koor { get => x_koor; set => x_koor = value; }
        public double Y_koor { get => y_koor; set => y_koor = value; }
        public int Loves_azon { get => loves_azon; set => loves_azon = value; }


    }
}
