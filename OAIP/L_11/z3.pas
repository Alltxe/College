program z3;
uses GraphABC;
var
  h,w,x1,x2,x3,x4,x5,x6,x7,y1,y2,y3,r: integer;
  A:array of Point;
  B:array of Point;
  C:array of Point;
begin
  setlength(A,3);
  setlength(B,3);
  setlength(C,3);
  w:=600;
  h:=400;
  SetWindowWidth(w);
  SetWindowHeight(h);
  SetPenColor(clblack);
  SetPenWidth(2);
  r:=25;
  y1:=h-25;
  x1:=150;
  x2:=w-150;
  Line(x1,y1,x2,y1);
  x3:=x1+75;
  x4:=x2-75;
  x5:=round(w/2);
  y2:=r*2;
  x6:=50;
  y3:=y2+r;
  x7:=w-50;
  A[0].X:=x1; A[0].Y:=y1; A[1].X:=x6; A[1].Y:=y3; A[2].X:=x4; A[2].Y:=y1;
  B[0].X:=x3; B[0].Y:=y1; B[1].X:=x5; B[1].Y:=y2; B[2].X:=x4; B[2].Y:=y1;
  C[0].X:=x3; C[0].Y:=y1; C[1].X:=x7; C[1].Y:=y3; C[2].X:=x2; C[2].Y:=y1;
  SetBrushColor(clblue);
  polygon(A);
  Circle(x6,y3,r);
  SetBrushColor(cllime);
  polygon(C);
  Circle(x7,y3,r);
  SetBrushColor(clred);
  polygon(B);
  Circle(x5,y2,r);

  
  
end.