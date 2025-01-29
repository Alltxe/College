program z5;
const N=10;
var i,j,c:integer;
  A: array of integer;
  B: array of integer;

function first_mod5(arr:array of integer): integer;
var len,i,c:integer;
Begin
  len:=length(arr);
  for i:=0 to len-1 do
    begin
      if arr[i] mod 5 = 0 then
      begin
        result:=i;
        break;
      end;
    end;
end;
  
function max_el_idx(arr:array of integer): integer;
var i,max,len:integer;
begin
  max:=-3278;
  len:=length(arr);
  for i:=0 to len-1 do
      if arr[i]>max then
      begin
        result:=i;
        max:=arr[i];
      end;
end;
Begin
  setlength(A,N);
  setlength(B,N);
  for i:=0 to N-1 do
    begin
      A[i]:=random(-10,10);
      B[i]:=random(-10,10);
     end;
    writeln(A);
    writeln(B);
  if first_mod5(A) < first_mod5(B) then
    begin
      A[max_el_idx(A)]:=0;
      for i:=0 to N-1 do
        B[i]:=B[i]*2;
    end
  else
    begin
      B[max_el_idx(A)]:=0;
      for i:=0 to N-1 do
      A[i]:=A[i]*2;
    end; 
  writeln(first_mod5(A):4, first_mod5(B):4);
  writeln(A);
  writeln(B);
end.