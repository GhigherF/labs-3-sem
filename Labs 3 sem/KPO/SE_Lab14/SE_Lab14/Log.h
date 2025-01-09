#pragma once
#include <fstream>
#include "In.h"
#include "Parm.h"
#include "Error.h"

namespace Log
{
	struct LOG
	{
		wchar_t logfile[PARM_MAX_SIZE];
		std::ofstream* stream;
	};

	static const LOG INITLOG{ L"",NULL };
	LOG getlog(wchar_t logfile[]);
	void WriteLine(LOG log, const char* c, ...);
	void WriteLine(LOG log, const wchar_t* c, ...);
	void WriteLog(LOG log);
	void WriteIn(LOG log, In::IN in);
	void WriteParm(LOG log,Parm::PARM parm);
	void WriteError(LOG log, Error::ERROR error);
	void WriteLexTable(LOG log, LT::LexTable& lextable);

	void WriteIdTable(LOG log, IT::IdTable& idtable);
	void Close(LOG log);
};
