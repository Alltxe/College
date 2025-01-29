program z6;
var a,b,c: integer;
pl_tr,p,s:real;
begin
  a:= random(50);
  writeln(a);
  b:=random(50);
  writeln(b);
  c:=random(50);
  writeln(c);
  p:=(a+b+c)/2;
  s:=(sqrt(p*(p-a)*(p-b)*(p-c)));
  writeln(s);
end.
