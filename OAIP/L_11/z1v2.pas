program z1v1;
uses GraphABC;
var
  h,w,a,x1,x2,x3,x4,y1,y2,y3,y4: integer;
begin
  w:=600;
  h:=600;
  SetWindowWidth(W);
  SetWindowHeight(H);
  SetPenColor(clblue);
  a:=round((min(h,w)-50)*0.9);
  x1:=50;
  y1:=50;
  x2:=50;
  y2:=y1+a;
  x3:=x1+a;
  y3:=y1+a;
  x4:=x1+a;
  y4:=50;
  SetPenColor(clblue);
  MoveTo (x1, y1);
  LineTo (x2, y2);
  LineTo (x3, y3);
  LineTo (x4, y4);
  LineTo (x1 , y1);
end.