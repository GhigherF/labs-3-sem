#define _CRT_SECURE_NO_WARNINGS
#include "pch.h"
#include "framework.h"
#include <iostream>

extern "C"
{
	void __stdcall outnum(int value)
	{
		std::cout << value<<" ";
	}

	void _stdcall getmin(int *value,int N)
	{
		int min = INT_MAX;
		for (int i = 0; i < N; i++)
		{
			if (value[i] < min)
				min = value[i];
		}
		std::cout << "MIN:"<<min << '\n';
	}
	void _stdcall getmax(int* value, int N)
	{
		int max = INT_MIN;
		for (int i = 0; i < N; i++)
		{
			if (value[i] > max)
				max = value[i];
		}
		std::cout<<"MAX:" << max<<'\n';
	}
}


