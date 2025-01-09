#include "FST.h"
#include <iostream>

void main()
{
    setlocale(LC_ALL, "rus");
    FST::FST fst1(
        "abcllf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1),FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l',5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2,FST::RELATION('l',1),FST::RELATION('l',6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst1))
    {
        std::cout << "цепочка: " << fst1.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst1.string << " не распознана" << std::endl;
    }

    FST::FST fst2(
        "abbbbbbbcllbbbbf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst2))
    {
        std::cout << "цепочка: " << fst2.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst2.string << " не распознана" << std::endl;
    }

    FST::FST fst3(
        "abbbclldllelldllcllelldllbbf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l',1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst3))
    {
        std::cout << "цепочка: " << fst3.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst3.string << " не распознана" << std::endl;
    }

    FST::FST fst4(
        "acllf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst4))
    {
        std::cout << "цепочка: " << fst4.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst4.string << " не распознана" << std::endl;
    }

    FST::FST fst5(
        "acllbbbbbbbbbbbf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst5))
    {
        std::cout << "цепочка: " << fst5.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst5.string << " не распознана" << std::endl;
    }

    FST::FST fst6(
        "abbbbbbbbbbbbbbbbbbbbbbbbbbbbbcllbbbbbbbbbbbf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst6))
    {
        std::cout << "цепочка: " << fst6.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst6.string << " не распознана" << std::endl;
    }

    FST::FST fst7(
        "abbbbbbbbbbbbbbbbbbbbbbbbbbbbbclldllellellellbbbbbbbbbbbf",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst7))
    {
        std::cout << "цепочка: " << fst7.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst7.string << " не распознана" << std::endl;
    }

    FST::FST fst8(
        "XXXHamster",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst8))
    {
        std::cout << "цепочка: " << fst8.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst8.string << " не распознана" << std::endl;
    }
    FST::FST fst9(
        "abbbcllellff",
        8,
        // FST::NODE(3, FST::RELATION('a', 0), FST::RELATION('b', 0), FST::RELATION('a', 1)),
        FST::NODE(1, FST::RELATION('a', 1)),
        FST::NODE(4, FST::RELATION('b', 1), FST::RELATION('c', 2), FST::RELATION('d', 3), FST::RELATION('e', 4)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(1, FST::RELATION('l', 5)),
        FST::NODE(2, FST::RELATION('l', 1), FST::RELATION('l', 6)),
        FST::NODE(2, FST::RELATION('b', 6), FST::RELATION('f', 7)),
        FST::NODE()
    );
    if (FST::execute(fst9))
    {
        std::cout << "цепочка: " << fst9.string << " распознана" << std::endl;
    }
    else
    {
        std::cout << "цепочка: " << fst9.string << " не распознана" << std::endl;
    }
}