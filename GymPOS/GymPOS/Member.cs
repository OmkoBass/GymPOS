using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPOS
{
    class Member
    {
        internal string ime
        { get; private set; }
        internal string prezime
        { get; private set; }
        internal Datum datum
        { get; private set; }

        private static int brClanova = 0;

        public Member(string ime, string prezime, Datum d)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datum = d;
            ++brClanova;
        }

        public void displayClana()
        {
            Console.Write($"{this.ime} -- {this.prezime} -- uplatio:{datum.displayDatum()} -- istice:{datum.istice()}\n\n");
        }

        public static int getBrojClanova()
        {
            return brClanova;
        }
    }
}
