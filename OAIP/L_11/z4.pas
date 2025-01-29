program z4;
Uses GraphABC;
var w,h,i,r,y:integer;
Begin
  r:=10;
  w:=600;
  h:=400;
  y:=100;
  SetWindowWidth(w);
  SetWindowHeight(h);
  SetPenColor(clblack);
  for i:=0 to w step 30 do
  begin
    SetBrushColor(clRandom);
    Circle(i,y,r)
  end;
end.