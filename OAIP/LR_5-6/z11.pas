program z11;
const
  N = 21;
var
  i, j, c, tmp: integer;
  A: array [1..N] of integer;
begin
  c := 0;

  for i := 1 to N - 1 do
  begin
    A[i] := random(-10, 10);

    if A[i] mod 2 = 0 then
      c += 1;

    write(A[i]:4);
  end;

  writeln();

  for i := 1 to N do
  begin
    if A[i] mod 2 = 0 then
    begin
      for j := N downto i + 1 do
        A[j] := A[j - 1];
      A[i + 1] := c;
      break;
    end;
  end;

  for i := 1 to N do
    write(A[i]:4);
end.
