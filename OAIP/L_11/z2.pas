program z2;
uses GraphABC;
var
  h,w,a,x1,x2,x3,x4,y1,y2,y3,y4,cx1,cx2,cy1,cy2,r: integer;
begin
  w:=800;
  h:=300;
  SetWindowWidth(W);
  SetWindowHeight(H);
  SetPenColor(clblack);
  setpenwidth(2);
  r:=round(min(w,h)*0.15);
  x1:=r*4;
  x2:=w-r*4;
  x3:=round(w/2);
  x4:=x3;
  y1:=round(h/2);
  y2:=y1;
  y3:=50;
  y4:=h-50;
  MoveTo(x1,y1);
  LineTo(x2,y2);
  LineTo(x3,y3);
  LineTo(x1,y1);
  FloodFill(x3,y3+10,clblue);
  LineTo(x4,y4);
  LineTo(x2,y2);
  FloodFill(x4,y4-10,cllime);
  cx1:=x1-r;
  cx2:=x2+r;
  cy1:=y1;
  cy2:=y2;
  Circle(cx1,cy1,r);
  FloodFill(cx1,cy2,clred);
  Circle(cx2,cy2,r);
  FloodFill(cx2,cy2,clyellow);
  
end.