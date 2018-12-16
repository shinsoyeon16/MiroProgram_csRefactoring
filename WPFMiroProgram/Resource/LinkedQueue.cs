using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMiroProgram.Resource
{
    class LinkedQueue
    {
        Node front;
        Node rear;
        internal LinkedQueue() { front = null; rear = null; }
        internal bool isEmpty() { return front == null; }
        internal void enqueue(Node p)
        {
            if (isEmpty()) front = rear = p;
            else
            {
                rear.link = p;
                rear = p;
            }
        }
        internal Node dequeue()
        {
            if (isEmpty()) return null;
            Node p = front;
            front = front.link;
            if (front == null) rear = null;
            return p;
        }
        internal Node peek() { return front; }
        internal void display()
        {
            for (Node p = front; p != null; p = p.link)
                p.display();
            Console.WriteLine();
        }
    }
}
