program z29;
var M,N,x,y: integer;
begin
  Write('Размеры таблицы: ');
  Readln(M,N);
  Write('Координаты клетки: ');
  Readln(x,y);
  if (x=1) and (y=1) then
    Write('(',x+1, ';', y,'),(',x,';',y+1,')')
  else
    if (x=1) and (y=N) then
      Write('(',x+1, ';', y,'),(',x,';',y-1,')')
    else
      if (x=M) and (y=1) then
        Write('(',x-1, ';', y,'),(',x,';',y+1,')')
      else
        if (x=M) and (y=N) then
          Write('(',x-1, ';', y,'),(',x,';',y-1,')')
        else
          if x=1 then
            Write('(',x+1, ';', y,'),(',x,';',y+1,'),(',x,';',y-1,')')
          else
            if x=M then
              Write('(',x-1, ';', y,'),(',x,';',y+1,'),(',x,';',y-1,')')
            else
              if y=1 then
                Write('(',x+1, ';', y,'),(',x,';',y+1,'),(',x-1,';',y,')')
              else
                if y=N then
                  Write('(',x+1, ';', y,'),(',x,';',y-1,'),(',x-1,';',y,')')
                else
                  Write('(',x+1, ';', y,'),(',x,';',y+1,'),(',x-1,';',y,'),(',x,';',y-1,')');
            
end.
