program z19;
var num:integer;
begin
  Read(num);
  if (num div 1000 = num mod 10) and (num div 100 mod 10 = num mod 100 div 10) then
    write('Полиндром')
  else
    write('Не полиндром')
end.
