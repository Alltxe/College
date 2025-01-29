program z12;
var num, d1, d2, d3, d4: integer;
begin
  readln(num);
  d1:=num div 1000;
  d2:=num div 100 mod 10;
  d3:=num mod 100 div 10;
  d4:=num mod 10;
  writeln('сумма: ', d1+d2+d3+d4);
  write('произведение : ', d1*d2*d3*d4);
end.