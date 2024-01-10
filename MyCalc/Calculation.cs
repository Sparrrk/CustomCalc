using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalc
{
    static class Calculation
    {
        static public LinkedList List;
        static private Stack Stack = new Stack();
        static private Node Node;
        static private Stack_Node Stack_Node1;
        static private Stack_Node Stack_Node2;
        
        /*public Calculation(LinkedList list)
        {
            List = list;
        }*/

        static public double Calc(LinkedList list)
        {
            List = list;
            while (List.Head != null) {
                Node = List.Pop();
                switcher(Node);
            }
            return Stack.Head.Value;
            //Console.WriteLine("result is:");
            //Stack.NodePrint();
        }

        static private void switcher(Node node)
        {
            double result = 0;
            if (node.Type == 0)
            {
                Stack.Add(node.Value, node.Priority, node.Type);
            }
            else if (node.Type >= 1 && node.Type <= 5)
            {
                Stack_Node1 = Stack.Pop();
                Stack_Node2 = Stack.Pop();
                result = Binary_calc(Stack_Node1, Stack_Node2, node.Type);
                Stack.Add(result, 0, 0);
            }
            else if (node.Type >= 6 && node.Type <= 11 || node.Type == 14 
                    || node.Type >= 15 && node.Type <= 18)
            {
                Stack_Node1 = Stack.Pop();
                result = Unary_calc(Stack_Node1, node.Type);
                Stack.Add(result, 0, 0);
            }
            else if (node.Type == 228)
            {
                Stack.Add(node.Value, node.Priority, node.Type);
            }
        }

        static private double Unary_calc(Stack_Node node1, uint type)
        {
            double res = 0;
            switch (type)
            {
                case 6:
                    res = Math.Cos(node1.Value);
                    break;

                case 7:
                    res = Math.Sin(node1.Value);
                    break;

                case 8:
                    res = Math.Tan(node1.Value);
                    break;

                case 9:
                    res = 1 / Math.Tan(node1.Value);
                    break;

                case 10:
                    res = Math.Log(node1.Value);
                    break;

                case 11:
                    res = Math.Log10(node1.Value);
                    break;

                case 14:
                    res = Factorial(node1.Value);
                    break;

                case 15:
                    res = Math.Asin(node1.Value);
                    break;

                case 16:
                    res = Math.Acos(node1.Value);
                    break;

                case 17:
                    res = Math.Atan(node1.Value);
                    break;

                case 18:
                    res = Math.Atan(1 / node1.Value);
                    break;

                default:
                    res = 0;
                    break;
            }
            return res;
        }

        static private int Factorial(double value)
        {
            int res = 1;
            for (int i = 1; i <= Math.Abs((int)value); i++)
            {
                res *= i;
            }
            return res;
        }

        static private double Binary_calc(Stack_Node node1, Stack_Node node2, uint type)
        {
            double res = 0;
            switch (type)
            {
                case 1:
                    res = node2.Value + node1.Value;
                    break;

                case 2:
                    res = node2.Value - node1.Value;
                    break;

                case 3:
                    res = node2.Value * node1.Value;
                    break;

                case 4:
                    res = node2.Value / node1.Value;
                    break;

                case 5:
                    res = Math.Pow(node2.Value, node1.Value);
                    break;

                default:
                    res = 0;
                    break;
            }
            return res;
        }
    }
}
