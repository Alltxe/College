program z2v1;
const N=20;
var i:integer;
  A:array of integer;
 
function max_el_idx(arr:array of integer): (integer,integer);
var i,max,len:integer;
begin
  max:=-3278;
  len:=length(arr);
  for i:=0 to len-1 do
    if arr[i]>max then
    begin
      result:=(A[i],i);
      max:=A[i];
    end;
end;
Begin
  SetLength(A,N);
  for i:=0 to N-1 do
    A[i]:=random(1,55);
  writeln(max_el_idx(A));
  writeln(A);
end.