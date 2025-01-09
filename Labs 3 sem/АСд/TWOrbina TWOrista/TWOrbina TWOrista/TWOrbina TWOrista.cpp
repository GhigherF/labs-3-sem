#include <iostream>
#include <windows.h>
#include <vector>
using namespace std;

bool check(int a,vector <int> b,vector <int> c)
{
	bool flag = false;
	for (int i = 0; i < b.size(); i++)
	{
		if (a == b[i]) flag = true;
	}
	for (int i = 0; i < c.size(); i++)
	{
		if (a == c[i]) flag = true;
	}
	return flag;
}

vector <int> pop_front(vector <int> &arr)
{
	vector <int> a;
	for (int i = 1; i < arr.size(); i++)
	{
		a.push_back(arr[i]);
	}
	return a;
}


void main()
{	
	SetConsoleOutputCP(1251);
	vector <int> visited;
	bool matrix[10][10] = {	0,1,0,0,1,0,0,0,0,0,
							1,0,0,0,0,0,1,1,0,0,
							0,0,0,0,0,0,0,1,0,0,
							0,0,0,0,0,1,0,0,1,0,
							1,0,0,0,0,1,0,0,0,0,	
							0,0,0,1,1,0,0,0,1,0,
							0,1,0,0,0,0,0,1,0,0,
							0,1,1,0,0,0,1,0,0,0,
							0,0,0,1,0,1,0,0,0,1,
							0,0,0,0,0,0,0,0,1,0};
	
	int at[22] = {1,1,2,2,2,3,4,4,5,5,6,6,6,7,7,8,8,8,9,9,9,10};
	int to[22] = {2,5,1,7,8,8,6,9,1,6,4,6,9,2,8,2,7,3,4,6,10,9};
	
	int row0[3] = {1,2,5};
	int row1[4] = {2,1,7,8};
	int row2[2] = {3,8};
	int row3[3] = {4,6,9};
	int row4[3] = {5,1,6};
	int row5[4] = {6,4,5,9};
	int row6[3] = {7,2,8};
	int row7[4] = {8,2,3,7};
	int row8[4] = {9,4,6,10};
	int row9[2] = {10,9};
	int* teeth[10] = {row0,row1,row2,row3,row4,row5,row6,row7,row8,row9};
	int teethSize[10] = {3,4,2,3,3,4,3,4,4,2};
	int i=0,sum=0;
	
	vector<int> queue;
	vector <int> stack;
	int temp=0;
	i=0;
cout << "Матрица смежности:100"<<'\n';
	cout << "Список ребёр и список смежности: 21"<<'\n';
	//BFS
	queue.push_back(1);
	while (!queue.empty())
	{
		temp = queue.front();
		queue=pop_front(queue);
		visited.push_back(temp);
		i = temp;
		for (int j = 1; j <=10; j++)
		{
			
			if (matrix[i-1][j-1] == true && check(j,visited,queue)==false) queue.push_back(j);
		}
	}
	//vector <int> gg = { 1,2,3,4,5 };

	cout << "BFS матрица смежности:" << '\n';
	while (!visited.empty())
	{
		cout << visited.front() << " ";
		visited=pop_front(visited);
	}
	cout << '\n';
	//DFS
	stack.push_back(1);
	while (!stack.empty())
	{
		temp = stack.back();
		stack.pop_back();
		visited.push_back(temp);
		i = temp;
		for (int j = 1; j <= 10; j++)
		{
			if (matrix[i - 1][j - 1] == true && check(j, visited,stack)==false) stack.push_back(j);
		}
	}
	cout << "DFS матрица смежности:" << '\n';
	while (!visited.empty())
	{
		cout << visited.front() << " ";
		visited = pop_front(visited);
	}
	cout << '\n';
	///BFS
	queue.push_back(1);
	while (!queue.empty())
	{
		temp = queue.front();
		queue = pop_front(queue);
		visited.push_back(temp);
		for (i=0;i<22;i++)
		{
			if (at[i]==temp && check(to[i],visited,queue)==false) queue.push_back(to[i]);
		}
	}

	cout << "BFS список ребёр:" << '\n';
	while (!visited.empty())
	{
		cout << visited.front() << " ";
		visited = pop_front(visited);
	}
	cout << '\n';

	///DFS
	stack.push_back(1);
	while (!stack.empty())
	{
		temp = stack.back();
		stack.pop_back();
		visited.push_back(temp);
		for (i = 0; i < 22; i++)
		{
			if (at[i] == temp && check(to[i], visited, stack) == false) stack.push_back(to[i]);
		}
	}
	cout << "DFS список рёбер:" << '\n';
	while (!visited.empty())
	{ 
		cout << visited.front() << " ";
		visited = pop_front(visited);
	}
	cout << '\n';

	///BFS
	queue.push_back(1);
	while (!queue.empty())
	{
		temp = queue.front();
		queue = pop_front(queue);
		visited.push_back(temp);
		int* ptr=teeth[temp-1];
		ptr += 1;
		for (int j = 1; j <teethSize[temp-1]; j++)
		{

			if (check(*ptr, visited, queue) == false)queue.push_back(*ptr);
			ptr += 1;
		}
	}

	cout << "BFS список смежности:" << '\n';
	while (!visited.empty())
	{
		cout << visited.front() << " ";
		visited = pop_front(visited);
	}
	cout << '\n';
	///DFS

	stack.push_back(1);
	while (!stack.empty())
	{
		temp = stack.back();
		stack.pop_back();
		visited.push_back(temp);
		int* ptr = teeth[temp - 1];
		ptr += 1;
		for (int j = 1; j < teethSize[temp - 1]; j++)
		{
			if (check(*ptr, visited,stack) == false) stack.push_back(*ptr);
			ptr += 1;
		}
	}

	cout << "DFS список смежности:" << '\n';
	while (!visited.empty())
	{
		cout << visited.front() << " ";
		visited = pop_front(visited);
	}
	cout << '\n';

}