program z7;
var i,len, cplus, cminus, c0:integer;
  s:string;
begin
  s:='58394 + od - das + ds ---- +++ +0 -0-0-0-0+0';
  len:=length(s);
  for i:=1 to len do
  begin
    if s[i] = '-' then
      cminus += 1
    else if s[i] = '+' then
      cplus += 1;
  end;
  for i:=1 to len-1 do
    if ((s[i] = '+') or (s[i] = '-')) and (s[i+1] = '0') then
      c0 += 1;
  
  writeln('Количество +: ', cplus);
  writeln('Количество -: ', cminus);
  writeln('Количество + и - после коториых следует 0: ', c0);
end.