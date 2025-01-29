program z7;
uses graphABC;
var i,j,w,h: integer;
switch:boolean;
begin
  w:=800;
  h:=800;
  SetWindowWidth(w);
  SetWindowHeight(h);
  SetPenColor(clblack);
  switch:=True;
  for i:=0 to w step 100 do
  begin
    for j:=0 to h step 100 do
    begin
    
      if switch then
      begin
        SetBrushColor(clblack);
        switch:=False;
      end
      else
      begin
        SetBrushColor(clwhite);
        switch:=True;
      end;
      
      rectangle(i,j,i+100,j+100)
    end;
  end;
end.