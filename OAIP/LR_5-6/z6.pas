program z6;
const N = 5;
var i:integer;
b: boolean;
A:array [1..N] of integer;
Begin
  for i:=1 to N do
    read(A[i]);

  writeln;
  
  for i:=1 to N-1 do
  begin
    if A[i] > A[i+1] then
    begin
      b:=False;
      break;
    end
    else
      b:=True;
  end;
  
  if b = True then
    write('Массив упорядочен')
  else
    write('Массив не упорядочен');
end.