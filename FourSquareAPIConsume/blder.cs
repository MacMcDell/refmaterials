using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourSquareAPIConsume
{
    
    public class dogs
    {
        public string name { get; set; }
        public int weight { get; set; }
    }

    public interface idogs
    {
        void setweight();
        void setname();
        dogs dog { get; }
    }

    public class pitty : idogs
    {
        private dogs _dogs;

        public pitty()
        {
            _dogs = new dogs();
        }

        public void setweight()
        {
            _dogs.weight = 100;
        }

        public void setname()
        {
            _dogs.name = "Maya";
        }

        public dogs dog
        {
            get { return _dogs; }
        }
    }

    public class dogdirector
    {
        public void dogbuilder(idogs dogs)
        {
            dogs.setname();
            dogs.setweight();
        }
    }



}
