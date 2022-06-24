program iteracii;
uses crt;
const n= 3;
var
a:array [1..n,1..n] of real;
y,x,b:array [1..n] of real;
e,s:real;
k,i,j:integer;
begin
clrscr;
write ('vvedite tochnost:E=');
readln(e);
writeln ('vvedite elementi matrici a');
for i:=1 to n do
for j:=1 to n do read (a[i,j]);
writeln ('vvedite koef-ti b[i]');
for i:=1 to n do read(b[i]);
for i:=1 to n do x[i]:=0;
repeat
for i:=1 to n do begin
s:=b[i]/a[i,i];
for j:=1 to n do begin
if i<>j  then s:=s-a[i,j]*x[j]/a[i,i];
end;
y[i]:=s;
end;
s:=0;
for k:=1 to n do begin
s:=s+abs(y[k]-x[k]);
x[k]:=y[k];
end;
until s<=e;
writeln('korni sistemi');
for i:=1 to n do
writeln ('x[',i,']=',x[i]:3:2);
end.

