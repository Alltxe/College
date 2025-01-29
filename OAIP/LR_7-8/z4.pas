program z4;
var i,len:integer;
  s:string;
begin
  s:='ll45f jhjh';
  len:=length(s);
  if len >= 6 then
    begin
      writeln('Первые 3 символа: ', s[1],s[2],s[3]);
      writeln('Последние 3 символа: ', s[len-2],s[len-1],s[len]);
    end
  else
    for i:=1 to len do
      write(s[1]);
end.
