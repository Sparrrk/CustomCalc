using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalc
{
    class Node 
    {
        public Node (double value, uint priority, uint type)
        {
            Value = value;
            Priority = priority;
            Type = type;
        }
        public double Value { get; }
        public uint Priority { get; }
        public uint Type { get; }

        public Node Next { get; set; }
    }

    class LinkedList 
    {
        public Node Head { get; set; }

        public void AddNode(double value, uint priority, uint type)
        {
            if (Head == null)
            {
                Head = new Node(value, priority, type);
            }
            else
            {
                Node runner = Head;
                while (runner.Next != null)
                {
                    runner = runner.Next;
                }
                runner.Next = new Node(value, priority, type);
            }
        }

        public void PrintList()
        {
            Node runner = Head;
            while (runner != null)
            {
                Console.WriteLine($"value = {runner.Value}, priority = {runner.Priority}, type = {runner.Type}");
                runner = runner.Next;
            }
        }

        public Node Pop()
        {
            Node temp = Head;
            Head = Head.Next;
            return temp;
        }
    }

}
