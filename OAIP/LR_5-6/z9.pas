program z9;
const N = 20;
var i, j, c, tmp, min, min_idx:integer;
b: boolean;
A:array [1..N] of integer;
Begin
  b:=False;
  min:= 10;
  for i:=1 to N do
  begin
    A[i]:=random(-10,10);
    write(A[i]:4);
    
    if A[i] < min then
    begin
      min:=A[i];
      min_idx:=i;
    end;
  end;
  
  writeln;
  writeln(min_idx, ' ', min );
  
  for i:=1 to N do
  begin
    if (A[i] > 0) and (b = False) then
    begin
      b:=True;
      c:=i;
      A[i]:=0;
      for j:=i to N-1 do
      begin
        tmp:=A[j+1];
        A[j+1]:=0;
        A[j]:=tmp;
      end;
    end;
  end;
  
  if min_idx > c then
    min_idx -= 1;
  
  if min_idx = N then
    A[min_idx]:=0
  else
    begin
      a[min_idx]:=0;
      for i:=min_idx to N-1 do
      begin
        tmp:=A[i+1];
        A[i+1]:=A[i];
        A[i]:=tmp;
      end;
    end;

  for i:=1 to N-2 do
    write(A[i]:4);
end.