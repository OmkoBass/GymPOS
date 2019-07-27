using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPOS
{
    class Program
    {
        static List<Member> clanovi = new List<Member>();

        static void Main(string[] args)
        {
            Datum d = new Datum(31, 51, 6123);
            /*clanovi.Add(new Member("Idris", "Namcori", d));            
            clanovi.Add(new Member("Ramadan", "Rahmani", d));            
            clanovi.Add(new Member("Emir", "Abazovic", d));            
            clanovi.Add(new Member("Mervan", "Mecikukic", d));            
            clanovi.Add(new Member("Arslan", "Agovic", d));*/
            Console.WriteLine("GYM POS");
            while (true)
            {
                Console.Write("1. Novi Clan\n2. Brisi Clana\n3. Prikazi Clanove\n\n");
                izbor(Console.ReadKey(true));
            }
        }

        private static void izbor(ConsoleKeyInfo unos)
        {
            switch (unos.Key)
            {
                case ConsoleKey.D1:
                    dodajClana();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    izbrisiClana();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    prikaziClanove();
                    break;
            }
        }

        private static void dodajClana()
        {
            Member m;
            Datum d;
            string ime;
            string prezime;
            (int d, int m, int g) datum;

            Console.Write("Ime: "); ime = Console.ReadLine();
            Console.Write("Prezime: "); prezime = Console.ReadLine();
            //Moze da se doda da prvo slovo imena stavi kao Upper a ostala kao lower

            Console.Write("(Dan Mesec Godina) Datum: ");
            try
            {
                Console.Write("Dan: ");
                datum.d = int.Parse(Console.ReadLine());
                Console.Write("Mesec: ");
                datum.m = int.Parse(Console.ReadLine());
                Console.Write("Godina: ");
                datum.g = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (checkDate(datum.d, datum.m, datum.g) == true)
                {
                    d = new Datum(datum.d, datum.m, datum.g);
                    m = new Member(ime, prezime, d);
                    clanovi.Add(m);
                }
            }
            catch
            { Console.WriteLine("Los Unos.\n"); }
        }

        private static bool checkDate(int d, int m, int g)
        {
            if (m >= 13 || m <= 0)
            {
                Console.WriteLine("Nemoguce.\n");
                return false;
            }
            else
            {
                switch (m)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        if (d <= 0 || d >= 32) { return false; }
                        break;
                    case 2:
                        if ((g % 4 == 0) && (g % 100 == 0) && (g % 400 == 0))
                        {
                            if (d <= 0 || d >= 30) { return false; }
                        }
                        else
                        {
                            if (d <= 0 || d >= 29) { return false; }
                        }
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        if (d <= 0 || d >= 31) { return false; }
                        break;
                }
            }
            return true;
        }

        private static void izbrisiClana()
        {
            prikaziClanove();

            int brisi;

            Console.WriteLine("Unesi broj clana kojeg hoces da izbrises: ");
            try
            {
                brisi = Int16.Parse(Console.ReadLine());
                if (brisi >= 1 && brisi <= Member.getBrojClanova())
                {
                    clanovi.RemoveAt(--brisi);
                    Console.WriteLine("Uspesno!");
                }
                else
                {
                    Console.WriteLine("Ne postoji taj clan.\n");
                }
            }
            catch
            {
                Console.WriteLine("Los unos.\n");
            }
        }

        private static void prikaziClanove()
        {
            int i = 1;

            foreach(Member m in clanovi)
            {
                Console.Write($"{i} -- "); m.displayClana();
                i++;
            }
        }

    }
}
