type t_chs = set of Char;
const
  lett: t_chs = ['a'..'z','A'..'Z','_'];
  num: t_chs = ['0'..'9'];
var
  str: string;
  i: byte;
  flag: boolean;
begin
  flag := true;

  Write('Введите строку: ');
  ReadLn(str);

  if not (str[1] in lett) then
    flag := false;

  for i := 2 to Length(str) do
  begin
    if not (str[i] in lett + num) then
    begin
      flag := false;
      Break;
    end;
  end;

  if flag then
    WriteLn('Строка корректна')
  else
    WriteLn('Строка некорректна');
end.