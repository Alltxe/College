Uses z1,graphABC;
Begin
     SetWindowSize(500,500);
     ClearWindow;
     x:= 100; y:= 100;
     depth:= 3; scale := 15;
     MoveTo(x, y);
       a(depth);
     OnKeyDown := KeyDown;
End.