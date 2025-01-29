program z4;
const N = 8; M = 8;
var i,j,avg:integer;
c:boolean;
A: array [1..N,1..M] of integer;
b: array [1..N] of integer;
begin
  c:=False;
  for i:=1 to N do
    B[i]:=30000;
  for i:=1 to N do
  begin
    for j:=1 to M do
    begin
      A[i,j]:=random(10,100);
      write(A[i,j]:4);
    end;
    writeln;
  end;
  for i:=1 to N do
  begin
    for j:=1 to M do
      if A[i,j] < B[i] then
        B[i]:= A[i,j];
    avg += B[i];
  end;
  avg:=round(avg/N);
  writeln(B);
  for i:=1 to N do
    if B[i]=avg then
    begin
      c:=True;
      writeln('одномерный массив содержит своё среднее арифметическее');
      break;
    end;
  if c=False then
    writeln('одномерный массив не содержит своё среднее арифметическее');
end.