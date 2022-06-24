Program z1;
Uses crt;
Var x,e,d:real;
Begin clrscr;
Writeln ('Vvedite znachenie argumenta a funkcii:');
Readln(x); e:=0.000001;
d:=(3*(x+e)*exp(cos(x+e))-3*x*exp(cos(x)))/e;
Write ('Znachenie proizvodnoy funkcii v tochke a ravno ',d:8:6);
End.