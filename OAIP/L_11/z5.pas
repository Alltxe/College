program z5;
Uses GraphABC;
var w,h,i:integer;
Begin
  w:=600;
  h:=400;
  SetWindowWidth(w);
  SetWindowHeight(h);
  SetPenColor(clblack);
  i:=round(h/2);
  while i>10 do
  begin
    SetBrushColor(clRandom);
    Circle(round(w/2),round(h/2),i);
    i-=10;
  end;
end.