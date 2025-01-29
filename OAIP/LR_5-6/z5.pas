program z5;
const N = 10;
var i, sum1, sum2:integer;
A:array [1..N] of integer;
B:array [1..N] of integer;
Begin
  for i:=1 to N do
  begin
    A[i]:=random(-10,11);
    B[i]:=random(-10,11);
    if A[i] > 0 then
      sum1 += A[i];
    if B[i] >0 then
      sum2 += B[i];
  end;
  
  writeln(A);
  writeln(B);
  
  if sum1 > sum2 then
    begin
      for i:=1 to N do
        A[i]:=A[i]*10;
      write(A);
    end
  else
    begin
     for i:=1 to N do
        B[i]:=B[i]*10;
     write(B);
    end;
end.