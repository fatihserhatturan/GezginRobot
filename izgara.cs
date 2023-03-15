using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab4
{
    internal class izgara
    {
        public izgara(int[,] dizi, int enBoyut, int boyBoyut) {

            this.dizi = dizi;
            this.enBoyut = enBoyut;
            this.boyBoyut = boyBoyut;

            for (int i = 0; i < enBoyut; i++)
            {
                for (int j = 0; j < boyBoyut; j++)
                {
                    if (dizi[i, j] != 0)
                    {
                        dizi[i, j] = engel;
                    }
                   
                }
            }

        }
        public  int ErisimNoktası()
        {
            int returnvalue;
            returnvalue = boyBoyut + 3;
            return returnvalue;

        }
       
        
        public int engel=9;
        public int enBoyut;
        public int boyBoyut;
        public int[,] dizi;
    }
  

}
