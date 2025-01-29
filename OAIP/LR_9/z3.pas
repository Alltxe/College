program z3;
const N=20;
var i:integer;
  A:array of integer;
 
function first_positive_pos(arr:array of integer): integer;
var i,a,len:integer;
begin
  len:=length(arr);
  for i:=0 to len-1 do
    if arr[i] > 0 then
    begin
      result:=i;
      break;
    end
    else
      result:=0
end;
Begin
  SetLength(A,N);
  for i:=0 to N-1 do
    A[i]:=random(-55,20);
  writeln(first_positive_pos(A)+1);
  writeln(A);
end.