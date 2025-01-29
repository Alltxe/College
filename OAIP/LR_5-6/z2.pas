program z2;
const N=20;
var i, b, even_count, odd_prod, sum:integer;
A:array [1..N] of integer;
Begin
  even_count:=0;
  odd_prod:=1;
  sum:=0;
  for i:=1 to N do
  begin
    A[i]:=random(-22,94);
    if (A[i] mod 2 = 0) and (i mod 2 = 1) then
      even_count += 1;
    if A[i] mod 2 = 1 then
      odd_prod *= A[i];
    write(A[i]:4);
  end;
  writeln;
  write('Введите промежуток через пробел: ');
  readln(i, b);
  for i:=i to b do
    sum += A[i];
  writeln('Кол-во четных на нечетных местах ', even_count);
  writeln('Произведение нечетных: ', odd_prod);
  writeln('Сумма элементов принадлежащих заданному промежутку: ', sum)
end.