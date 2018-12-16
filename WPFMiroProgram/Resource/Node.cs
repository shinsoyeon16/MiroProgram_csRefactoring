using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMiroProgram.Resource
{
    class Node
    {
        public int row { get; set; }
        public int col { get; set; }
        internal Node link { get; set; }
        internal Node() { }
        internal Node(int r, int c) { row = r; col = c; link = null; }
        internal void display()
        {
            Console.Write($"({row}, {col}) ");
        }
    }
}
