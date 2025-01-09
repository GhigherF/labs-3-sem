#include <iostream>
#include <windows.h>
#include <vector>
using namespace std;

void main()
{
	int startpoint;
	char a;
	int temp;
	int index=99998;
	int value;
	SetConsoleOutputCP(1251);
	int matrix[9][9] = {0,7,10,0,0,0,0,0,0,
						7,0,0,0,0,9,27,0,0,
						10,0,0,0,31,8,0,0,0,
						0,0,0,0,32,0,0,17,21,
						0,0,31,32,0,0,0,0,0,
						0,9,8,0,0,0,0,11,0,
						0,27,0,0,0,0,0,0,15,
						0,0,0,17,0,11,0,0,15,
						0,0,0,21,0,0,15,15,0};
	cout << "Вершина:";
	cin >>a;
	startpoint = int(a) - 65;
	int visited[9];
	int min[9];

	for (int i = 0; i < 9; i++)
	{
		min[i] = 99999;
		visited[i] = 1;
	}
	min[startpoint] = 0;
	while (index < 99999)
	{
		index = 99999;
		value = 99999;
		for (int i = 0; i < 9; i++)
		{
			if ((visited[i] == 1) && (min[i] < value))
			{
				value=min[i];
				index=i;
			}
		}
		if (index != 99999)
		{
			for (int i = 0; i < 9; i++)
			{
				if (matrix[index][i] > 0)
				{
					temp = value + matrix[index][i];
					if (temp < min[i]) min[i] = temp;
				}
			}
			visited[index] = 0;
		}
	}
	printf("\nКратчайшие расстояния до вершин: \n");
	for (int i = 0; i < 9; i++)
		printf("%5d ", min[i]);
}