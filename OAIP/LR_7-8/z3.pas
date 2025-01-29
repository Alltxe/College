program z3;
var len:integer;
  s:string;
  ch1,ch2,ch3:char;
begin
  s:='lk al;skd;l hklad t';
  len:=length(s);
  ch1:=s[1];
  ch3:=s[len];
  writeln('Первый элемент: ', ch1);
  writeln('Последний элемент: ', ch3);
  if len > 3 then
  begin
    ch2:=s[(len div 2)];
    writeln('Средний элемент: ', ch2);
  end
  else
    writeln('Среднего элемента не существует');
end.