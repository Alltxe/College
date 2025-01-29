Program LastNumber;
    var number, LastDigit: integer;
begin
  writeln('Введите число');
  readln (number);
  LastDigit := number mod 10;
  writeln('последняя цифра ', LastDigit);
end.