﻿program variant1_z1;
var i:integer;
    x,y:real;
begin
  y:=0;
  readln(x);
    if x<-10 then
      y:=cos(x)*power(x, 0.1*x)+x*x*x/exp(x)
    else 
      if x <-2 then
        y:=-x+exp(x)
      else
        if x<2 then
          y:=cos(2*x)*(cos((x)/ln(x))/2)
        else
          y:=(28/power(x, 1/3))*(cos(2*x)/x);
    if y = y then
      writeln(x, ': ', y)
    else 
      writeln('Точка разрыва');
end.
