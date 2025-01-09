.MODEL FLAT, STDCALL
includelib kernel32.lib
includelib user32.lib 

ExitProcess PROTO :DWORD
MessageBoxA PROTO :DWORD, :DWORD, :DWORD, :DWORD
wsprintfA PROTO C :VARARG 

.STACK 4096

.CONST

.DATA
FMT DB "result = %d", 0 
BUF DB 256 DUP(0) 
DIGIT1 DD 5
DIGIT2 DD 4
MB_OK EQU 0
STR_TITLE DB "Результат операции", 0 ; Заголовок окна

.CODE

main PROC
START:


    MOV EAX, DIGIT1
    MOV EBX, DIGIT2
    ADD EAX, EBX

    
    PUSH EAX          
    PUSH OFFSET FMT   
    PUSH OFFSET BUF   
    CALL wsprintfA    
    ADD ESP, 12       

  
    PUSH MB_OK
    PUSH OFFSET STR_TITLE 
    PUSH OFFSET BUF       
    PUSH 0
    CALL MessageBoxA

    ; Завершаем процесс
    PUSH 0
    CALL ExitProcess
main ENDP

END main
