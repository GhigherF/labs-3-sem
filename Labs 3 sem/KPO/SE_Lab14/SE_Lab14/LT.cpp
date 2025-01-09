//include "stdafx.h"
#include "LT.h"
#include "Error.h"
#include <iostream>

using namespace std;

namespace LT
{
    LexTable Create(int size)
    {
        LexTable lextable;
        if (size > 0)
        {
            lextable.maxsize = size;
            lextable.size = 0;
            lextable.table = new Entry[size];
            return lextable;
        }
        ERROR_THROW(113);
    }

    void Add(LexTable& lextable, Entry entry)
    {
        if (lextable.size < lextable.maxsize) {
            lextable.table[lextable.size] = entry;
            lextable.size++;
        }
        else {
            ERROR_THROW(114);
        }
    }

    Entry GetEntry(LexTable& lextable, int n)
    {
        if (n >= 0 && n < lextable.size) {
            return lextable.table[n];
        }
        else {
            cout << "Invalid:" << endl;
            Entry invalid;
            invalid.lexema;
            invalid.sn = -1;
            invalid.idxTI = LT_TI_NULLIDX;
            return invalid;
        }
    }

    void Delete(LexTable& lextable)
    {
        delete[] lextable.table;
        lextable.maxsize = 0;
        lextable.size = 0;
    }
}