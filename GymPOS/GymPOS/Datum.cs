using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymPOS
{
    class Datum
    {
        private int dan;
        private int mesec;
        private int godina;

        public Datum(int dan, int mesec, int godina)
        {
            this.dan = dan;
            this.mesec = mesec;
            this.godina = godina;
        }

        public string displayDatum()
        {
            return $"{this.dan}.{this.mesec}.{this.godina}";
        }

        public string istice()
        {
            //Proveri mesec, doda mu 30 dana i modulise sa brojem dana sledeceg meseca
            //Meni ispada tacno, ako ima bug nek se javi
            switch(this.mesec)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    this.dan = (this.dan + 30) % 31;
                    mesec++;
                    if(mesec >= 13) { godina++; mesec = 1; }
                    break;
                case 2:
                    if((this.godina % 4 == 0) && (this.godina % 100 == 0) && (this.godina % 400 == 0))
                    {
                        this.dan = (this.dan + 30) % 30;
                        mesec++;
                        if (mesec >= 13) { godina++; mesec = 1; }
                    }
                    else
                    {
                        this.dan = (this.dan + 30) % 29;
                        mesec++;
                        if (mesec >= 13) { godina++; mesec = 1; }
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    this.dan = (this.dan + 30) % 31;
                    mesec++;
                    if (mesec >= 13) { godina++; mesec = 1; }
                    break;
            }
            if(this.dan == 0) { dan++; }
            return $"{this.dan}.{this.mesec}.{this.godina}";
        }
    }
}
