program ayler;
uses crt;
label m;
var x,y,x0,y0,h,xn:real;
function f(x:real):real;
begin f:=x+cos(y/2);end;
begin clrscr; write('x0=');
  readln(x0); write('xn=');
  readln(xn); write('y0=');
  readln(y0); write('h=');
  readln(h); x:=x0; y:=y0;
  m:y:=y+h*f(x); x:=x+h;
  writeln(x:6:2,' ':6, y:6:2);
  if x<xn then goto m; readkey;
end.
