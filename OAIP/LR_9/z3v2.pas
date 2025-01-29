program z3v2;
const N=20;
var i:integer;
  A:array of integer;
 
function last_neg_pos(arr:array of integer): integer;
var i,a,len:integer;
begin
  len:=length(arr);
  for i:=len-1 downto 0 do
    if arr[i] < 0 then
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
    A[i]:=random(-55,55);
  writeln(last_neg_pos(A)+1);
  writeln(A);
end.