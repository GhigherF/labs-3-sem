.586
.model flat, stdcall
includelib kernel32.lib
includelib libucrt.lib
includelib "C:\Users\stude\OneDrive\Рабочий стол\Labs\labs\Labs 3 sem\KPO\KPO_19\Debug\PlusPlus.lib"

.stack 4096
outnum PROTO : DWORD
getmin PROTO : DWORD, : DWORD
getmax PROTO : DWORD, : DWORD

.code

public getmin
getmin PROC a: DWORD, b: DWORD

    push ebx
    push edx
    push ecx
    push esi
    push edi

    mov edi, 0              
    mov ecx, b              
    mov esi, a              
    mov ebx, 999999         

cycle1:
    mov eax, [esi + edi]    
    cmp eax, ebx            
    jge next                
    mov ebx, eax            

next:
    add edi, 4              
    loop cycle1             
    push ebx                
    call outnum

    pop edi
    pop esi
    pop ecx
    pop edx
    pop ebx

    ret
getmin ENDP

public getmax
getmax PROC a: DWORD, b: DWORD

    push ebx
    push edx
    push ecx
    push esi
    push edi

    mov edi, 0              
    mov ecx, b              
    mov esi, a              
    mov ebx, 0         

cycle2:
    mov eax, [esi + edi]    
    cmp eax, ebx            
    jle next                
    mov ebx, eax            

next:
    add edi, 4              
    loop cycle2             
    push ebx                
    call outnum

    pop edi
    pop esi
    pop ecx
    pop edx
    pop ebx

    ret
getmax ENDP

end