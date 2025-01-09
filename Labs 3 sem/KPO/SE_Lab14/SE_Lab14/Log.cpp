#pragma warning(disable:4996)
#include "Log.h"
#include "LT.h"
#include "Error.h"
#include "IT.h"
#include <iostream>
#include <iomanip>
using namespace std;

namespace Log {
	LOG getlog(wchar_t logfile[])
	{
		LOG log;
		log.stream = new std::ofstream;
		log.stream->open(logfile);
		if (log.stream->fail())
			throw ERROR_THROW(112);
		wcscpy_s(log.logfile, logfile);
		return log;
	}

	void WriteLine(LOG log, const char* c, ...)
	{
		const char** ptr = &c;
		int i = 0;
		while (ptr[i] != "")
			*log.stream << ptr[i++];
		*log.stream << std::endl;
	}
	void WriteLine(LOG log, const wchar_t* c, ...)
	{
		const wchar_t** ptr = &c;
		char temp[100];
		int i = 0;
		while (ptr[i] != L"")
		{
			wcstombs(temp, ptr[i++], sizeof(temp));
			*log.stream << temp;
		}
		*log.stream << std::endl;
	}
	void WriteLog(LOG log) {

		char date[100];
		tm local;
		time_t currentTime;
		currentTime = time(NULL);
		localtime_s(&local, &currentTime);
		strftime(date, 100, "%d.%m.%Y %H:%M:%S", &local);
		*log.stream << "--- Протокол --- " << date << std::endl;

	}
	void WriteParm(LOG log, Parm::PARM parm) {

		char buff[PARM_MAX_SIZE];
		size_t tsize = 0;

		*log.stream << "--- Параметры --- " << std::endl;
		wcstombs_s(&tsize, buff, parm.in, PARM_MAX_SIZE);
		*log.stream << "-in : " << buff << std::endl;
		wcstombs_s(&tsize, buff, parm.out, PARM_MAX_SIZE);
		*log.stream << "-out: " << buff << std::endl;
		wcstombs_s(&tsize, buff, parm.log, PARM_MAX_SIZE);
		*log.stream << "-log: " << buff << std::endl;
	}
	void WriteIn(LOG log, In::IN in) {

		*log.stream << "--- Исходные данные --- " << std::endl;
		*log.stream << "Количество символов : " << in.size << std::endl;
		*log.stream << "Количество строк    : " << in.lines << std::endl;
		*log.stream << "Проигнорировано     : " << in.ignor << std::endl;
	}
	void WriteError(LOG log, Error::ERROR error)
	{
		if (log.stream)
		{
			*log.stream << "--- Ошибка!!! --- " << std::endl;
			*log.stream << "Ошибка " << error.id << ": " << error.message << std::endl;
			if (error.inext.line != -1)
			{
				*log.stream << "Строка: " << error.inext.line << std::endl << "Столбец: " << error.inext.col << std::endl <<std::endl;
			}
		}
		else
		std::cout<< "Ошибка " << error.id << ": " << error.message << ", строка " << error.inext.line << ", позиция " << error.inext.col << std::endl << std::endl;
	}

	void Log::WriteLexTable(LOG log, LT::LexTable& lextable)
	{
		int currentLine = 1;  // Èíèöèàëèçèðóåì ïåðåìåííóþ äëÿ õðàíåíèÿ òåêóùåé ñòðîêè
		*log.stream << "\n\nÒàáëèöà Ëåêñåì:\n";
		*log.stream << setw(2) << setfill('0') << currentLine << " ";
		for (int i = 0; i < lextable.size; i++) {
			if (lextable.table[i].sn != currentLine) {
				currentLine++;
				*log.stream << "\n";
				*log.stream << setw(2) << setfill('0') << currentLine << " ";
				*log.stream << LT::GetEntry(lextable, i).lexema;
			}
			else {
				*log.stream << LT::GetEntry(lextable, i).lexema;
			}
		}
	}

	void Log::WriteIdTable(LOG log, IT::IdTable& idtable)
	{
		int currentLine = 1;  // Èíèöèàëèçèðóåì ïåðåìåííóþ äëÿ õðàíåíèÿ òåêóùåé ñòðîêè
		*log.stream << "\n\nÒàáëèöà Èäåíòèôèêàòîðîâ:\n";
		for (int i = 0; i < idtable.size; i++) {
			IT::Entry ent = IT::GetEntry(idtable, i);
			*log.stream << ent.id << ", ";
			if (ent.iddatatype == 1)
			{
				*log.stream << "INT";
			}
			else {
				*log.stream << "STR";
			}

			*log.stream << ", ";

			if (ent.idtype == 1)
			{
				*log.stream << "V";
			}
			else if (ent.idtype == 2) {
				*log.stream << "F";
			}
			else
			{
				*log.stream << "P";
			}

			*log.stream << ", " << ent.idxfirstLE << ", ";

			if (ent.iddatatype == IT::INT)
			{
				*log.stream << ent.value.vint;
			}
			else {
				for (int j = 0; j < ent.value.vstr->len; j++)
				{
					*log.stream << ent.value.vstr->str[j];
				}
			}
			*log.stream << endl;
		}
	}


	void Close(LOG log) {
		log.stream->close();
		delete log.stream;
	}
}