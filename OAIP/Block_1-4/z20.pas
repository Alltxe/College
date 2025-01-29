program z20;
var x1,x2,y1,y2: integer;
begin
  Write('Первая точка: ');
  Readln(x1, y1);
  Write('Вторая точка: ');
  Readln(x2, y2);
  if (x1>0) and (x2>0) or (x1<0) and(x2<0) and (y1>0) and (y2>0) or (y1<0) and (y2<0) then
    Write('Точки лежат в одной четверти')
  else
    Write('Точки не лежат в одной четверти');
  
end.