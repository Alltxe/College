program counting_sort;
const n=10000;
var a,b:array[1..n] of integer;
    long_arr,sorted_arr:text;
    i,j,k,val:integer;
    f:boolean;
begin
  assign(long_arr,'long_arr.txt');
  reset(long_arr);
  for i:=1 to n do
   begin
    readln(long_arr, a[i]);
   end;
  for i:=1 to n do
    b[i]:=-1;
  for i:=1 to n do
   begin
    k:=0;
    for j:=1 to n do
    if a[j]<a[i] then k:=k+1;
    b[k+1]:=a[i];
   end;
   
  closeFile(long_arr);
  assign(sorted_arr,'sorted_arr.txt');
  rewrite(sorted_arr);
  for i:=2 to n do
    if b[i]=-1 then b[i]:=b[i-1];
    writeln('Массив отсортирован');
  for i:=1 to n do
    writeln(sorted_arr,b[i],' ');
end.