var
  n: integer;

begin
  Write('Введите число: ');
  ReadLn(n);

  if (n mod 100) in [11, 12, 13, 14] then
    Writeln(n, ' лет')
  else if (n mod 10) = 1 then
    Writeln(n, ' год')
  else if (n mod 10) in [2, 3, 4] then
    Writeln(n, ' года')
  else
    Writeln(n, ' лет');
end.
