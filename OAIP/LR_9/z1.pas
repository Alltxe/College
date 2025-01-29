program z1;
const N=10;
var i:integer;
  A:array of integer;

function arr_product(arr:array of integer): integer;
var len,i:integer;
begin
  result:=1;
  len:=length(arr);
  for i:=0 to len-1 do
    if A[i] mod 2 = 0 then
      result*=arr[i];
end;
Begin
  SetLength(A,N);
  for i:=0 to N-1 do
    A[i]:=random(1,5);
  writeln(arr_product(A));
  writeln(A);
end.