using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prolab4
{
    internal class robot
    {
        public robot(int[,] konum,int en,int boy)
        {

        this.konum = konum;
        this.boy = boy;
        this.en = en;
        

        }
        
        public int[,] konum;
        public int en;
        public int boy;

        public int BaslangıcKonum()
        {
            int returnvalue;
            returnvalue = ((en + 2) * (boy + 2)) - (en + 4);

            return returnvalue;
            
        }
        public int KonumVer1()
        {
            for(int i = 0; i < en; i++)
            {
                for( int j = 0; j < boy; j++)
                {
                    if (konum[i,j] == 8) { return i; }
                }
                
            }
            return 0;
        }
        public int KonumVer2()
        {
            for (int i = 0; i < en; i++)
            {
                for (int j = 0; j < boy; j++)
                {
                    if (konum[i, j] == 8) { return j; }
                }

            }
            return 0;
        }


        public int RobotBul1()
        {

            int returnArray;

            for(int i = 0; i < en; i++)
            {
               for( int j = 0; j < boy; j++)
                {
                    if (konum[i,j] == 8)
                    {
                        returnArray = i;
                        return (returnArray);
                    }
                }
            }
            return RobotBul1();
        }
        public int RobotBul2()
        {
            int returnArray;


            for (int i = 0; i < en; i++)
            {
                for (int j = 0; j < boy; j++)
                {
                    if (konum[i, j] == 8)
                    {
                        returnArray = j;
                        return (returnArray);
                    }
                }
            }
            return RobotBul2();
        }

        public int SagHareket(int i,int j)
        {
            int returnvalue=1;
            if (konum[i, j + 1] == 9)
            {
                returnvalue = 0;
                return (returnvalue);
            }


            return returnvalue;
        }
        public int SolHareket(int i, int j)
        {
            int returnvalue = 1;
            if (konum[i, j - 1] == 9)
            {
                returnvalue = 0;
                return (returnvalue);
            }


            return returnvalue;
        }
        public int YukariHareket(int i, int j)
        {
            int returnvalue = 1;
            if (konum[i-1, j] == 9)
            {
                returnvalue = 0;
                return (returnvalue);
            }


            return returnvalue;
        }
        public int AsagiHareket(int i, int j)
        {
            int returnvalue = 1;
            if (konum[i+1, j] == 9)
            {
                returnvalue = 0;
                return (returnvalue);
            }


            return returnvalue;
        }



    }
    }

