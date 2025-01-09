#include "pch.h"
#include <iostream>

extern "C"
{
void _stdcall outnum(int N)
	{
	std::cout <<N<<std::endl;
	}
void _stdcall getmin(int* a, int N)
{
	int min = a[0];
	for (int i = 0; i < N; i++)
	{
		if (min > a[i])
		{
			min = a[i];
		}
	}
	std::cout << min << std::endl;
}
void _stdcall getmax(int* a, int N)
{
	int max = a[0];
	for (int i = 0; i < N; i++)
	{
		if (max < a[i])
		{
			max = a[i];
		}
	}
	std::cout << max << std::endl;
}
}
