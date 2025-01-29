program z9;
var i,len1,len2:integer;
  s1,s2:string;
begin
  s1:='d;j';
  s2:='e';
  len1:=length(s1);
  len2:=length(s2);
  if len1 = len2 then
    write(s1)
  else
    if len1 > len2 then
      writeln(s1*(len1-len2))
    else
      writeln(s2*(len2-len1));
end.