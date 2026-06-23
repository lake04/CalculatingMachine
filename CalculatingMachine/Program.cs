using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string str;
        Stack<double> numStack = new Stack<double>();
        List<string> rearStr = new List<string>();
        Stack<string> operatorStack = new Stack<string>();

        Console.WriteLine("입력 : ");

        str = Console.ReadLine();

        int len = str.Length;
        char preChar = '\n';
        string nums = string.Empty;
        string opperator = string.Empty;

        for (int i = 0; i < len; i++)
        {
            if(preChar != '\n')
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    nums += str[i];
                }
                else if (preChar >= '0' && preChar <= '9' && str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-' )
                {
                    if (nums.Length > 0)
                    {
                        rearStr.Add(nums);
                        nums = string.Empty;
                    }
                    opperator += str[i];
                    operatorStack.Push(opperator);
                }
                else if(str[i] == '(')
                {

                }
                else if (preChar >= '0' && preChar <= '9' && str[i] == ')')
                {
                    if (nums.Length > 0)
                    {
                        rearStr.Add(nums);
                        nums = string.Empty;
                    }
                    string oppratorStack = operatorStack.Pop();
                    rearStr.Add(oppratorStack);
                }
                else
                {
                    Console.WriteLine("잘못 된 입력입니다.");
                }
            }
            else
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    nums += str[i];
                }
                else if (str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-')
                {
                    opperator += str[i];
                    operatorStack.Push(opperator);
                }
                else if (str[i] == '(')
                {

                }
                else if (str[i] == ')')
                {
                    string oppratorStack = operatorStack.Pop();
                    rearStr.Add(oppratorStack);
                }
                else
                {
                    Console.WriteLine("잘못 된 입력입니다.");
                }
            }
            preChar = str[i];
            opperator = string.Empty;
        }
        if(nums.Length > 0)
        {
            rearStr.Add(nums);
        }


        int index = 0;

        while (rearStr.Count > 0)
        {
            string cur = rearStr[index++];
            if (cur[0] >= '0' && cur[0] <= '9')
            {
                numStack.Push(cur[0] - '0');
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
                switch (cur[0])
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







