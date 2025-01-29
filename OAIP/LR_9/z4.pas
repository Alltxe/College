program z4;
const N = 5;
var i,j,sum1,sum2:integer;
A,B:array [1..N] of integer;
begin
  for i:=1 to N do
  begin
      A[i]:=random(-10,10);
      B[i]:=random(-10,10);
      sum1 += A[i];
      sum2 += B[i];
  end;
  
  writeln(A);
  writeln(B);
  writeln(sum1, ' ', sum2);
  
  if sum1 < sum2 then
    for i:=1 to N do
      A[i]:= A[i]*10
    else
      for i:=1 to N do
        B[i]:= B[i]*10;
      
  writeln(A);
  writeln(B);
end.