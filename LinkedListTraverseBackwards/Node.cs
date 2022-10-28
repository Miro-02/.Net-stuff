using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTraverseBackwards
{
    public class Node
    {
        private string? data;
        private Node? next;
        private int indexOfSearchedNode;

        public Node(string data, int indexOfSearchedNode)
        {
            this.Data = data;
            this.IndexOfSearchedNode = indexOfSearchedNode;
        }

        public string Data { get => data; set => data = value; }
        public Node Next { get => next; set => next = value; }
        public int IndexOfSearchedNode { get => indexOfSearchedNode; set => indexOfSearchedNode = value; }
    }
}
