program z1;
var i,l,s:integer;
text, tmp:string;
begin
  text:='jflkjs hjkjl Nikolay dajk Nikolay';
  l:=length(text);
  for i:=1 to l do
  begin
    if pos('Nikolay', text) = 0 then
      break
    else
    begin
      s:=pos('Nikolay', text);
      delete(text, s, 7);
      insert('Oleg', text, s);   
    end;
  end;
  write(text)
end.