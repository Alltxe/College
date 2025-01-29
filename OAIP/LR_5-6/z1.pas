program z1;
const N=20;
var i,b:integer;
A: array [1..N] of integer;
Begin
  for i:=1 to N do
  begin
    read(b);
    if b > 0 then
      A[i]:=b*b
    else
      A[i]:=0;
  end;
  for i:=1 to N do
    write(A[i]:4);
end.