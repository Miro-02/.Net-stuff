using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


namespace LinkedListTraverseBackwards
{
    /// <summary>
    /// Implemented only the functions I need to do the exercise and test it
    /// </summary>
    internal class MyLinkedList
    {
        private Node head;
        public Node Head { get => head; set => head = value; }

        /// <summary>
        /// Constructor with Node
        /// </summary>
        /// <param name="head"> The node I am adding</param>
        public MyLinkedList(Node head)
        {
            Head = head;
        }

        /// <summary>
        /// Constructor with data and index
        /// </summary>
        /// <param name="data">The data of the node I am adding</param>
        /// <param name="indexOfSearchedNode">The index of the node I am adding</param>
        public MyLinkedList(string data, int indexOfSearchedNode)
        {
            this.head = new Node(data, indexOfSearchedNode);
        }

        /// <summary>
        /// Checks if next node is null
        /// </summary>
        /// <param name="node">The node I am checking</param>
        /// <returns>Boolean</returns>
        private bool checkNextNull(Node node)
        {
            if (node.Next == null)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Finds the node that I am looking for
        /// </summary>
        /// <param name="data"> The data I am looking for on the first traverse forward (first check)</param>
        /// <param name="minusIndex">Shows how much we have to go back (if we have to)</param>
        /// <param name="curNode">Current node</param>
        /// <param name="counter">How many times I am into the recursion</param>
        /// <param name="returnData">The data of the node I am looking for (after the second check)</param>
        /// <returns> The data of the node, I am seeking </returns>
        private string findNode(string data, ref int minusIndex, Node curNode, int counter = 0, string? returnData = null)
        {
            if (data == curNode.Data)
            {
                //The index that shows how far is the node from the current that we are seeking
                int index = curNode.IndexOfSearchedNode;

                if (index >= 0)
                {
                    for (; index > 0; index--)
                    {
                        if (!checkNextNull(curNode))
                        {
                            curNode = curNode.Next;
                        }
                        else
                        {
                            //throw new IndexOutOfRangeException("Index out of range");
                            return "Index out of range";
                        }

                    }
                    return curNode.Data;
                }
                else if (index < 0)
                {
                    if (counter < index * -1)
                    {
                        return "Index out of range";
                    }
                    minusIndex = index;
                    return "FoundMinus";
                }
            }
            else
            {
                if (!checkNextNull(curNode))
                {
                    returnData = findNode(data, ref minusIndex, curNode.Next, ++counter);
                    if (minusIndex < 0)
                    {
                        minusIndex++;
                    }
                    if (minusIndex == 0 && returnData == "FoundMinus")
                    {
                        return curNode.Data;
                    }
                    else if (minusIndex == 0)
                    {
                        return returnData;
                    }
                }
                else
                {
                    return "Index out of range";
                }
            }
            return "Index out of range";
        }
        /// <summary>
        /// Adding nodes to the linkedList
        /// </summary>
        /// <param name="data">The value of the data</param>
        /// <param name="indexOfSearchedNode">The index of the node I am seeking</param>
        public void addNode(string data, int indexOfSearchedNode)
        {
            Node curNode = head;
            Node newNode = new Node(data, indexOfSearchedNode);
            while (curNode.Next != null)
            {
                curNode = curNode.Next;
            }
            curNode.Next = newNode;
        }
        /// <summary>
        /// Function for calling from main, it's used like an interface
        /// </summary>
        /// <param name="data"> The data I am looking for on the first traverse forward (first check)</param>
        /// <returns></returns>
        public string findNode(string data)
        {
            int index = 0;
            return findNode(data, ref index, head);
        }
    }
}
