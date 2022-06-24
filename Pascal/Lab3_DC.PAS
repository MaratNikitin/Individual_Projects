Program Pryamougolniki;
Uses crt;
Var a,b,h,n,x,s,g:real;
Begin clrscr;
Writeln ('Vvedite a, b, n:');
Readln (a,b,n);
h:=(b-a)/n; S:=0;x:=a;
Writeln('Metod levih pr`amougol`nikov.');
While x<=b do begin
S:=S+h*3*x*exp(cos(x));
x:=x+h;
end; x:=a; g:=s;
Writeln ('Integral raven ',s:9:6);s:=0;
Writeln ( 'Metod pravih pr`amougol`nikov.');
While x<=b do begin x:=x+h;
S:=S+h*3*x*exp(cos(x));
end;
Writeln ('Integral raven ',s:9:6);
Writeln ('Metod srednih pr`amougol`nikov.');
S:=0.5*(s+g);
Writeln ('Integral raven ',s:9:6);
End.
