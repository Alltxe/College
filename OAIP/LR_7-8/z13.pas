program z13;
var i,len:integer;
  s:string;
  c:boolean;
begin
  c:=True;
  s:='aaabbbccc';
  len:=length(s);
  for i:=1 to len do
    if (s[i]<>'a') and (s[i]<>'b') and (s[i]<>'c') then
      c:=False;
  if c then
    write('Строка содержит только a, b, c')
  else
    write('Строка содержит не только a, b, c');
end.