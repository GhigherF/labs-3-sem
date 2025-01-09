#include <iostream>
#include <vector>
#include <string>
#include <stack>

using namespace std;



pair<vector <int>,int> longest(vector<int> numbers) {
  
    if (numbers.size() == 1) {
        pair<vector<int>, int> rtrn;
        rtrn.first = numbers;
        rtrn.second = 1;
        return rtrn;
    }
	

    vector<int> SubLength(numbers.size(), 1);

    for (int i = 0; i < numbers.size(); i++)
    {
        for (int j = 0; j < i; j++)
        {
            if (numbers[i] > numbers[j]) {
                if (SubLength[i] <=SubLength[j]) {
                    SubLength[i] = SubLength[j] + 1;
                }
            }
        }
    }

    int max = INT_MIN;

    for (int i : SubLength) {
        if (i > max) 
        {
			max = i;
		}   
    }
    pair<vector<int>, int> rtrn;
    rtrn.first = SubLength;
    rtrn.second=max;
    return rtrn;
}

void restore(vector<int> numbers, pair<vector<int>,int> count)
{
    string a = "";
    bool flag = false;
    int compare = INT_MAX;
    for (int i = numbers.size()-2;i >=0; i--)
    {   
        if (count.first[i] == count.second&&numbers[i]<compare) {
            if (count.second == 2 && flag == false) 
            {
                flag = true;
                continue;
            }
			a = to_string(numbers[i])+" "+a;
            count.second -= 1;
            compare = numbers[i];
		}
    }
    cout << a<<'\n';
}


void main()
{
	int N;
	cout << "Length:";
    cin>>N;
 vector<int> numbers(N);
    for (int i = 0; i < N; i++)
    {
        cin >> numbers[i];
    }
   pair<vector <int>,int> temp=longest(numbers);
	for (int i : temp.first) {
		cout << i << " ";
	}
    cout << '\n' << '\n';
    restore(numbers, temp);
}