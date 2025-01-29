program z8;
var i,n:integer;
s:real;
Begin
  readln(n);
  i:=1;
  while i <= n do
  begin
    s:=s+1/i;
    i:=i+1;
  end;
  Write(s);
end.