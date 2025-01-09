#include <iostream>
#include <map>
#include <string>
#include <windows.h>
#include <queue>
#include <string>
using namespace std;


struct Element {
    char letter;
    int frequency;
    Element* left;
    Element* right;
};


struct compare {
    bool operator()(Element* l, Element* r) {
        return l->frequency > r->frequency;
    }
};


Element* newLeaf(char letter, int frequency, Element* left, Element* right) {
    Element* node = new Element();
    node->letter = letter;
    node->frequency = frequency;
    node->left = left;
    node->right = right;
    return node;
}
void decode(Element* root, int& index, string str)
{
    if (root == nullptr) {
        return;
    }
    if (!root->left && !root->right)
    {
        cout << root->letter;
        return;
    }

    index++;

    if (str[index] == '0')
        decode(root->left, index, str);
    else
        decode(root->right, index, str);
}

void encode(Element* root, string str, map<char, string>& code) {
    if (root == nullptr) return;


    if (!root->left && !root->right) {
        code[root->letter] = str;
    }

    encode(root->left, str + "0", code);
    encode(root->right, str + "1", code);
}



int main() {
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    setlocale(LC_ALL, "rus");

    char str[999];
    cout << "Введите строку: ";
    cin.getline(str, 999);


    map<char, int> freq;
    for (char ch : str) {
        if (int(ch) < 0 || int(ch) > 10) {
            freq[ch]++;
        }
    }


    freq.erase(char(-52));


    for (auto i : freq) {
        cout << i.first << " -- " << i.second << '\n';
    }


    priority_queue<Element*, vector<Element*>, compare> qu;
    for (auto i : freq) {
        qu.push(newLeaf(i.first, i.second, nullptr, nullptr));
    }

 
    while (qu.size() > 1) {
        Element* left = qu.top();
        qu.pop();
        Element* right = qu.top();
        qu.pop();
        int sum = left->frequency + right->frequency;
        qu.push(newLeaf('\0', sum, left, right));
    }


    Element* root = qu.top();
    map<char, string> code;

    encode(root, "", code);

    cout << "Коды сброса боеголовок :\n";
    for (auto i : code) {
        cout << i.first << " -- " << i.second << '\n';
    }

    string stroka = "";
    for (char ch : str) {
        stroka += code[ch];
    }
    
    cout << "Закодированная(как дед) строка: " << stroka << '\n';
    cout << "\nЗакодированная в квадрате(как дед в квадрате) строка: " << '\n';
    int index = -1;
   while (index < (int)stroka.size()-2)
    {
        decode(root, index, stroka);
    }
}
