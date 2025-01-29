Program z1;
var i,n:integer; a,b,h,x,xb,s,t,E:real;
function f(x:real):real;
begin
result:=2*x**3 - 2*x**2 - 5*x + 8; 
end;
begin
write('Введите нижний предел интегрирования '); readln(a);
write('Введите верхний предел интегрирования '); readln(b);
write('Введите количество отрезков '); readln(n);
h:=(b-a)/n; s:=0; xb:=a;
for i:=1 to n do
begin x:=xb+i*h; s:=s+f(x)*h; end;
 
writeln('Интеграл равен ',s:12:10);
t:=6*x**2 - 4*x - 5;
E:=(t/2)*(h**2)*n;
writeln('Погрешность ', abs(E));
end.