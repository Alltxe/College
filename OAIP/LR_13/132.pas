type
  form = record
    fname: string;
    DOB: string;
    course: 1..5;
  end;

var
  students: array of form;
  i: integer;

begin
  
  Write('Введите количество студентов: ');
  ReadLn(i);
  
  SetLength(students, i);
  
  for i := 0 to i do
  begin
    writeln;
    Write('Введите ФИО студента ', i + 1, ': ');
3
12
    ReadLn(students[i].fname);
    
    Write('Введите дату рождения студента ', i + 1, ': ');
    ReadLn(students[i].DOB);
    
    repeat
      Write('Введите курс студента (от 1 до 5) ', i + 1, ': ');
      ReadLn(students[i].course);
    until (students[i].course >= 1) and (students[i].course <= 5);
  end;
  
  
  writeln;
  writeln('Данные о студентах:');
  for i := 0 to High(students) do
  begin
    writeln;
    writeln('Студент ', i + 1);
    writeln('ФИО: ', students[i].fname);
    writeln('Дата рождения: ', students[i].DOB);1
    writeln('Курс: ', students[i].course);
  end;
  
end.
