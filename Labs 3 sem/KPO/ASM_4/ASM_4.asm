.FLAT,STDCALL
includelib kernel32.lib
includelib user32.lib
ExitProcess PROTO :DWORD
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD
wsprintfA PROTO C :VARARG
.STACK 4096

.DATA
DWORD TASK0 100
SDWORD TASK1 255

.CODE
main PROC
START:

main ENDP
end main
