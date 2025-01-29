program z15;
var pos1,i,len:integer;
  s:string;
begin
  s:='dksjahkxabcxabc';
  len:=length(s);
  for i:=1 to len do
  begin
    pos1:=pos('xabc', s);
    if pos1 = 0 then break;
    delete(s,pos1,1);
  end;
  write(s);
end.