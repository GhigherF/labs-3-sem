#include  <iostream>
#pragma comment(lib,"C:/Users/stude/OneDrive/Рабочий стол/Labs/labs/Labs 3 sem/KPO/KPO_19/Debug/StaticLib1.lib")

extern "C"
{
void _stdcall getmin(int* a, int b);
void _stdcall getmax(int* a, int b);
}



void main()	
{
	int a[10]{ 1,2,3,4,5,6,7,8,9,10 };
	getmin(a, 10);
	getmax(a, 10);
}