using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string str;
        Stack<double> numStack = new Stack<double>();
        Stack<char> rearStr = new Stack<char>();
        Stack<char> operatorStack = new Stack<char>();

        Console.WriteLine("입력 : ");

        str = Console.ReadLine();

        int len = str.Length;

        for (int i = 0; i < len; i++)
        {
            if (str[i] >= '0' && str[i] <= '9')
            {
                rearStr.Push(str[i]);
            }
            else if (str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-')
            {
                operatorStack.Push(str[i]);
            }
            else if (str[i] == ')')
            {
                char oppratorStack = operatorStack.Pop();
                rearStr.Push(oppratorStack);
            }
            else
            {
                Console.WriteLine("잘못 된 입력입니다.");
            }
        }

        while (rearStr.Count > 0)
        {
            char cur = rearStr.Pop();
            if (cur >= '0' && cur <= '9')
            {
                numStack.Push(cur - '0');
            }
            else
            {
                double num1 = 0;
                double num2 = 0;
                double sum = 0;

                if (numStack.Count > 0)
                {
                    num1 = numStack.Pop();
                }
                if (numStack.Count > 0)
                {
                    num2 = numStack.Pop();
                }
                switch (cur)
                {
                    case '*':
                        sum = num1 * num2;
                        break;
                    case '/':
                        sum = num2 / num1;
                        break;
                    case '+':
                        sum = num1 + num2;
                        break;
                    case '-':
                        sum = num2 - num1;
                        break;
                }
                if (sum != 0)
                {
                    numStack.Push(sum);
                }
            }
        }
    }

}







