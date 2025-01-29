program z6;
var i,n,c:integer;
Begin
  readln(n);
  c:=0;
  for i:=1 to n do
    if n mod i = 0 then
      c:=c+1;
  write(c)
end.