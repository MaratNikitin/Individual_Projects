Program Simpsons;
Uses crt;
Var a,b,h,n,i,s,x1,x2,x3:real;
Begin clrscr;
Writeln ('Vvesti a,b,n');
Readln(a,b,n);
h:=(b-a)/n;
s:=0; i:=2;
While i<=n do begin x2:=a+(i-1)*h; x1:=x2-h;
x3:=x2+h;
S:=S+3*x1*exp(cos(x1))+4*3*x2*exp(cos(x2))+3*x3*exp(cos(x3));
i:=i+2;
End; s:=s*h/3;
Write ('Znachenie integrala ravno ',s:9:6);
End.