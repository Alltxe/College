program lab5;
const N = 10000;
type massiv=array[1..N] of integer;
var i: integer;
input,out1,out2: text;
a,b,long_arr: massiv;

function TxtToArr(inputfile:string): massiv;
var i: integer;
  input:text;
begin
  assign(input,inputfile);
  reset(input);
  i:=1;
  while not EOF(input) do
  begin
    readln(input, result[i]);
    i += 1;
  end;
  close(input);
end;

procedure ArrToTxt(a:massiv; outputfile:string);
var i,len:integer;
output:text;
begin
  assign(output,outputfile);
  rewrite(output);
  for i:=1 to N do
    writeln(output,a[i]);
  close(output);
end;


procedure comparator(a, b:massiv);
var i,len1,len2:integer;
  t:boolean;
begin

  t:=True;
    for i:=1 to len1 do
      if a[i] <> b[i] then
      begin
        t:=False;
        break;
      end;
  if t then
    writeln('Массивы одинаковы')
  else
    writeln('Массивы различаются')
end;

function counting_sort(a:massiv): massiv;
var i,j,k:integer;
  f:boolean;
begin
  for i:=1 to n do
    result[i]:=-1;
  for i:=1 to n do
   begin
    k:=0;
    for j:=1 to n do
    if a[j]<a[i] then k:=k+1;
    result[k+1]:=a[i];
   end;

  for i:=2 to n do
    if result[i]=-1 then 
      result[i]:=result[i-1];
end;

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

Begin
  Long_arr := TxtToArr('long_arr.txt');
  a := counting_sort(long_arr);
  b:=long_arr;
  MergeSort(b,1,n);
  Writeln('Массивы отсортированы');
  comparator(a,b);
  ArrToTxt(long_arr,'dasfds');
  ArrToTxt(a,'count_sorted.txt');
  ArrToTxt(b,'merge_sorted.txt');
end.