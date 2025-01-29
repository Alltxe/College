program merge_sort;
const N = 10000;
type massiv=array[1..N] of integer;
var i: integer;
A: massiv;
long_arr,sorted_arr:text;
procedure Merge(var A: massiv; first, last: integer);
var middle, start, final , j: integer;
    mas: massiv;
begin
middle:=(first+last) div 2;
start:=first;
final:=middle+1;
for j:=first to last do
if (start <= middle) and ((final>last) or (A[start]<A[final])) then
 begin
  mas[j]:=A[start];
  start += 1;
 end
else
 begin
  mas[j]:=A[final];
  final += 1;
 end;

for j:=first to last do A[j]:=mas[j];
end;

procedure MergeSort(var A: massiv; first, last: integer);
begin
if first<last then
 begin
  MergeSort(A, first, (first+last) div 2);
  MergeSort(A, (first+last) div 2+1, last);
  Merge(A, first, last);
 end;
end;

begin
assign(long_arr,'long_arr.txt');
reset(long_arr);

for i:=1 to n do
 begin
  readln(long_arr, a[i]);
 end;
closeFile(long_arr);
MergeSort(A, 1, n);

assign(sorted_arr,'sorted_arr1.txt');
rewrite(sorted_arr);
writeln('Массив отсортирован');
for i:=1 to n do 
  writeln(sorted_arr, a[i], ' ');

end.
