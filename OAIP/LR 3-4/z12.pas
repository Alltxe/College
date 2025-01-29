program z12;
var i,s,p,n:integer;
A:array [1..10] of integer;
Begin
  p:=1;
  s:=0;
  i:=1;
  repeat
    readln(n);
    if n mod 2 = 0 then
      p:=p*n
    else
      s:=s+n;
    i:=i+1
  until i=5;
  writeln('Произведение четных = ', p);
  write('Сумма нечетных = ', s)
end.