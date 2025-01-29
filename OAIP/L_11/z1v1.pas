program z1v2;
uses GraphABC;
var
  H,W,x1,x2,x3,y1,y2,y3,a: integer;
begin
  w:=600;
  h:=450;
  SetWindowWidth(W);
  SetWindowHeight(H);
  SetPenColor(clblue);
  x1:=50;
  y1:=h-50;
  x2:=w-50;
  y2:=y1;
  x3:=round((x2+x1)/2);
  a:=round(x2-x1);
  y3:=round(h-sqrt(sqr(a)-sqr(a/2)));
  SetPenColor(clblue);
  MoveTo (x1, y1);
  LineTo (x2, y2);
  LineTo (x3, y3);
  LineTo (x1, y1);
end.