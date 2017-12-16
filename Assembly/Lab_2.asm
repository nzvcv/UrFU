%include "io.inc"

%define size 1024
%define null 0x00

section .bss
    string        resb size
    position      resb size
    length        resb size
    quantity      resb size
    result_string resb size

section .text
    global CMAIN

CMAIN:
    mov EBP, ESP ; for correct debugging
    
    GET_STRING string, size
    GET_DEC 1, position
    GET_DEC 1, length
    GET_DEC 1, quantity
    
    mov ESI, string
    mov EDI, result_string

    mov ebx, 0
    mov eax, 0
    
    len:                
        lodsb
        inc EBX
        cmp EAX, 0
        jne len
    
    mov EAX, EBX
    sub EAX, 1
    
    mov ESI, string 
    xor EBX, EBX
 
    mov ECX, [position]
    
    copy:
        mov DH, [ESI]
        mov [EDI], DH
        inc ESI
        inc EDI
        loop copy
        mov ECX, [length]
        
    mainloop:
        mov DH, [ESI]
        mov [EDI], DH
        inc ESI
        inc EDI
        loop mainloop
        
        inc BL
        cmp BL, [position]
        jne othermetka
        xor ECX, ECX

   
    mov ECX, EAX    
    sub ECX, [length]
    sub ECX, [position]
    newothermetka:
        mov DH, [ESI]
        mov [EDI], DH
        inc ESI
        inc EDI
        loop newothermetka
     
    PRINT_STRING result_string
      
    xor EAX, EAX
    ret
    
    othermetka:
        mov ECX, [length]
        sub ESI, [length]
        jmp mainloop