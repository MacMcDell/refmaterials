using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {

        private static List<Category> Cats()
        {
            var l = new List<Category>
            {
                new Category() {Name = "Computers", Id = 1, ParentId = null},
                new Category() {Name = "laptop", Id = 2, ParentId = 1},
                new Category() {Name = "Peripheral", Id = 3, ParentId = 1},
                new Category() {Name = "Mice", Id = 4, ParentId = 3},
                new Category() {Name = "Other", Id = 5, ParentId = null},
                new Category() {Name = "Other 0.1", Id = 6, ParentId = 5}
                };
            return l;
        }



        static void Main(string[] args)
        {
            var l = Cats();
            foreach (Category item in l.Where(x => x.ParentId == null))
            {

                FindChild(ref l, item);

            }
            //from Root
            PrintItems(l.Where(x => x.ParentId == null).ToList());
            //from n position
            PrintItems(l.Where(x => x.Id == 3).ToList());

            Console.ReadLine();
        }

        private static void PrintItems(List<Category> categories, string indentation = null)
        {
            foreach (Category item in categories)
            {
                var items = indentation + item.Name;
                if (item.Children != null) // keep building the string
                {
                    PrintItems(item.Children, items + "-->");
                }
                else //no more children - output
                {
                    Console.WriteLine(items);
                }

            }
        }


        private static void FindChild(ref List<Category> items, Category item)
        {

            var children = items.Where(x => item.Id == x.ParentId);
            if (children.Any())
            {
                item.Children = new List<Category>();
                item.Children.AddRange(children);
            }
            foreach (Category childitem in children)
            {
                FindChild(ref items, childitem);
            }

        }
    }
}
