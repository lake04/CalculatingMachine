#include "calculating.h"
#include <stack>
#include <iostream>

using namespace std;

int main()
{
	string str;
	stack<int> num1;

	cout <<"ют╥б : ";
	cin >> str;

	int len = str.length();
	for (int i = 0; i < len; i++)
	{
		if (str[i] >= '0' && str[i] <= '9')
		{
			num1.push(str[i] - '0');
		}
		else
		{
			if (num1.empty())
			{
				return 0;
			}
			int num2 = num1.top();
			num1.pop();
			int num3 = num1.top();
			if (num1.empty())
			{
				return 0;
			}
			num1.pop();
			switch (str[i])
			{
			case '+':
				num1.push(num3 + num2);
				break;
			case '-':
				num1.push(num3 - num2);
				break;
			case '*':
				num1.push(num3 * num2);
				break;
			case '/':
				num1.push(num3 / num2);
				break;
			default:
				break;
			}
		}
	}

	return 0;
}
