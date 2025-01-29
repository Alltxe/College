Unit z1;
Uses GraphABC;

Var
  x,y, depth, scale: Integer;
   

 
{В PascalABC нет функции LineRel - искусственно реализуем ее через LineTo}
Procedure LineRel(dx, dy : Integer);
Begin
     LineTo(PenX+dx, PenY+dy)
End;
 
Procedure a(i: Integer); forward;
Procedure b(i: Integer); forward;
Procedure c(i: Integer); forward;
Procedure d(i: Integer); forward;
 
Procedure a(i: Integer); // параметризация
Begin
     If i > 0 Then // базовый случай - ничего не происходит если i < 0
     Begin
          d(i - 1);
          LineRel( + scale, 0);
              a(i - 1); //декомпозиция
              LineRel(0, scale);
              a(i - 1); //декомпозиця
              LineRel(-scale, 0);
              c(i - 1) //декомпозиця
     End
End;
 
Procedure b(i: integer);
Begin
     If i > 0 Then
     Begin
          c(i - 1); //декомпозиця
              LineRel(-scale, 0);
              b(i - 1); //декомпозиця
              LineRel(0, -scale);
              b(i - 1); //декомпозиця
              LineRel(scale, 0);
              d(i - 1) //декомпозиця
     End
End;
 
Procedure c(i: integer);
Begin
     If i > 0 Then
     Begin
          b(i - 1); //декомпозиця
          LineRel(0, -scale);
              c(i - 1); //декомпозиця
              LineRel(-scale, 0);
              c(i - 1); //декомпозиця
              LineRel(0, scale);
              a(i - 1) //декомпозиця
     End
End;
 
Procedure d(i: integer);
Begin
     If i > 0 Then
     Begin
          a(i - 1);
              LineRel(0, scale);
              d(i - 1);
              LineRel(scale, 0);
              d(i - 1);
              LineRel(0, -scale);
              b(i - 1)
     End
End;

Procedure KeyDown(Key:integer);
begin
  case Key of
  VK_Left:  begin
    clearWindow;
    x -= 10;
    MoveTo(x,y);
    a(depth)
  end;
  VK_Right:  begin
    clearWindow;
    x += 10;
    MoveTo(x,y);
    a(depth)
  end;
  VK_Up:  begin
    clearWindow;
    y -= 10;
    MoveTo(x,y);
    a(depth)
  end;
  VK_Down:  begin
    clearWindow;
    y += 10;
    MoveTo(x,y);
    a(depth)
  end;
  VK_W: begin
    clearWindow;
    MoveTo(x,y);
    depth += 1;
    a(depth);
   end;
  VK_S: begin
    clearWindow;
    MoveTo(x,y);
    depth -= 1;
    a(depth);
   end;
  VK_D: begin
    clearWindow;
    MoveTo(x,y);
    scale -= 1;
    a(depth);
   end;
  VK_A: begin
    clearWindow;
    MoveTo(x,y);
    scale += 1;
    a(depth);
   end;
   
  end; 
end;
end.