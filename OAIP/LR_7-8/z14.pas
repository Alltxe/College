program z14;
var i,l,s:integer;
text, tmp:string;
begin
  text:='jflkjs hjkjl word dsal dword';
  l:=length(text);
  for i:=1 to l do
  begin
    if pos('word', text) = 0 then
      break
    else
    begin
      s:=pos('word', text);
      delete(text, s, 4);
      insert('letter', text, s);   
    end;
  end;
  write(text)
end.