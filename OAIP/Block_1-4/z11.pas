program z11;
var a,b, a1, a2, a3: integer;
begin
a := random(900)+100;
writeln(a);
a1:= a mod 10;
writeln(a1);
a2 := a div 100 mod 10;
writeln(a2);
a3 := a div 10 mod 10;
writeln(a3);
b := a1*100 + a3*10 + a2;
writeln(b);
writeln(a-b)
end.