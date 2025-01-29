Program z15;
var
  num1, num2, num3: integer;
  count: integer;
begin
  writeln('Введите три числа:');
  readln(num1, num2, num3);

  count := 0;

  if num1 > 0 then
    count := count + 1;
  if num2 > 0 then
    count := count + 1;
  if num3 > 0 then
    count := count + 1;

  writeln('Количество положительных чисел среди введенных: ', count);
end.