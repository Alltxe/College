program z10;
var n,i,c:integer;
A:array [1..6] of integer;
Begin
  n:=100000;
  c:=0;
  repeat
    i:=1;
    repeat
      A[i]:=n mod 10;
      n:=n div 10;
      i:=i+1;
    until i>6;
    if A[1]+A[2]+A[3] = A[4] + A[5] + A[6] then
      c:=c+1;
    write(n, ' ');
    n:=n+1;
  until n>999999;
  write(c);
end.