.586
.MODEL FLAT, STDCALL

includelib kernel32.lib

GetStdHandle PROTO :DWORD
WriteConsoleA PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD
ExitProcess PROTO :DWORD

.CONST
STD_OUTPUT_HANDLE EQU -11

.DATA
MSG_PREFIX DB "Результат сложения = ", 0 ; Префикс сообщения
RESULT_BUFFER DB "00", 0                 ; Буфер для числа (макс. двух цифр)
OUTPUT_STRING DB "Результат сложения = 00", 0 ; Итоговая строка
BYTES_WRITTEN DD 0                           ; Количество записанных байт

DIGIT1 DD 3                                  ; Первое число
DIGIT2 DD 5                                  ; Второе число
RESULT DD 0                                  ; Переменная для результата

.CODE
IntToStr PROC
    ; Преобразует целое число из RESULT в строку RESULT_BUFFER
    MOV ESI, OFFSET RESULT_BUFFER
    ADD ESI, 1               ; Устанавливаемся на предпоследний символ
    MOV BYTE PTR [ESI + 1], 0 ; Завершающий ноль
    MOV EAX, RESULT
    MOV EBX, 10
L1:
    XOR EDX, EDX
    DIV EBX
    ADD DL, '0'
    MOV [ESI], DL
    DEC ESI
    TEST EAX, EAX
    JNZ L1
    MOV EAX, ESI
    INC EAX
    RET
IntToStr ENDP

main PROC
    ; Получение дескриптора консоли
    PUSH STD_OUTPUT_HANDLE
    CALL GetStdHandle
    CMP EAX, -1
    JE HANDLE_ERROR
    MOV EBX, EAX

    ; Сложение двух чисел
    MOV EAX, DIGIT1
    MOV ECX, DIGIT2
    ADD EAX, ECX
    MOV RESULT, EAX

    ; Преобразование результата в строку
    CALL IntToStr

    ; Копируем префикс сообщения в итоговую строку
    LEA ESI, MSG_PREFIX
    LEA EDI, OUTPUT_STRING
    MOV ECX, SIZEOF MSG_PREFIX
    REP MOVSB

    ; Копируем число в строку
    LEA ESI, RESULT_BUFFER
    MOV ECX, SIZEOF RESULT_BUFFER
    REP MOVSB

    ; Вывод строки в консоль
    PUSH 0                     ; NULL для Overlapped
    PUSH OFFSET BYTES_WRITTEN  ; Количество записанных байт
    MOV EAX, OFFSET OUTPUT_STRING
    PUSH ECX                   ; Длина строки
    PUSH EAX                   ; Итоговая строка
    PUSH EBX                   ; Дескриптор консоли
    CALL WriteConsoleA

    ; Завершение программы
    PUSH 0
    CALL ExitProcess

HANDLE_ERROR:
    PUSH 1
    CALL ExitProcess

main ENDP
END main
