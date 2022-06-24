Program lb2a;
Uses crt;
Var a,b,c,da,db,dc,n,m,p,q,z,dz,NG,VG:real;
Begin clrscr;
a:=0.0976; b:=2.371; c:=1.15874;
da:=0.00005; db:=0.0005; dc:=0.000005;
Writeln('a= ',a:6:4,';', ' da= ',da:7:5);
NG:=a-da; VG:=a+da;
Writeln('NG(a)= ',NG:7:5,';','VG(a)= ',VG:7:5);
Writeln;
Writeln('b= ',b:5:3,';', ' db= ',db:6:4);
NG:=b-db; VG:=b+db;
Writeln('NG(b)= ',NG:6:4,';','VG(b)= ',VG:6:4);
Writeln;
Writeln('c= ',c:7:5,';', ' dc= ',dc:8:6);
NG:=c-dc; VG:=c+dc;
Writeln('NG(c)= ',NG:8:6,';','VG(c)= ',VG:8:6);
Writeln;
n:=a*dc+c*da; m:=a*c;
Write ('a*c= ',m:7:5,';');
Writeln (' d(a*c)= ',n:9:7);
NG:=m-n; VG:=m+n;
Writeln('NG(ac)= ',NG:9:7,';','VG(ac)= ',VG:9:7);
Writeln;
m:=m+b; n:=n+db;
Write ('a*c+b= ',m:6:4,';');
Writeln(' d(a*c+b)= ',n:8:6);
NG:=m-n; VG:=m+n;
Writeln('NG(a*c+b)= ',NG:8:6,';','VG(a*c+b)= ',
VG:8:6); Writeln;
p:=b-c; q:=db+dc;
Write('b-c= ',p:5:3,';');
Writeln (' d(b-c)= ',q:8:6);
NG:=p-q; VG:=p+q;
Writeln ('NG(b-c)= ',NG:8:6,';','VG(b-c)= ',
VG:8:6); Writeln;
p:=sqrt(p); q:=q/(2*sqrt(b-c));
Write ('sqrt(b-c)= ',p:6:4,';');
Writeln(' d(sqrt(b-c))= ',q:8:6);
NG:=p-q; VG:=p+q;
Writeln('NG(sqrt(b-c)=',NG:8:6,';',
'VG(sqrt(b-c)= ',VG:8:6); Writeln;
z:=m/p; dz:=(p*n-m*q)/(b-c);
Write('z= ',z:6:4,';');
Writeln(' dz= ',dz:8:6);
NG:=z-dz; VG:=z+dz;
Writeln('NG(z)=',NG:8:6,';',
'VG(z)= ',VG:8:6);
END.
