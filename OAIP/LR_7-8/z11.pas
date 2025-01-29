program z11;
var len:integer;
  s,s1:string;
begin
  s:='djsahhkjhjkh';
  len:=length(s);
  if len > 10 then
    s:=s[1:6]
  else
    insert('o'*(12-len),s,len+1);
  write(s);
end.