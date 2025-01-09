#include <iostream>
#include "Error.h"
#include "Parm.h"
#include "Log.h"
#include "In.h"
#include "Out.h"
#include "FST.h"
#include "LT.h"
#include "IT.h"
#include "Flexer.h"

using namespace std;

int _tmain(int argc,_TCHAR* argv[]) {

    setlocale(LC_ALL, "RU");

    cout << "---- ���� Parm::getparm ----" << endl << endl;
    Parm::PARM parm;
    Log::LOG log = Log::INITLOG;
    Out::OUT out = Out::INIOUT;

    try {
        parm = Parm::getparm(argc,argv);
        wcout << "-in:" << parm.in << ", -out:" << parm.out << ", -log:" << parm.log << endl << endl;
        log = Log::getlog(parm.log);
        Log::WriteLog(log);
        Log::WriteParm(log, parm);
    }
    catch (Error::ERROR e) {
        cout << "������ " << e.id << ": " << e.message << endl << endl;
    }

    cout << "---- ���� In::getin ----" << endl << endl;
    try {
        parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);


        cout << in.text << endl;
        cout << "����� ��������: " << in.size << endl;
        cout << "����� �����: " << in.lines << endl;
        cout << "���������: " << in.ignor << endl;
        Log::WriteIn(log, in);


    }
    catch (Error::ERROR e) {
        cout << "������ " << e.id << ": " << e.message << endl << endl;
        cout << "������ " << e.inext.line << " ������� " << e.inext.col << endl << endl;
        log = Log::getlog(parm.log);
        Log::WriteError(log, e);
        out = Out::getout(parm.out);
        Out::WriteToError(out, e);

    }
    try {
        parm = Parm::getparm(argc, argv);
        In::IN in = In::getin(parm.in);
        LT::LexTable lextab = LT::Create(LT_MAXSIZE - 1);
        IT::IdTable idtab = IT::Create(TI_MAXSIZE - 1);
        Flexer::Exe(lextab,idtab,in);
        Log::WriteLexTable(log, lextab);
        Log::WriteIdTable(log, idtab);

        out = Out::getout(parm.out);
        Out::WriteToFile(out, in);
    }
    catch (Error::ERROR e)
    {
        cout << "������ " << e.id << ": " << e.message << endl << endl;
        Log::WriteError(log, e);
        out = Out::getout(parm.out);
        Out::WriteToError(out, e);
    }


    system("pause");
    return 0;
}