using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMiroProgram.Resource
{
    class LinkedStack
    {
        Node top;
        internal LinkedStack() { top = null; }
        internal bool isEmpty()
        {
            return top == null;
        }

        internal void push(Node p)
        {
            if (isEmpty()) top = p;
            else
            {
                p.link = top;
                top = p;
            }
        }
        internal Node pop()
        {
            if (isEmpty()) return null;
            Node p = top;
            top = top.link;
            return p;
        }
        internal Node peek()
        {
            return top;
        }
        internal void display()
        {
            for (Node p = top; p != null; p = p.link)
                p.display();
            Console.WriteLine();
        }
    }
}
