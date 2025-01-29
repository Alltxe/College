program z10;
const N = 20;
var i,j,c,tmp:integer;
A:array [1..N] of integer;
Begin
  c:=0;
  
  for i:=1 to N do
  begin
    A[i]:=random(-10,10);
    write(A[i]:4);
  end;
  
  writeln;
  
  for i:=N downto 1 do
    if A[i]<0 then
      begin
        c += 1;
        A[i]:=0;
        for j:=i to N-1 do
        begin
            tmp:=A[j+1];
            A[j+1]:=A[j];
            A[j]:=tmp;
        end;
      end;
  
  for i:=1 to N-c do
    write(A[i]:4);

end.