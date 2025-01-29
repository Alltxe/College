program z16;
var x, y:integer;
begin
  Readln(x);
  Readln(y);
  if (x > 0) and (y > 0) then
    Writeln('I четверть')
  else
    if (x > 0) and (y < 0) then
      Writeln('II четверть')
    else
      if (x < 0) and (y < 0) then
        Writeln('III четверть')
      else
        Writeln('IV четверть');
end.