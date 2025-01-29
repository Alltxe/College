program z7;
var x,y,h:real;
Begin
  x:=-5;
  h:=0.5;
  while x<=5 do
  begin
    write(x,'; ');
    y:=3*(x*x)- exp(ln(2)*x);
    x:=x+h;
    Writeln(y);
  end;
end.