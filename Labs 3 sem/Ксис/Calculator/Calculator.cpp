#include  <iostream>
#include <bitset>
#include <string>
using namespace std;

bool checkAdress(const char* ip)
{
    int counter = 0, number = 0;
    char temp[4];


    for (int i = 0; ip[i] != '\0'; ++i)
    {
        if (isdigit(ip[i]))
        {
            if (number >= 3) return false;
            temp[number] = ip[i];
            number += 1;
        }
        else if (ip[i] == '.')
        {
            temp[number] = '\0';
            if (number == 0 || atoi(temp) > 255) return false;
            number = 0;
            counter += 1;
        }
        else
        {
            return false;
        }
    }

    temp[number] = '\0';
    if (number == 0 || atoi(temp) > 255) return false;
    return counter == 3;
}


bool checkMask(unsigned long mask) {
    bool foundZero = false;
    for (int i = 31; i >= 0; --i) {
        if ((mask & (1 << i)) == 0) {
            foundZero = true;
        }
        else if (foundZero) {
            return false;
        }
    }
    return true;
}

unsigned long charToUL(const char* ip_) {
    unsigned long result = 0;

    for (int i = 0; ip_[i] != '\0';) {
        unsigned long octet = 0;

        while (ip_[i] != '.' && ip_[i] != '\0') {
            octet = octet * 10 + (ip_[i] - '0');
            i++;
        }
        result = (result << 8) + octet;

        if (ip_[i] == '.') i++;
    }

    return result;
}


string ulToChar(unsigned long ip)
{
    string result;
    for (int i = 3; i >= 0; --i)
    {
        result += to_string(ip >> (i * 8) & 0xFF);
        if (i != 0)result += '.';
    }
    return result;
}

void main()
{
    unsigned long ip, mask, net, host, broadcast;
    char ip_[16], mask_[16];
    bool flag = true;

    do
    {
        if (!flag) cout << "WROING ADRESS!" << '\n';
        cout << "ip:";
        cin >> ip_;
    } while (!(flag = checkAdress(ip_)));

    ip = charToUL(ip_);

    flag = true;
        

    do {
        if (!flag) std::cout << "WRONG MASK!" << std::endl;
        std::cout << "mask: ";
        std::cin >> mask_;
    } while (!(flag = checkAdress(mask_)) || !(flag = checkMask(mask = charToUL(mask_))));

    net = ip & mask;
    host = ip & ~mask;
    broadcast = ip | ~mask;


    cout << ulToChar(net) << '\n';
    cout << ulToChar(host) << '\n';
    cout << ulToChar(broadcast) << '\n';
}