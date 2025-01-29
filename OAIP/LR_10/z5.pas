program z8;
const N = 8; M = 8;
var i,j,max:integer;
A: array of array of integer;
b: array of integer;


function single_max(arr: array of integer): Boolean;
var i,len,max_idx,max: Integer;
begin
  len:=length(arr);
  max:=-30000;
  for i:=0 to len-1 do
    if arr[i] > max then
    begin
      max:=arr[i];
      max_idx:=i;
    end;
    for i:=0 to N-1 do
      if (arr[i] = max) and (max_idx <> i) then
      begin
        result:=False;
        exit;
      end;
  result:=True;
end;

begin
  setlength(A,N);
  setlength(B,N);
  for i:=0 to N-1 do
  begin
    setlength(A[i],M);
    for j:=0 to M-1 do
    begin
      A[i,j]:=random(1,10);
      write(A[i,j]:4);
    end;
    writeln;
  end;
 for i:=0 to N-1 do
 begin
   B[i]:=-30000;
   if single_max(A[i]) then
     B[i]:=1
   else
     B[i]:=-1;
 end;
 writeln(B);
end.