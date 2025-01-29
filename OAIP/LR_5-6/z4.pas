program z4;
const N = 30;
var i,j:integer;
A:array [1..N] of integer;
B:array [1..N] of integer;
Begin
  j:=1;
  for i:=1 to N do
  begin
    B[i]:= -999;
    A[i]:=random(-99, 68);
    write(A[i]:4);
    
    if A[i] mod 2 = 0 then
    begin
      B[j]:=A[i];
      j += 1;
    end;
  end;
  
  writeln;
  for i:=1 to N do
    if B[i] <> -999 then
      write(B[i]:4);
end.