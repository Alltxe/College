program z1;
const N = 6; M = 8;
var i,j:integer;
A: array [1..N,1..M] of integer;
b: array [1..N] of integer;
begin
  for i:=1 to N do
  begin
    for j:=1 to M do
    begin
      A[i,j]:=random(1,10);
      write(A[i,j]:4);
    end;
    writeln;
  end;
 for i:=1 to N do
 begin
   if abs(A[i,1]) > 4 then
     B[i]:=A[i,1]
   else
     B[i]:=0;
 end;
 writeln(B);
end.