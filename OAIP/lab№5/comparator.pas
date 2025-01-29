program comparator;
const N = 9898;
var i:integer;
t:boolean;
A:array [1..N] of integer;
B:array [1..N] of integer;
arr1,arr2:text;
Begin
  assign(arr1,'sorted_arr.txt');
  assign(arr2,'sorted_arr1.txt');
  reset(arr1);
  for i:=1 to N do
    readln(arr1,A[i]);
  closeFile(arr1);
  reset(arr2);
  for i:=1 to N do
  begin
    readln(arr2,B[i]);
    if A[i] <> B[i] then
    begin
      write('массивы не совпадают');
      t:=False;
      break;
    end
    else
      t:=True;
  end;
  if t then
    writeln('массивы одинаковы')
end.