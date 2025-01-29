program z6;
Uses GraphABC;
var w,h,r,x,y:integer;
Begin
  r:=10;
  w:=600;
  h:=400;
  y:=50;
  SetWindowWidth(w);
  SetWindowHeight(h);
  SetPenColor(clblack);
  for x:=50 to w - round(w/5) step round(w/10)do
  begin
    SetBrushColor(clRandom);
    Circle(x,y,r);
    y += round(h/10.5);
    r += 10;
  end;
    
end.