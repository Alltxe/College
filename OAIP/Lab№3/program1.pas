Program z1;
uses crt;
var i, n: integer;
    a, b, h, x, xb, s, t, E: real;
    exitProgram: boolean;

function f(x: real): real;
begin
  result := 2 * x ** 3 - 2 * x ** 2 - 5 * x + 8; 
end;

begin
  exitProgram := false;

  repeat
      writeln('1. Ввод пределов интегрирования');
      writeln('2. Ввод количества отрезков');
      writeln('3. Вычисление интеграла и погрешности');
      writeln('0. Выход');
      write('Выберите опцию: '); readln(i);

    case i of
      1: 
      begin
        write('Введите нижний предел интегрирования '); readln(a);
        write('Введите верхний предел интегрирования '); readln(b);
      end;
      2:
      begin
        write('Введите количество отрезков '); readln(n);
        h := (b - a) / n;
        s := 0;
        xb := a;
        for i := 1 to n do
        begin 
          x := xb + i * h; 
          s := s + f(x) * h; 
        end;
        writeln('Интеграл равен ', s:12:10);
      end;
      3:
      begin
        t := 6 * x ** 2 - 4 * x - 5;
        E := (t / 2) * (h ** 2) * n;
        writeln('Погрешность ', abs(E)); 
      end;
      0: 
        exitProgram := true;
    end;

    writeln;
    if not exitProgram then
    begin
      write('Нажмите Enter для продолжения...'); 
      readln;
      clrscr;
    end;
  until exitProgram;

  writeln('Программа завершена.');
  readln;
end.
