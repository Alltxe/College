program z21;
var n1,n2,n3: integer;
begin
  Readln(n1, n2, n3);
  if ((n1 mod 2 = 0) or (n2 mod 2 = 0) or (n3 mod 2 = 0)) and ((n1 mod 2 = 1) or (n2 mod 2 = 1) or (n3 mod 2 = 1)) then
    Write('Да')
  else
    Write('Нет')
end.