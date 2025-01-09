#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <Winsock2.h>
#include <Iphlpapi.h>
#include <string>
#include <sstream>
#include <vector>
#pragma comment(lib, "WS2_32.lib")
#pragma comment(lib, "IPHlpApi.Lib")

using namespace std;

// Функция проверки корректности IP-адреса
bool CheckAddr(char* ip_) {
    int points = 0, numbers = 0;
    char buff[4] = { 0 };

    for (int i = 0; ip_[i] != '\0'; i++) {
        if (ip_[i] >= '0' && ip_[i] <= '9') {
            if (numbers >= 3) return false;
            buff[numbers++] = ip_[i];
        }
        else if (ip_[i] == '.') {
            if (atoi(buff) > 255 || numbers == 0) return false;
            memset(buff, 0, sizeof(buff));
            numbers = 0;
            points++;
        }
        else return false;
    }

    if (points != 3) return false;
    return true;
}

// Функция преобразования MAC-адреса из строки в массив байт
bool ParseMACAddress(const string& macStr, BYTE* mac) {
    stringstream ss(macStr);
    string byteStr;
    int i = 0;

    while (getline(ss, byteStr, (macStr.find('-') != string::npos) ? '-' : ':')) {
        if (byteStr.length() != 2 || i >= 6) return false;
        mac[i++] = (BYTE)strtol(byteStr.c_str(), nullptr, 16);
    }

    return i == 6;
}

// Функция вывода MAC-адреса
void PrintMAC(BYTE* mac) {
    printf("%02X-%02X-%02X-%02X-%02X-%02X\n",
        mac[0], mac[1], mac[2], mac[3], mac[4], mac[5]);
}

// Функция поиска MAC-адреса для заданного IP
bool FindMACForIP(DWORD ip) {
    MIB_IPNETTABLE* pIpNetTable = (MIB_IPNETTABLE*) new char[0xFFFF];
    ULONG cbIpNetTable = 0xFFFF;

    if (GetIpNetTable(pIpNetTable, &cbIpNetTable, true) == NO_ERROR) {
        for (DWORD i = 0; i < pIpNetTable->dwNumEntries; i++) {
            if (pIpNetTable->table[i].dwAddr == ip && pIpNetTable->table[i].dwType != 2) {
                cout << "MAC-адрес: ";
                PrintMAC(pIpNetTable->table[i].bPhysAddr);
                delete[] pIpNetTable;
                return true;
            }
        }
    }

    delete[] pIpNetTable;
    return false;
}

// Функция поиска IP-адреса по MAC-адресу
bool FindIPForMAC(const BYTE* targetMAC) {
    MIB_IPNETTABLE* pIpNetTable = (MIB_IPNETTABLE*) new char[0xFFFF];
    ULONG cbIpNetTable = 0xFFFF;
    bool found = false;

    if (GetIpNetTable(pIpNetTable, &cbIpNetTable, true) == NO_ERROR) {
        for (DWORD i = 0; i < pIpNetTable->dwNumEntries; i++) {
            BYTE* currentMAC = pIpNetTable->table[i].bPhysAddr;

            if (memcmp(currentMAC, targetMAC, 6) == 0 && pIpNetTable->table[i].dwType != 2) {
                in_addr addr;
                addr.s_addr = pIpNetTable->table[i].dwAddr;
                cout << "Найден IP-адрес: " << inet_ntoa(addr) << endl;
                found = true;
            }
        }
    }

    delete[] pIpNetTable;
    return found;
}
int main() {
    setlocale(LC_ALL, "Russian");
    WSADATA wsaData;

    if (WSAStartup(MAKEWORD(2, 2), &wsaData) != 0) {
        cout << "Ошибка инициализации WSA!" << endl;
        return 1;
    }

    int choice;
    cout << "Выберите действие:\n";
    cout << "1. Найти MAC-адрес по IP\n";
    cout << "2. Найти IP-адрес по MAC\n";
    cout << "Ваш выбор: ";
    cin >> choice;

    if (choice == 1) {
        char ip[16];
        bool validIP;

        do {
            cout << "Введите IP-адрес: ";
            cin >> ip;
            validIP = CheckAddr(ip);
            if (!validIP) cout << "Неверный IP-адрес! Попробуйте снова." << endl;
        } while (!validIP);

        DWORD targetIP = inet_addr(ip);
        if (!FindMACForIP(targetIP)) {
            cout << "MAC-адрес для " << ip << " не найден!" << endl;
        }
    }
    else if (choice == 2) {
        string macStr;
        BYTE targetMAC[6] = { 0 };

        cout << "Введите MAC-адрес (формат XX-XX-XX-XX-XX-XX): ";
        cin >> macStr;

        if (!ParseMACAddress(macStr, targetMAC)) {
            cout << "Ошибка: некорректный MAC-адрес!" << endl;
        }
        else if (!FindIPForMAC(targetMAC)) {
            cout << "IP-адрес для введённого MAC-адреса не найден!" << endl;
        }
    }
    else {
        cout << "Неверный выбор!" << endl;
    }

    WSACleanup();
    return 0;
}
