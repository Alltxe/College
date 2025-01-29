program z13;
var c,n,d,s,p:integer;
Begin
  c:=0;
  s:=0;
  p:=1;
  readln(n);
  repeat
    d:=n mod 10;
    c:=c+1;
    s:=s+d;
    p:=p*d;
    n:=n div 10;
  until n < 10;
  d:=n mod 10;
    c:=c+1;
    s:=s+d;
    p:=p*d;
  writeln('кол-во цифр ', c);
  writeln('сумма ', s);
  writeln('произведение ', p);
end.