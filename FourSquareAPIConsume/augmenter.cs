using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSquareAPIConsume
{
  public  class Augmenter
    {
        private static Augmenter _instance;
        private  List<string> items= new List<string>();
        private static object _padlock = new object();
        private Random random = new Random();
        internal Augmenter()
        {
            items.Add("first");
            items.Add("second");
            items.Add("third");
            items.Add("fourth");
        }

        public static Augmenter GetAugmenter()
        {

            if (_instance == null)
                lock (_padlock)
                {
                    if (_instance == null)
                        _instance = new Augmenter();

                }
            return _instance; 
        }

        public string Server
        {
            get
            {
                int r = random.Next(items.Count);
                return items[r];
            }
        }

      public void increase()
      {
         var r = new Random().Next(10,100);
          items.Add(r.ToString());

      }



    }
}
