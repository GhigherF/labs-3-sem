#pragma once
namespace FST
{
    struct RELATION
    {
        char symbol;
        short nnode;
        RELATION(
            char c = 0x00,
            short ns = -1
        );
    };

    struct NODE
    {
        short n_relation;
        RELATION* relations;
        NODE();
        NODE(
            short n,
            RELATION rel, ...
        );
    };

    struct FST
    {
        string string;
        short position;
        short nstates;
        NODE* nodes;
        short* rstates;
        FST(
            const char* s,
            short ns,
            NODE n, ...
        );
    };

    bool execute(FST& fst);
    bool step(FST& fst, short*& rstates);
}