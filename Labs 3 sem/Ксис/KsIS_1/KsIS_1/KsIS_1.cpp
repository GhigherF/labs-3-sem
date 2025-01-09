#define _WINSOCK_DEPRECATED_NO_WARNINGS
#include <iostream>
#include <conio.h>
#include <winsock2.h>
#include <iphlpapi.h>
#include <Icmpapi.h>

using namespace std;
#pragma comment(lib, "iphlpapi.lib")
#pragma comment(lib, "ws2_32.lib")

#define IP_STATUS_BASE 11000
#define IP_SUCCESS 0
#define IP_DEST_NET_UNREACHABLE 11002
#define IP_DEST_HOST_UNREACHABLE 11003
#define IP_DEST_PROT_UNREACHABLE 11004
#define IP_DEST_PORT_UNREACHEBLE 11005
#define IP_REQ_TIMED_OUT 11010
#define IP_BAD_RWQ 11011
#define IP_BAD_ROUTE 11012
#define IP_TTL_EXPIRED_TRANSIT 11013

void Ping(const char* cHost, unsigned int Timeout, unsigned int RequestCount)
{
    // Check for null pointer reference
    if (cHost == nullptr)
    {
        cerr << "Error: cHost is null." << endl;
        return;
    }

    HANDLE hIP = IcmpCreateFile();
    if (hIP == INVALID_HANDLE_VALUE)
    {
        WSACleanup();
        cerr << "Error: IcmpCreateFile failed." << endl;
        return;
    }

    char SendData[32] = "Data for ping";
    int LostPacketsCount = 0;
    unsigned int MaxMS = 0;
    int MinMS = -1;

    PICMP_ECHO_REPLY pIpe = (PICMP_ECHO_REPLY)GlobalAlloc(GHND, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData));
    if (pIpe == nullptr)
    {
        IcmpCloseHandle(hIP);
        WSACleanup();
        cerr << "Error: GlobalAlloc failed." << endl;
        return;
    }

    pIpe->Data = SendData;
    pIpe->DataSize = sizeof(SendData);

    unsigned long ipaddr = inet_addr(cHost);
    if (ipaddr == INADDR_NONE)
    {
        IcmpCloseHandle(hIP);
        GlobalFree(pIpe);
        WSACleanup();
        cerr << "Error: inet_addr failed." << endl;
        return;
    }

    IP_OPTION_INFORMATION option = { 255, 0, 0, 0, 0 };

    try
    {
        for (unsigned int c = 0; c < RequestCount; c++)
        {
            int dwStatus = IcmpSendEcho(hIP, ipaddr, SendData, sizeof(SendData), &option, pIpe, sizeof(ICMP_ECHO_REPLY) + sizeof(SendData), Timeout);
            if (dwStatus > 0)
            {
                for (int i = 0; i < dwStatus; i++)
                {
                    unsigned char* pIpPtr = (unsigned char*)&pIpe->Address;
                    cout << "Ответ от " << (int)*(pIpPtr) << "." << (int)*(pIpPtr + 1) << "." << (int)*(pIpPtr + 2) << "." << (int)*(pIpPtr + 3) << ": число байт = " << pIpe->DataSize << " время = " << pIpe->RoundTripTime << "мс TTL = " << (int)pIpe->Options.Ttl;
                    MaxMS = (MaxMS > pIpe->RoundTripTime) ? MaxMS : pIpe->RoundTripTime;
                    MinMS = (MinMS < (int)pIpe->RoundTripTime && MinMS >= 0) ? MinMS : pIpe->RoundTripTime;
                    cout << endl;
                }
            }
            else
            {
                if (pIpe->Status)
                {
                    LostPacketsCount++;
                    switch (pIpe->Status)
                    {
                    case IP_DEST_NET_UNREACHABLE:
                    case IP_DEST_HOST_UNREACHABLE:
                    case IP_DEST_PROT_UNREACHABLE:
                    case IP_DEST_PORT_UNREACHABLE:
                        cout << "Remote host may be down." << endl;
                        break;
                    case IP_REQ_TIMED_OUT:
                        cout << "Request timed out." << endl;
                        break;
                    case IP_TTL_EXPIRED_TRANSIT:
                        cout << "TTL expired in transit." << endl;
                        break;
                    default:
                        cout << "Error code: %ld" << pIpe->Status << endl;
                        break;
                    }
                }
                cout << ": число байт = " << pIpe->DataSize << " время = " << pIpe->RoundTripTime << "мс TTL = " << (int)pIpe->Options.Ttl;
                MaxMS = (MaxMS > pIpe->RoundTripTime) ? MaxMS : pIpe->RoundTripTime;
                MinMS = (MinMS < (int)pIpe->RoundTripTime && MinMS >= 0) ? MinMS : pIpe->RoundTripTime;
                cout << endl;
            }
        }
    }
    catch (const std::exception& e)
    {
        IcmpCloseHandle(hIP);
        GlobalFree(pIpe);
        WSACleanup();
        cerr << "Error: " << e.what() << endl;
        return;
    }

    IcmpCloseHandle(hIP);
    GlobalFree(pIpe);
    WSACleanup();

    if (MinMS < 0) MinMS = 0;
    unsigned char* pByte = (unsigned char*)&pIpe->Address;
    cout << "Статистика Ping " << (int)*(pByte) << "." << (int)*(pByte + 1) << "." << (int)*(pByte + 2) << "." << (int)*(pByte + 3) << endl;
    cout << "\tПакетов: отправлено = " << RequestCount << ", получено = " << RequestCount - LostPacketsCount << ", потеряно = " << LostPacketsCount << "<" << (int)(100 / (float)RequestCount) * LostPacketsCount << " % потерь>, " << endl;
    cout << "Приблизительное время приема-передачи:" << endl << "Минимальное = " << MinMS << "мс, Максимальное = " << MaxMS << "мс, Среднее = " << (MaxMS + MinMS) / 2 << "мс" << endl;
}

int main(int argc, char** argv)
{
    setlocale(LC_ALL, "RUS");
    try
    {
        Ping("81.19.70.1", 60, 10);
    }
    catch (const std::exception& e)
    {
        cerr << "Error: " << e.what() << endl;
        return 1;
    }
    _getch();
    return 0;
}
