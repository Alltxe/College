program z8;
var s:string;
ch:char;
x,w:boolean;
begin
  x:=True;
  w:=True;
  s:='lk;lk walshd xkp ojxwsx';
  if pos('x', s) = 0 then
    begin
      writeln('Нет символов x');
      x:= False
    end;
  if pos('w', s) = 0 then
    begin
      writeln('Нет символов w');
      w:=False;
    end;
  if x and w then
    if pos('x', s) < pos('w', s) then
      ch:='x'
    else
      ch:='w';
  writeln('Раньше встречается символ ', ch)
end.