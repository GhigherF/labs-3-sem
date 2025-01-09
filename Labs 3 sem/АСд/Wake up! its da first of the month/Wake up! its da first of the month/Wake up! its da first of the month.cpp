#include <iostream>
#include <chrono>
using namespace std;
int num = 0;
void twinTowers(int n, int i, int k)
{
	if (n == 1)
	{
		num += 1;
		cout << n << "," << i << "---->" << k<<'\n';
	}
	else
	{
		num += 1;
int temp = 6-i-k;
	twinTowers(n - 1, i, temp);
	cout << n << "," << i << "---->" << k<<'\n';
	twinTowers(n - 1, temp, k);
	}
	
}

void main()
{
	int N, i, k;
	cout << "N:";
	cin >> N;
	if (N <= 0) {
		cout << "WRONG!"; exit(228);
	}
	cout <<'\n'<< "i:";
	cin >> i;
	if (i<1||i>3) {
		cout << "WRONG!"; exit(228);
	}
	cout << '\n' << "k:";
	cin >> k;
	if (k< 1 || k>3) {
		cout << "WRONG!"; exit(228);
	}
	cout << '\n';
	float a = clock();
	twinTowers(N, i, k);
	float b = clock();
	cout << "Time:" << (b - a) / 1000<<'\n'<<"Moves:"<<num;
}