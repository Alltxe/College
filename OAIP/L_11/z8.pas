program z8;
uses GraphABC;
var w,h,x,y,x1,y1,x2,y2,x3,y3:integer;
Begin
  w:=600;
  h:=400;
  SetWindowWidth(w);
  SetWindowHeight(h);
  x1:=50;
  y1:=h-50;
  x2:=round(w/2);
  y2:=25;
  x3:=w-50;
  y3:=h-50;
  for x:=x1 to x2 do
  begin
   y:=round(((x-x1)*(y2-y1))/(x2-x1))+y1;
   SetPenColor(clblack);
   SetbrushColor(clblack);
   rectangle(x,y,x+10,y+10);
   sleep(1);
   SetPenColor(clwhite);
   SetbrushColor(clwhite);
   rectangle(x-2,y-2,x+12,y+12);
  end;
  for x:=x2 to x3 do
  begin
   y:=round(((x-x2)*(y3-y2))/(x3-x2))+y2;
   SetPenColor(clblack);
   SetbrushColor(clblack);
   rectangle(x,y,x+10,y+10);
   sleep(1);
   if x < x3 then
   begin
     SetPenColor(clwhite);
     SetbrushColor(clwhite);
     rectangle(x-2,y-2,x+12,y+12);;
   end;
  end;
end.