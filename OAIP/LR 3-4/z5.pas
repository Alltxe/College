program z5;
var i,n:integer;
Begin
  readln(n);
  i:=n;
  while i >= 1 do
   begin
    if n mod i = 0 then
      write(i,' ');
    i:=i-1;
   end;
end.
