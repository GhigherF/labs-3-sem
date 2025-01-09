.586
.model flat, stdcall
includelib kernel32.lib
includelib libucrt.lib
includelib "C:\Users\stude\OneDrive\Рабочий стол\Labs\labs\Labs 3 sem\KPO\KPO_19\Debug\PlusPlus.lib"

ExitProcess PROTO :DWORD
outnum PROTO: DWORD

getmin PROTO:DWORD,:DWORD
getmax PROTO:DWORD,:DWORD

.stack 4096
.data 
    arr dword 10, 15, 16, 23, 45, 67, 11, 3, 7, 6

.code
MAIN PROC              
    push 10
    push OFFSET arr
    call getmin
                  
    push 10
    push OFFSET arr
    call getmax

    push 0                
    call ExitProcess      
MAIN ENDP
end MAIN
