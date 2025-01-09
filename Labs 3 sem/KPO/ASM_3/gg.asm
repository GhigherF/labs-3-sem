.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib

ExitProcess PROTO :DWORD
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD
wsprintfA PROTO C :VARARG

.STACK 4096

.DATA
FMT DB "%d", 0
MB_OK EQU 0
BUF DB 256 DUP(0)
STR_TITLE DB "Результат операции", 0

myBytes BYTE 10h, 20h, 30h, 40h
myWords WORD 8Ah, 3Bh, 44h, 5Fh, 99h
myDoubles DWORD 1, 2, 3, 4, 5, 6
myPointer DWORD myDoubles
myTest DWORD 1, 4, 2, 0, 5

.CODE

main PROC
START:

    MOV ESI, 0
    MOV EAX, 0  
    MOV EBX, 0  
    MOV ECX, 6  

TASK1:
    MOV EBX, myDoubles[ESI] 
    ADD EAX, EBX            
    ADD ESI, 4              
    LOOP TASK1              


    MOV EAX, 0  
    MOV EBX, 0  
    MOV ECX, 5  
    MOV ESI, 0  

TASK2:
    MOV EAX, myTest[ESI] 
    CMP EAX, 0         
    JE EQUALS          
    ADD ESI, 4         
    LOOP TASK2         

    MOV EBX, 0

EQUALS:
    MOV EBX, 1         


    PUSH -1
    CALL ExitProcess

main ENDP
end main
