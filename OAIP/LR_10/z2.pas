program z2;
const N = 8; M = 6;
var i,j:integer;
A: array [1..N,1..M] of integer;
b: array [1..N] of integer;
begin
  for i:=1 to N do
  begin
    for j:=1 to M do
    begin
      A[i,j]:=random(-5,20);
      write(A[i,j]:4);
    end;
    writeln;
  end;
 for i:=1 to N do
 begin
   for j:=1 to M do
   begin
     if A[i,j] >= 0 then
       B[i]:=1
     else
     begin
       B[i]:=-1;
       break;
     end;
   end;
 end;
 writeln(B);
end.