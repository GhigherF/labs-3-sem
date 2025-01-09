#include <iostream>
#include <iomanip>
using namespace std;

struct item
{
	string name;
	int price;
	int weight;
};


void main()
{
cout << "N:";
int N=0;
cin>>N;
cout<<"\nItems:\n";
int k =0;
item* temp = new item[k+1];
item* items = new item[k + 1];
while (true)
{
	
cout << "name:";
		cin >> temp[k].name;
		cout << "price:";
		cin >> temp[k].price;
		cout << "weight:";
		cin >> temp[k].weight;
		cout<<"\n------------------------\n";

		k += 1;
		items = new item[k+1];
		for (int i = 0; i < k; i++)
		{
			items[i] = temp[i];
		}
		delete[] temp;
		//item *temp=new item[k];
		temp=items;


		cout << "?";
		bool flag;
		cin >> flag;
		if (flag == false)
		{
			break;
		}
}
item** memo = new item * [k + 1];

for (int i = 0; i <= k; i++) {
	memo[i] = new item[N + 1];
}



for (int i = 0; i <= k; i++) {
	for (int j = 0; j <= N; j++) {
		if (i == 0 || j == 0) {
			memo[i][j] ={"",0,0};
		}
		else if (i == 1)
			{
			if (items[0].weight <= j)memo[1][j] = items[0]; else memo[1][j] = { "",0,0 };
			} else
				if(items[i-1].weight>j)
					memo[i][j] = memo[i - 1][j];
				else
				{
					int tempPrice=items[i-1].price+memo[i-1][j-items[i-1].weight].price;
					if (memo[i-1][j].price>tempPrice) memo[i][j]=memo[i-1][j];
					else
					{
						memo[i][j].name=items[i - 1].name+"+"+memo[i - 1][j - items[i - 1].weight].name;
						memo[i][j].price = tempPrice;
						memo[i][j].weight = memo[i-1][j-items[i-1].weight].weight+items[i-1].weight;
					}
				}
		
	}
}

cout << '\n';
int max = INT_MIN;
item* maximum=new item;
for (int i = 1; i < k+1; i++)
	{
		for (int j = 1; j < N+1; j++)
		{
			if (memo[i][j].price >max) maximum =&memo[i][j];
		cout<<memo[i][j].price << "    ";
		}
		cout << '\n';
	}
	cout << '\n' << '\n' << '\n';
	cout<<"MAXIMUM:"<<"\n"<<"Name:"<<maximum->name << "\n Weight:" << maximum->weight << "\nPrice:" << maximum->price;
	cout << '\n' << '\n' << '\n';
	delete[] items;
	for (int i = 0; i <= k; i++) {
		delete[] memo[i];
	}
	delete[] memo;
}