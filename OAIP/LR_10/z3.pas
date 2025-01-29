program z3;
const N = 8; M = 6;
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
   for j:=1 to M-1 do
   if A[i,j] + A[i,j+1] = 7 then
   begin
     B[i]:=1;
     break;
   end
   else
     B[i]:=-1;
 end;
 writeln(B);
end.