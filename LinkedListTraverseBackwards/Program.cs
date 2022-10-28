using LinkedListTraverseBackwards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Disclaimer: not sure if it's a faster solution, but it should use less memory than the stack one
internal class Program
{

    public static void Main(string[] args)
    {
        //Some tests to see whether it works
        MyLinkedList myLinkedList = new MyLinkedList("a", 0);
        myLinkedList.addNode("b", 1);
        myLinkedList.addNode("c", 10);
        myLinkedList.addNode("d", -1);
        myLinkedList.addNode("e", -10);

        Console.WriteLine(myLinkedList.findNode("a"));
        Console.WriteLine(myLinkedList.findNode("b"));
        Console.WriteLine(myLinkedList.findNode("c"));
        Console.WriteLine(myLinkedList.findNode("d"));
        Console.WriteLine(myLinkedList.findNode("e"));
    }
}