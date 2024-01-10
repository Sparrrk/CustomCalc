using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalc
{
    static class Parser {

        static public LinkedList list { get; set; } = new LinkedList();
        static public Stack stack = new Stack();

        /*public Parser(string input_str)
        {
            Input_str += input_str;
            if (parsing(Input_str) == 1)
                Console.WriteLine("Some error occured");
        }*/

        static private string Number_checker { get; set; } = "0123456789.,";

        static readonly public string[] binary_checker = { "+", "-", "*", ":", "^" };

        static readonly public string[] unary_checker = { "cos", "sin", "tan", "ctg", "ln", "log", "(", ")", "!", "asin", "acos", "atan", "actg"};

        static public void parsing(string input_str, double point)
        {
            //string str_clone = "";
            while (input_str != "") {
                //str_clone = input_str;
                Number(ref input_str);
                Binary(ref input_str);
                Unary(ref input_str);
                Variable(ref input_str, point);
            }
            Stack_reaver(stack);
        }
        
        static public int Is_variable(ref string input_str)
        {
            int res = 0;
            if (input_str.Length != 0 && input_str[0] == 'x')
            {
                res = 1;
            }
            return res;
        }

        static private void Variable(ref string input_str, double point)
        {
            if (Is_variable(ref input_str) == 1)
            {
                input_str = input_str.Substring(1);
                list.AddNode(point, 0, 0);
            }
        }

        static public string Is_number(ref string input_str)
        {
            int num_flag = 0;
            string num_container = "";
            input_str = input_str.Trim();
            string str_clone = input_str;
            while (Number_checker.IndexOf(str_clone.FirstOrDefault()) != -1)
            {
                num_container += str_clone.First();
                str_clone = str_clone.Substring(1);
                num_flag++;
            }
            return num_container;
        }

        static private void Number(ref string input_str)
        {
            string number_container = Is_number(ref input_str);
            if (number_container.Length != 0)
            {
                number_container = number_container.Replace('.', ',');
                double number = Convert.ToDouble(number_container);
                list.AddNode(number, 0, 0);
                input_str = input_str.Substring(number_container.Length);
            }
        }

        static public int Is_binary(ref string str)
        {
            int binary_flag = 0;
            str = str.Trim();
            for (int i = 0; i < binary_checker.Length; i++)
            {
                if (string.Compare(str, 0, binary_checker[i], 0, binary_checker[i].Length) == 0)
                {
                    binary_flag = i + 1;
                    break;
                }
            }
            return binary_flag;
        }

        static private void Binary(ref string input_str)
        {
            int flag = Is_binary(ref input_str);
            int priority = 0; 
            if (flag == 1 || flag == 2)
            {
                priority = 1;
                input_str = input_str.Substring(1);
            }
            else if (flag == 3 || flag == 4)
            {
                priority = 2;
                input_str = input_str.Substring(1);
            }
            else if (flag == 5)
            {
                priority = 3;
                input_str = input_str.Substring(1);
            }
            if (flag != 0)
                Stack_binary_adder(0, (uint)priority, (uint)flag);
        } 
            
        static private void Stack_binary_adder(double value, uint priority, uint type)
        {
            if (stack.Head == null)
            {
                stack.Add(value, priority, type);
            }
            else
            {
                Stack_Node temp;
                while (stack.Head != null && priority <= stack.Peek().Priority)
                {
                    temp = stack.Pop();
                    list.AddNode(temp.Value, temp.Priority, temp.Type);
                }
                stack.Add(value, priority, type);
            }
        }

        static private void Unary(ref string input_str)
        {
            input_str = input_str.Trim();
            int unary_flag = Is_unary(ref input_str);
            if (unary_flag != 0)
            {
                Stack_unary_switcher((uint)unary_flag);
                input_str = input_str.Substring(unary_checker[unary_flag - 6].Length);
            }
        }

        static public int Is_unary(ref string input_str)
        {
            int unary_flag = 0;
            for (int i = 0; i < unary_checker.Length; i++)
            {
                if (string.Compare(input_str, 0, unary_checker[i], 0, unary_checker[i].Length) == 0)
                {
                    unary_flag = i + 6;
                    break;
                }
            }
            return unary_flag;
        }

        static private void Stack_unary_switcher(uint type)
        {
            uint priority;

            switch (type)
            {
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 15:
                case 16:
                case 17:
                case 18:
                    priority = 4;
                    break;

                case 12:
                case 13:
                    priority = 0;
                    break;

                case 14:
                    priority = 5;
                    break;

                default:
                    priority = 0;
                    type = 0;
                    break;
            }
            Stack_Node node = new Stack_Node(0, priority, type);
            Stack_unary_adder(node);
        }

        static private void Stack_unary_adder(Stack_Node node)
        {
            if (node.Type >= 6 && node.Type <= 12 || node.Type >= 15 && node.Type <= 18)
            {
                stack.Add(0, node.Priority, node.Type);
            }
            else if (node.Type == 14)
            {
                list.AddNode(0, node.Priority, node.Type);
            }
            else if (node.Type == 13)
            {
                Stack_Node temp;
                while (stack.Peek().Type != 12)
                {
                    temp = stack.Pop();
                    list.AddNode(0, temp.Priority, temp.Type);
                }
                stack.Pop();
            }
        }

        static private void Stack_reaver(Stack stack)
        {
            while (stack.Head != null)
            {
                Stack_Node temp = stack.Pop();
                list.AddNode(0, temp.Priority, temp.Type);
            }
        }
    }    
}
