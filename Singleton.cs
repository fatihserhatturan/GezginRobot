using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prolab4._3
{
    public sealed class Singleton
    {

        private Singleton() { }

        private static Singleton _instance;

        public int[] textboxes;
        public int[] array;
        public int counterEn;
        public int counterBoy;
        public List<TextBox> textboxs;


        public static Singleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
                _instance.array = new int[5];
                _instance.counterEn=0;
                _instance.counterBoy=0;
                _instance.textboxs = new List<TextBox>();
                _instance.textboxes=new int[100];
            }
            return _instance;
        }


       
    }

}