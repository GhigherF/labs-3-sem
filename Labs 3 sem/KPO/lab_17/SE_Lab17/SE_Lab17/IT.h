#pragma once
#define ID_MAXSIZE		5
#define TI_MAXSIZE		4096
#define TI_SMALL_DEFAULT	0x00000000
#define TI_SYMB_DEFAULT	0x0
#define TI_NULLIDX		0xffffffff
#define TI_STR_MAXSIZE  255

namespace IT
{
	enum IDDATATYPE { SML = 1, SMB = 2 };
	enum IDTYPE { V = 1, F = 2, P = 3, L = 4 };

	struct Entry
	{
		int		idxfirstLE;
		std::string	id;
		IDDATATYPE iddatatype;
		IDTYPE	idtype;
		struct
		{
			int vsmall = TI_SMALL_DEFAULT;
			char vsymbol = TI_SYMB_DEFAULT;
		} value;
	};

	struct IdTable
	{
		int maxsize;
		int size;
		Entry* table;
	};


	IdTable Create(
		int size
	);

	void Add(
		IdTable& idtable,
		Entry entry
	);

	Entry GetEntry(
		IdTable& idtable,
		int n
	);

	int IsId(
		IdTable& idtable,
		std::string id
	);

	void Delete(IdTable& idtable);

};