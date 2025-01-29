program z5;
var i,len:integer;
  s:string;
  last_char:char;
begin
  s:='jlkajgd askgdlk aljdg';
  len:=length(s);
  last_char:=s[len];
  for i:=1 to len-1 do
  begin
    
    if s[i] = last_char then
      write(i,' ');
    
  end;
end.