program z17;
var a,b,c:integer;
d,x1,x2: real;
begin
  Readln(a, b, c);
  d:=sqr(b)-4*a*c;
  if d > 0 then
  begin
    x1:=(-b+sqrt(d))/(2*a);
    x2:=(-b-sqrt(d))/(2*a);
    Writeln('x1 = ', x1, ' x2 = ', x2)
  end
  else
    if d = 0 then
      begin
      x1:=-b/(2*a);
      Writeln('x = ', x1);
      end
    else
      Write('Нет корней');
    
end.