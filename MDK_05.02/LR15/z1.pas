var i := 2;
 i_ptr: ^integer;
begin
  i_ptr:=@i;
  writeln(i_ptr^);
end.