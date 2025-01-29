type
  form = record
    fname: string;
    DOB: string;
    course: 1..5;
  end;

var
  student: form;

begin
 
  Write('Введите ФИО студента: ');
  Readln(student.fname);
  
  Write('Введите дату рождения студента: ');
  Readln(student.DOB);
  
  repeat
    Write('Введите курс студента (от 1 до 5): ');
    Readln(student.course);
  until (student.course >= 1) and (student.course <= 5);
  
  writeln;
  
  Writeln('ФИО студента: ', student.fname);
  Writeln('Дата рождения студента: ', student.DOB);
  Writeln('Курс студента: ', student.course);
  
end.
