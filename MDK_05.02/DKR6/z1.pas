uses crt;
const N = 20;
var i,j:byte;
last, num: integer;
exit_program := False;
stack: array [1..N] of integer;

procedure push (data:integer);
begin
  if last < N then begin
    last += 1;
    stack[last]:=data;
  end
  else
    writeln('Стек переполнен');
end;

function pop: integer;
begin
  if last > 0 then begin
    result := stack[last];
    stack[last]:=0;
    last -= 1;
  end
  else
    writeln('стек пуст');
end;

function isEmptyStack:boolean;
begin
if last = 0 then
  result := True
else
  result := False;
end;

Begin
  
  repeat
  writeln('1: Добавить элемент');
  writeln('2: Получить элемент');
  writeln('3: Вывести весь стек');
  writeln('4: выход');
  write('Ввод: ');
  readln(i);

    case i of
      1: begin
        readln(num);
        push(num);
        clrscr;
      end;
      2: begin
        writeln(pop);
        readln();
        clrscr;
      end;
      3: begin
        for j:=1 to last do
          write(stack[j], ' ');
        readln();
        clrscr;
      end;
      4: begin
        exit_program:=True;
      end;
    end;
  until exit_program;
end.
