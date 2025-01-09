#pragma once
#define IN_MAX_LEN_TEXT 1024*1024
#define IN_CODE_ENDL '|'

#define IN_CODE_TABLE {\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, '|',IN::F, IN::F,IN::F,IN::F,IN::F,\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
IN::I, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::F, IN::F, IN::F,\
IN::T/*0*/, IN::T, IN::T /*2*/, IN::T, IN::T, IN::T, IN::T/* 6*/, IN::T /*7*/, IN::T, IN::T, IN::F, IN::T, IN::T, IN::T, IN::T, IN::F,\
IN::F, IN::T, IN::T, IN::T /*C*/, IN::T /*D*/, IN::T/* E*/, IN::T, IN::T, IN::T /*H*/, IN::T /* I*/, IN::T, IN::T /*K*/, IN::T /*L*/, IN::T /*M*/, IN::T /*N*/, IN::T /*O*/,\
IN::T, IN::T, IN::T /*R*/, IN::T, IN::T/* T*/, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::F, IN::F, IN::F, IN::F, IN::F,\
IN::F, IN::T, IN::T, IN::T /*c*/, IN::T /*d*/, IN::T /*e*/, IN::T, IN::T, IN::T /*h*/,   IN::T /*i*/, IN::T, IN::T /*k*/, IN::T /*l*/, IN::T/* m*/, IN::T /*n*/, IN::T /*o*/,\
IN::T, IN::T, IN::T /*r*/, IN::T, IN::T /*t*/, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::F, IN::T,\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F, IN::F,\
IN::T, IN::T, IN::T, IN::T, IN::T /*Д*/, IN::T /*Е*/, IN::T, IN::T, IN::T,  IN::T/*К*/, IN::T /*Л*/, IN::T /*М*/, IN::T /*Н*/, IN::T /*O*/, IN::T,IN::T,\
IN::T /*Р*/ , IN::T, IN::T, /*T*/ IN::T, IN::T, IN::T, IN::T, IN::T /*Ч*/, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,\
IN::T, IN::T, IN::T, IN::T, IN::T /*Д*/, IN::T /*Е*/, IN::T, IN::T, IN::T,  IN::T/*К*/, IN::T /*Л*/, IN::T /*М*/, IN::T /*Н*/, IN::T /*O*/, IN::T,IN::T,\
IN::T /*Р*/ , IN::T, IN::T, /*T*/ IN::T, IN::T, IN::T, IN::T, IN::T /*Ч*/, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T, IN::T,\
 }  

namespace In
{
    struct IN
    {
        enum { T = 1024, F = 2048, I = 4096 };
        int size;
        int lines;
        int ignor;
        unsigned char* text;
        int code[256] = IN_CODE_TABLE;
    };
    IN getin(wchar_t infile[]);
}

