program z2;
var i,j: integer;
begin
  for i:=1 to 100 do
  begin
    write(i*i:6);
    if i mod 10 = 0 then
      writeln;
  end;
end.