program z17;
var i,n,r:integer;
Begin
  readln(n);
  i:=1;
  r:=1;
  repeat
    i:=i+1;
    r:=r*2;
  until i>n+1;
  write(r)
end.