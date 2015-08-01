using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace FourSquareAPIConsume
{


    public class AnimalFactory
    {
        public enum animals
        {
            Cat = 0,
            Dog = 1,
            Chicken = 2

        }

        public delegate Animal GetAnimalDelegate();

        public GetAnimalDelegate GetAnimal(animals type)
        {
            switch (type)
            {
                case animals.Dog:
                    return new GetAnimalDelegate(CreateDog);
                case animals.Cat:
                    return new GetAnimalDelegate(CreateCat);
                default:
                    return new GetAnimalDelegate(CreateChicken);
            }
        }

        private Animal CreateDog()
        {
            return new Animal.Dog();
        }

        private Animal CreateCat()
        {
            return new Animal.Cat();
        }

        private Animal CreateChicken()
        {
            return new Animal.Chicken();
        }
    }

}


public abstract class Animal
{
    public virtual string speak()
    {
        return "Hello";
    }

    protected string Command(string cmd)
    {
        return cmd;

    }



    public class Chicken : Animal
    {
      
        public string Thecmd(string input)
        {
           switch (input)
            {
               case "sit":
                  return  sitResponse();
              break;

            }
            return null;
        }

        private string sitResponse()
        {
            return "good job.";
        }


        public override string speak()
        {
           return "cluck cluck";
        }
    }

    internal class Cat : Animal
    {
        public override string speak()
        {
            return "meow";
        }
    }

    public class Dog : Animal
    {
        public override string speak()
        {
            return "woof";

        }
    }




}
