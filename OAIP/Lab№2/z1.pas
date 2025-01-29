program z1;
const N = 10;
var i,j:integer;
A:array [1..N] of integer;
Begin
  for i:=1 to N do
    A[i]:=random(1,10);
  writeln(A);
  for i:=1 to N do
  begin
    for j:=1 to N do
    begin
      if (A[i]*A[j]<A[j] + A[i]) and (i <> j) then
      begin
        writeln(A[i],';',A[j]);
        break;
      end;
    end;
  end;
end.