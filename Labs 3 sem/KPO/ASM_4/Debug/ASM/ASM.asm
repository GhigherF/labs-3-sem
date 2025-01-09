.MODEL FLAT,STDCALL
includelib kernel32.lib
includelib user32.lib
ExitProcess PROTO :DWORD
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD
wsprintfA PROTO C :VARARG
.STACK 4096

.DATA
TASK0 DWORD 100
TASK1 SDWORD 255
OP DB "Значения переменных", 0
msgBuffer DB 256 DUP(0)
formatString DB"TASK0: %d, TASK1 : %d", 0

.CODE
main PROC
START:

INVOKE wsprintfA, addr msgBuffer, addr formatString, TASK0, TASK1
INVOKE MessageBoxA, 0, addr msgBuffer, addr OP, 0
INVOKE ExitProcess, 0
main ENDP
end main
