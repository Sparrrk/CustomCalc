using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmartCalc
{
    static class Error_checker
    {
        static public int Str_check(string input_str)
        {
            int res = 0;
            res += Brackets_checker(input_str);
            res += Unary_check(input_str);
            res += Binary_check(input_str);
            res += Trash_checker(input_str);
            res += Number_check(input_str);
            return res;
        }

        static private int Brackets_checker(string input_str)
        {
            int error_flag = 0;
            int opener_index = input_str.IndexOf('(');
            int closer_index = input_str.IndexOf(')');
            if (closer_index < opener_index)
            {
                error_flag = 1;
            }
            int opener_count = input_str.Count(ch => ch == '(');
            int closer_count = input_str.Count(ch => ch == ')');
            if (opener_count != closer_count)
            {
                error_flag = 1;
            }
            return error_flag;
        }

        static private int Unary_check(string str)
        {
            int res = 0;

            string str_clone = str;

            while (str_clone.Length != 0)
            {
                int flag = Parser.Is_unary(ref str_clone);
                if (flag == 0 || flag == 13)
                {
                    str_clone = str_clone.Substring(1);
                }
                else if (flag != 14)
                {
                    str_clone = str_clone.Substring(Parser.unary_checker[flag - 6].Length);
                    if ( str_clone.Length == 0 || Parser.Is_binary(ref str_clone) != 0 || str_clone[0] == ')' )
                    {
                        res = 1;
                        break;
                    }
                }
                else if (flag == 14)
                {
                    str_clone = str_clone.Substring(Parser.unary_checker[flag - 6].Length);
                    if (Parser.Is_unary(ref str_clone) != 0 && Parser.Is_unary(ref str_clone) != 13 )
                    {
                        res = 1;
                        break;
                    }
                }
            }
            return res;
        }

        static private int Binary_check(string str)
        {
            int res = 0;
            string str_clone = str;
            
            while (str_clone.Length != 0)
            {
                if (Parser.Is_binary(ref str_clone) == 0 )
                {
                    str_clone = str_clone.Substring(1);
                }
                else
                {
                    str_clone = str_clone.Substring(1);
                    if (str_clone.Length == 0 || str_clone[0] == ')' || Parser.Is_binary(ref str_clone) != 0)
                    {
                        res = 1;
                        break;
                    }
                }
            }

            return res;
        }
        
        static private int Number_check(string input_str)
        {
            int res = 0;
            string str_clone = input_str;

            while (str_clone.Length != 0)
            {
                string number_container = Parser.Is_number(ref str_clone);
                if (number_container.Length == 0)
                {
                    str_clone = str_clone.Substring(1);
                }
                else
                {
                    str_clone = str_clone.Substring(number_container.Length);
                    int dot_count = number_container.Count(c => c == '.');
                    dot_count += number_container.Count(c => c == ',');
                    if (dot_count > 1)
                        res = 1;
                }
            }
            return res;
        }

        static private int Trash_checker(string input_str)
        {
            int res = 0;
            string str_clone = input_str;
            while (str_clone.Length != 0) {
                int flag = 0;
                str_clone = str_clone.Trim();
                int num = Parser.Is_number(ref str_clone).Length;
                int unary = Parser.Is_unary(ref str_clone);
                if (num != 0)
                {
                    flag = 1;
                    str_clone = str_clone.Substring(num);
                }
                else if (unary != 0)
                {
                    flag = 1;
                    str_clone = str_clone.Substring(Parser.unary_checker[unary - 6].Length);
                }
                else if (Parser.Is_binary(ref str_clone) != 0 || str_clone[0] == 'x')
                {
                    flag = 1;
                    str_clone = str_clone.Substring(1);
                }
                if (flag == 0)
                {
                    res = 1;
                    break;
                }
            }
            return res;
        }
    }
}
