program z30;
var x,n:integer;
begin
  Readln(x);
  if x = 100 then
    write('C')
  else
      if x>9 then
      begin
        if x div 10 < 4 then
          Write('X'*(x div 10))
        else if x div 10 = 4 then 
          Write('XL')
        else if (x div 10 > 4) and (x div 10 <> 9) then
          Write('L',('X'*((x div 10)-5)))
        else if x div 10 = 9 then
          Write('XC');
        if x mod 10< 4 then
          Write('I'*(x mod 10))
        else if x mod 10= 4 then 
          Write('IV')
        else if (x  mod 10 > 4) and (x mod 10 <> 9) then
          Write('V',('I'*((x mod 10)-5)))
        else if x mod 10 =9 then
          Write('IX');
      end
      else
        if x < 4 then
          Write('I'*x)
        else if x = 4 then 
          Write('IV')
        else if (x > 4) and (x <> 9) then
          Write('V',('I'*(x-5)))
        else if x = 9 then
          Write('IX')
        
end.