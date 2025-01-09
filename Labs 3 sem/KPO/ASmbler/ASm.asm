.586
.MODEL FLAT, STDCALL

includelib kernel32.lib

GetStdHandle PROTO :DWORD
WriteConsoleA PROTO :DWORD, :DWORD, :DWORD, :DWORD, :DWORD
ExitProcess PROTO :DWORD

.CONST
STD_OUTPUT_HANDLE EQU -11

.DATA
MSG_PREFIX DB "��������� �������� = ", 0 ; ������� ���������
RESULT_BUFFER DB "00", 0                 ; ����� ��� ����� (����. ���� ����)
OUTPUT_STRING DB "��������� �������� = 00", 0 ; �������� ������
BYTES_WRITTEN DD 0                           ; ���������� ���������� ����

DIGIT1 DD 3                                  ; ������ �����
DIGIT2 DD 5                                  ; ������ �����
RESULT DD 0                                  ; ���������� ��� ����������

.CODE
IntToStr PROC
    ; ����������� ����� ����� �� RESULT � ������ RESULT_BUFFER
    MOV ESI, OFFSET RESULT_BUFFER
    ADD ESI, 1               ; ��������������� �� ������������� ������
    MOV BYTE PTR [ESI + 1], 0 ; ����������� ����
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
    ; ��������� ����������� �������
    PUSH STD_OUTPUT_HANDLE
    CALL GetStdHandle
    CMP EAX, -1
    JE HANDLE_ERROR
    MOV EBX, EAX

    ; �������� ���� �����
    MOV EAX, DIGIT1
    MOV ECX, DIGIT2
    ADD EAX, ECX
    MOV RESULT, EAX

    ; �������������� ���������� � ������
    CALL IntToStr

    ; �������� ������� ��������� � �������� ������
    LEA ESI, MSG_PREFIX
    LEA EDI, OUTPUT_STRING
    MOV ECX, SIZEOF MSG_PREFIX
    REP MOVSB

    ; �������� ����� � ������
    LEA ESI, RESULT_BUFFER
    MOV ECX, SIZEOF RESULT_BUFFER
    REP MOVSB

    ; ����� ������ � �������
    PUSH 0                     ; NULL ��� Overlapped
    PUSH OFFSET BYTES_WRITTEN  ; ���������� ���������� ����
    MOV EAX, OFFSET OUTPUT_STRING
    PUSH ECX                   ; ����� ������
    PUSH EAX                   ; �������� ������
    PUSH EBX                   ; ���������� �������
    CALL WriteConsoleA

    ; ���������� ���������
    PUSH 0
    CALL ExitProcess

HANDLE_ERROR:
    PUSH 1
    CALL ExitProcess

main ENDP
END main
