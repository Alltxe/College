program z12;
var c,i,j,len:integer;
  s:string;
  digits:array [1..10] of string;
begin
  for i:=0 to 9 do
    digits[i+1]:=IntToStr(i);
  s:='jdksalkj1982u43qwkj94';
  len:=length(s);
  for i:=1 to len do
    for j:=1 to 10 do
      if s[i] = digits[j] then
        c += 1;
  write('Количество цифр: ', c);
end.