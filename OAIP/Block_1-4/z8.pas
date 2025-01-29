Program Zad8;
var chzch, trexznch: integer;
begin
  writeln ('введите 3-х значное число');
  writeln();
  readln (trexznch);
  trexznch := trexznch div 100 mod 10;
  writeln();
  writeln('первая цифра числа ', trexznch);
  writeln();
  begin 
    writeln ('введите 4-х значное число');
    writeln();
  readln (chzch);
  chzch := chzch div 1000 mod 100;
  writeln();
  writeln('первая цифра числа ', chzch);
  end;
end.