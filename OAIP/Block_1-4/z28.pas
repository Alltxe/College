program z28;
var n: integer;
str_n: string;
begin
  Readln(n);
  if (n>9) and (n<21) then
    str_n:=' korov'
  else
    if ((n-1) mod 10 = 0) then
      str_n:=' korova'
    else
      if ((n-2) mod 10 = 0) or ((n-3) mod 10 = 0) or ((n-4) mod 10 = 0) then
        str_n:=' korovy'
      else
        str_n:=' korov';
  Write('На лугу пасется ', n, str_n)
end.