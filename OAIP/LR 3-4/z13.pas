program z13;
var i: integer;
r:real;
begin
  i:=1;
  r:=0;
  repeat
    r:=r+3*i;
    write(3*i:4);
    i:=i+2;
  until i > 19;
  writeln;
  write(r/10)
end.