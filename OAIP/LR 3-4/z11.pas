program z11;
var i,n:integer;
s:real;
Begin
  readln(n);
  i:=n;
  s:=1;
  while i>1 do
  begin
    s:=s*i;
    i:=i-1;
  end;
  write(s)
end.