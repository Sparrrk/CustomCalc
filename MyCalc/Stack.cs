using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalc
{
    class Stack
    {
        public Stack_Node Head { get; set; }
        public Stack_Node Temp { get; set; }

        public void Add(double value, uint priority, uint type)
        {
            if (Head == null)
            {
                Head = new Stack_Node(value, priority, type);
            }
            else
            {
                Temp = new Stack_Node(value, priority, type);
                Temp.Next = Head;
                Head = Temp;
            }
        }

        public void NodePrint()
        {
            Stack_Node runner = Head;
            while (runner != null)
            {
                Console.WriteLine($"value - {runner.Value}, priority - {runner.Priority}, type - {runner.Type}");
                runner = runner.Next;
            }
        }

        public Stack_Node Peek()
        {
            return Head;
        }

        public Stack_Node Pop()
        {
            Temp = Head;
            Head = Head.Next;
            return Temp;
        }
    }

    class Stack_Node
    {
        public Stack_Node(double value, uint priority, uint type)
        {
            Value = value;
            Priority = priority;
            Type = type;
        }
        public double Value { get; }
        public uint Priority { get; }
        public uint Type { get; }

        public Stack_Node Next { get; set; }
    }
}
