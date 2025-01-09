.MODEL FLAT, STDCALL
includelib kernel32.lib

ExitProcess PROTO:DWORD
MessageBoxA PROTO : DWORD,:DWORD,:DWORD,:DWORD

.STACK 4096

.CONST

.DATA
MESSAGE		DB "Õףי",0


.CODE
	
main PROC
START :
		PUSH  OFFSET MESSAGE
		CALL MessageBoxA

	push 69
	call ExitProcess
main ENDP

end main