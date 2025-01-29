program z3;
const N = 20;
var i, max, max_ind, min, min_ind, last5:integer;
A:array [1..N] of integer;
Begin
  max:=-52;
  min:=65;
  for i:=1 to N do
  begin
    A[i]:=random(-52, 66);
    
    if A[i] > max then
    begin
      max:=A[i];
      max_ind:=i;
    end;
    
    if (A[i] < min) and (A[i]>0) then
    begin
      min:=A[i];
      min_ind:=i
    end;
    
    if A[i] mod 5 = 0 then
      last5:=i;
    
    write(A[i]:4)
  end;
  
  writeln;
  writeln('Наибольший элемент: ', max, '; его номер: ',max_ind);
  writeln('Наименьший положительный элемент: ', min, '; его номер: ', min_ind);
  writeln('Номер последнего элемента кратного 5-и: ', last5);
end.