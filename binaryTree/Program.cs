using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace binaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 20);
            var s = num.ToString().PadLeft(3);
            var mytree = new Tree(num);
            for (int i = 1; i < 20; i++)
            {
                num = rnd.Next(0, 50);
                mytree.add(num);

                s += num.ToString().PadLeft(3);
            }
            Console.WriteLine(s);
            string treestring = "";
            mytree.Print_InOrder(null, ref treestring);
            Console.WriteLine(treestring);
         
            treestring = string.Empty;
            mytree.Print_PreOrder(null, ref treestring);
          
            treestring = string.Empty;
            mytree.Print_PostOrder(null, ref treestring);
            Console.WriteLine(treestring);
            Console.ReadLine();
        }
    }

    internal class Node
    {
        public int Value;
        public Node Left;
        public Node Right;

        public Node(int initial)
        {
            Value = initial;
            Left = null;
            Right = null;
        }

    }

    class Tree
    {
        private Node top;

        public Tree()
        {
            top = null;
        }

        public Tree(int initial)
        {
            top = new Node(initial);
        }

        public void add(int value)
        {
            if (top == null)
            {
                Node newNode = new Node(value);
                top = newNode;
                return;
            }
            Node currNode = top;
            bool added = false;
            do
            {
                if (value < currNode.Value)
                {
                    if (currNode.Left == null)
                    {
                        Node newNode = new Node(value);
                        currNode.Left = newNode;
                        added = true;
                    }
                    else
                    {
                        currNode = currNode.Left;
                    }
                }
                if (value >= currNode.Value)
                {
                    if (currNode.Right == null)
                    {
                        Node newNode = new Node(value);
                        currNode.Right = newNode;
                        added = true;

                    }
                    else
                    {
                        currNode = currNode.Right;
                    }

                }

            } while (!added);

        }

        public void addRc(int value)
        {
            addR(ref top, value);
        }

        private void addR(ref Node n, int value)
        {
            if (n == null)
            {
                Node newNode = new Node(value);
                n = newNode;
                return;

            }
            if (value < n.Value)
            {
                addR(ref n.Left, value);
                return;
            }
            if (value >= n.Value)
            {
                addR(ref n.Right, value);
                return;
            }
        }


        public void Print_PreOrder(Node N, ref string s)
        {
            if (N == null)
            {
                N = top;
                s = s + N.Value.ToString().PadLeft(3);
            }

            if (N.Left != null)
            {
                Print_InOrder(N.Left, ref s);
                s = s + N.Value.ToString().PadLeft(3);
            }
            if (N.Right != null)
            {
                Print_InOrder(N.Right, ref s);
            }

        }

        public void Print_InOrder(Node N, ref string s)
        {
            if (N == null)
            {
                N = top;
            }

            if (N.Left != null)
            {
                Print_InOrder(N.Left, ref s);
                s = s + N.Value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.Value.ToString().PadLeft(3);
            }

            if (N.Right != null)
            {
                Print_InOrder(N.Right, ref s);
            }

        }

        public void Print_PostOrder(Node N, ref string s)
        {


            if (N.Left != null)
            {
                Print_InOrder(N.Left, ref s);
                s = s + N.Value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.Value.ToString().PadLeft(3);
            }

            if (N.Right != null)
            {
                Print_InOrder(N.Right, ref s);
            }

          
                N = top;
                s = s + N.Value.ToString().PadLeft(3);
           

        }
    }
}
