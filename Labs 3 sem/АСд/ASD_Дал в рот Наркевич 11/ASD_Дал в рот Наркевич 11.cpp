#include <iostream>
#include <vector>
#include <random>
#include <algorithm>
#include <windows.h>

using namespace std;

void main() 
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    int N;
    cout << "Количество траев: ";
    cin >> N;

    int умныйCounter = 0;
    int тупойCounter = 0;

    random_device rand;
    mt19937 gen(rand());

    vector<int> boxes(100);
    for (int i = 0; i < 100; i++) boxes[i] = i + 1;

    for (int n = 0; n < N; n++)
    {
        shuffle(boxes.begin(), boxes.end(), gen);

        bool  globalFlag= true;
        for (int i = 1; i <= 100; i++)
        {
            bool flag = false;
            for (int j = 0; j < 50; j++)
            {
                int randomIndex = gen() % 100; 
                if (boxes[randomIndex] == i)
                {
                    flag= true;
                    break;
                }
            }
            if (!flag)
            {
                globalFlag = false;
                break;
            }
        }
        тупойCounter += globalFlag ? 1 : 0;

        globalFlag = true;
        for (int i = 1; i <= 100; i++)
        {
            int pos = i - 1; 
            bool flag = false;
            for (int j = 0; j < 50; j++)
            {
                if (boxes[pos] == i)
                {
                    flag = true;
                    break;
                }
                pos = boxes[pos] - 1;
            }
            if (!flag)
            {
                globalFlag = false;
                break;
            }
        }
        умныйCounter += globalFlag ? 1 : 0;
    }

    cout << "Вумны: " << умныйCounter << "\\" << N << endl;
    cout << "Глупы: " << тупойCounter << "\\" << N << endl;
}