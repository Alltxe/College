program z6;
var i,len:integer;
  s:string;
begin
  s:='1ajld jaslkdjaslfd sfgdh lasd';
  len:=length(s);
  i:=len;
  while i >= 3 do
  begin
    if s[3] = ' ' then
      write('space ')
    else
      write(s[3], ' ');
    i -= 3;
    delete(s, 1, 3);
  end;
end.