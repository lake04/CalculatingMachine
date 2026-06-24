using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Operator
{
    public string sign;
    public int priority;
    //곱하기 : 2
    // 나눗셈 : 2
    //덧쏌 : 1
    //뼬썜 : 1
    //수가 클수록 우선순위가 높음
}

class Program
{
    static void Main(string[] args)
    {
        string str;

        Stack<double> numStack = new Stack<double>();
        List<string> rearStr = new List<string>();
        Stack<Operator> operatorStack = new Stack<Operator>();

        Console.WriteLine("입력 : ");

        str = Console.ReadLine();

        int len = str.Length;
        char preChar = '\n';
        string nums = string.Empty;

        for (int i = 0; i < len; i++)
        {
            if (preChar != '\n')
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    nums += str[i];
                }
                else if(str[i] == '.')
                {
                    nums += '.';
                }
                else if (str[i] == '-' && (preChar == '\n' || preChar == '(' || preChar == '+' || preChar == '-' || preChar == '*' || preChar == '/'))
                {
                    nums += '-';
                }
                else if (str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-')
                {
                    if (nums.Length > 0)
                    {
                        rearStr.Add(nums);
                        nums = string.Empty;
                    }
                    OperatorComparison(str[i]);
                }
                else if (str[i] == '(')
                {
                    if (nums.Length > 0)
                    {
                        rearStr.Add(nums);
                        nums = string.Empty;
                    }

                    Operator open = new Operator();
                    open.sign = "(";
                    open.priority = -1;

                    operatorStack.Push(open);
                }
                else if (str[i] == ')')
                {
                    if (nums.Length > 0)
                    {
                        rearStr.Add(nums);
                        nums = string.Empty;
                    }
                    while (operatorStack.Count > 0 && operatorStack.Peek().sign != "(")
                    {
                        rearStr.Add(operatorStack.Pop().sign);
                    }
                    if (operatorStack.Count == 0)
                    {
                        Console.WriteLine("괄호가 맞지 않습니다.");
                    }
                    else
                    {
                        operatorStack.Pop();
                    }
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
                else if (str[i] == '-')
                {
                    nums += '-';
                }
                else if (str[i] == '(')
                {
                    Operator open = new Operator();
                    open.sign = "(";
                    open.priority = -1;

                    operatorStack.Push(open);
                }
                else
                {
                    Console.WriteLine("잘못 된 입력입니다.");
                }
            }
            preChar = str[i];
        }

        if (nums.Length > 0)
        {
            rearStr.Add(nums);
        }

        while (operatorStack.Count > 0)
        {
            string cur = operatorStack.Pop().sign;
            rearStr.Add(cur);
        }

        for (int i = 0; i < rearStr.Count; i++)
        {
            Console.WriteLine(rearStr[i]);
        }

        for (int i = 0; i < rearStr.Count; i++)
        {
            string cur = rearStr[i];
            if (double.TryParse(cur, out double num))
            {
                numStack.Push(num);
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
                        numStack.Push(sum);
                        break;
                    case '/':
                        sum = num2 / num1;
                        numStack.Push(sum);
                        break;
                    case '+':
                        sum = num1 + num2;
                        numStack.Push(sum);
                        break;
                    case '-':
                        sum = num2 - num1;
                        numStack.Push(sum);
                        break;
                }
            }
        }

        double rel = numStack.Pop();

        Console.WriteLine(rel.ToString("0.#####"));

        void OperatorComparison(char op)
        {
            Operator curOperator = new Operator();

            curOperator.sign = op.ToString();
            curOperator.priority = GetPriority(op);

            while (operatorStack.Count > 0 &&
                   operatorStack.Peek().sign != "(" &&
                   operatorStack.Peek().priority >= curOperator.priority)
            {
                Operator preOperator = operatorStack.Pop();

                rearStr.Add(preOperator.sign);
            }

            operatorStack.Push(curOperator);
        }

        int GetPriority(char op)
        {
            switch (op)
            {
                case '*':
                case '/':
                    return 2;

                case '+':
                case '-':
                    return 1;
            }

            return -1;
        }

    }
}