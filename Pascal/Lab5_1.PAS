program priblijenie;
uses crt;
const n= 3;
var
a:array [1..n,1..n] of real;
x,y,b:array [1..n] of real;
e,s:real;
k,i,j:integer;
begin
clrscr;
write ('vvedite tochnost:E=');
readln(e);
writeln ('vvedite elementi matrici a');
for i:=1 to n do
for j:=1 to n do read(a[i,j]);
writeln ('vvedite koef-ti b[i]');
for i:=1 to n do read(b[i]);
for k:=1 to n do
begin
x[k]:=0;
a[k,k]:=a[k,k]+1;
end;
repeat
for i:=1 to n do
begin
s:=0;
for j:=1 to n do begin
s:=s+a[i,j]*x[j];
end;
y[i]:=s-b[i];
end;
s:=0;
for k:=1 to n do begin
s:=s+abs(y[k]-x[k]);
x[k]:=y[k];
end;
until s<e;
writeln('korni yravnenia');
for i:=1 to n do
writeln('x[',i,']=',x[i]:3:2);
end.
