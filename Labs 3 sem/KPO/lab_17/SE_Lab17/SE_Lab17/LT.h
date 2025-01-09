#pragma once
#define LEXEMA_FIXSIZE 1
#define LT_MAXSIZE 4096
#define LT_TI_NULLIDX 0xffffffff
#define LEX_SMALL 't'
#define LEX_SYMBOL 't'
#define LEX_ID 'i'
#define LEX_LITERAL 'l'
#define LEX_FN 'f'
#define LEX_ANNOUNCE 'a'
#define LEX_RETURN 'r'
#define LEX_WRITE 'w'
#define LEX_SEMICOLON ';'
#define LEX_COMMA ','
#define LEX_LEFTBRACE '{'
#define LEX_BRACELET '}'
#define LEX_LEFTHESIS '('
#define LEX_RIGHTHESIS ')'
#define LEX_MOVE 'v'
#define LEX_MAIN 'm'
#define LEX_EQUALS '='

namespace LT
{
    struct Entry
    {
        char lexema;
        int snum;
        int idxTi = LT_TI_NULLIDX;
    };

    struct LexTable
    {
        int maxsize;
        int size;
        Entry* table;
    };
    LexTable Create(int size);
    void Add(LexTable& lextable, Entry entry);
    Entry GetEntry(LexTable& lextable, int n);
    void Delete(LexTable& lextable);
};
