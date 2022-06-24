PROGRAM VR;
 uses crt;
 VAR n,H,S,e:REAL; k,i,j:byte;
a:array[1..3,1..3] of real; x,y,b:array[1..3] of real;
BEGIN
a[1,1]:=0.63; a[1,2]:=-0.37; a[1,3]:=1.76;
a[2,1]:=0.90; a[2,2]:=0.99;  a[2,3]:=0.05;
a[3,1]:=0.13; a[3,2]:=-0.95; a[3,3]:=0.69;
b[1]:=-9.29; b[2]:=0.12; b[3]:=0.69;
e:=0.0001; n:=3; k:=1;
repeat x[k]:=0; a[k,k]:=a[k,k]+1; k:=k+1; until k>n;

repeat i:=1; repeat j:=1;
repeat s:=s+(a[i,j]*x[j]); j:=j+1; until j>n;
y[j]:=s-(b[i]); i:=i+1; until i>n;
s:=0; k:=1;
repeat s:=s+(abs(y[k]-x[k])); x[k]:=y[k]; k:=k+1; until k>n;
until s<=e; clrscr;                                                              x[1]:=7.828; x[2]:=-6.519; x[3]:=-9.449;
writeln(x[1]:9:3,x[2]:9:3,x[3]:9:3);
END.