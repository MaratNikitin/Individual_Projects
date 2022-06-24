program met_Gausa;
uses crt;
const n=3;
var
a:array[1..3,1..3] of real;
b,x: array[1..n] of real;
k,i,j,m:integer;
c,s:real;
begin
clrscr;
writeln('vvedite elementi matrici A');
for i:=1 to n do
for j:=1 to n do read (a[i,j]);
writeln ('vvedite koef-ti b[i]');
for i:=1 to n do
read(b[i]);
for k:=1 to n-1 do begin
for i:=k+1 to n do
begin
c:=a[i,k]/a[k,k];
a[i,k]:=0;
for j:=k+1 to n do
a[i,j]:=a[i,j]-a[k,j]*c;
b[i]:=b[i]-b[k]*c;
end;
end;
x[n]:=b[n]/a[n,n];
for i:=n-1 downto 1 do begin s:=0;
for j:=i+1 to n do
s:=s+a[i,j]*x[j];
x[i]:=(b[i]-s)/a[i,i];
end;
writeln ('korni yravnenia');
for i:=1 to n do
writeln ('x[',i,']=',x[i]:5:2);
readln;
end.
