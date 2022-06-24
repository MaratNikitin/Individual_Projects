Program trapecii;
Uses crt;
Var a,b,h,s,x:real;n,i:integer;
Begin clrscr;
Writeln('Vvesti a,b,n');
Readln(a,b,n); h:=(b-a)/n; s:=0; x:=a;
For i:=1 to n do begin
s:=s+h/2*(3*x*exp(cos(x))+3*(x+h)*exp(cos(x+h)));
x:=x+h
end;
Writeln ('Znachenie integrala ravno ',s:9:6);
end.
