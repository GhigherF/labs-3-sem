#include <iostream>
#include "Out.h"
#include "Log.h"
#include <fstream>
#include "Error.h"
#include <cstdarg>
#include <ctime>


using namespace Out;
using namespace std;
using namespace Parm;
using namespace In;


namespace Out {

	OUT getout(wchar_t outfile[])
	{
		OUT out;
		ofstream* file = new ofstream(outfile);
		if (!file->is_open())
		{
			delete file;
			ERROR_THROW(113);
		}
		wcscpy_s(out.outfile, outfile);
		out.stream = file;
		return out;
	}

	void Out::WriteToFile(OUT out, In::IN in)
	{
		*out.stream << in.text;
	}

	void WriteToError(OUT out, Error::ERROR error)
	{
		if (out.stream) { // åñëè îòêðûò ïîòîê äëÿ çàïèñè
			*out.stream << "Îøèáêà " << error.id << ": " << error.message; // âûâîäèì ñîîáùåíèå îá îøèáêå
			if (error.inext.line != -1) { // åñëè èìååòñÿ èíôîðìàöèè î ìåñòå îøèáêå, òî âûâîäèì è ýòó èíôîðìàöèþ
				*out.stream << ", ñòðîêà " << error.inext.line << ", ïîçèöèÿ " << error.inext.col << '\n';
			}
			else {
				*out.stream << '\n';
			}
		}
		else { // åñëè ïîòîê íå îòêðûò, òî âûâîäèì èíôîðìàöèþ â êîíñîëü
			cout << "Îøèáêà " << error.id << ": " << error.message << '\n';
			cout << "Ñòðîêà " << error.inext.line << ", ïîçèöèÿ " << error.inext.col << '\n';
		}

	}

	void CloseFile(OUT out)
	{
		out.stream->close();
		delete out.stream;
	}

}