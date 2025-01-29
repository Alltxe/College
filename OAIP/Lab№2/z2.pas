program z2;
var i,j,c:integer;
s1,s2:string;
t:boolean;
Begin
  readln(s1);
  readln(s2);
  for i:=1 to length(s1) do
  begin
   t:=False;
   if s1[i] = s2[1] then
    begin
      t:=True;
      for j:=1 to length(s2) do
      begin
        if s1[i+j-1] <> s2[j] then
        begin
          t:=False;
          break;
        end;
      end;
    end;
    if t then
      c += 1;
  end;
  Write('количество вхождений подстроки s2 в строку s1: ', c);
end.