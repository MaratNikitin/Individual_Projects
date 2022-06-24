program rungekuttametod;
uses crt;
var x,y,k1,k2,k3,k4:real;
const x0=-2; xn=-1; y0=3; h=0.1;
function f(x,y:real):real;
begin f:=X+cos(y/2);
end;begin clrscr;
x:=x0; y:=y0;
  while x<xn do begin
  k1:=h*f(x,y);
  k2:=h*f(x+h/2,y+k1/2);
  k3:=h*f(x+h/2,y+k2/2);
  k4:=h*f(x+h,y+k3);
  writeln (x:6:2,Y:6:2);
  y:=y+1/6*(k1+2*k2+2*k3+k4);
  x:=x+h; end; writeln; readkey;
end.
