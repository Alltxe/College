program z2v2;
const N=20;
var i:integer;
  A:array of integer;
 
function min_max(arr:array of integer): (integer,integer);
var i,min_abs,max_neg,len:integer;
begin
  min_abs:=32767;
  max_neg:=-32768;
  len:=length(arr);
  for i:=0 to len-1 do
  begin
    if abs(arr[i])<abs(min_abs) then
      min_abs:=A[i];
    if (arr[i]>max_neg) and (arr[i] <= -1) then
      max_neg:=A[i];
  end;
  result:=(min_abs, max_neg)
end;
Begin
  SetLength(A,N);
  for i:=0 to N-1 do
    A[i]:=random(-55,55);
  writeln(min_max(A));
  writeln(A);
end.