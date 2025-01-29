type
  toy = record
    name: string;
    price: real;
    age: string;
  end;

var
  toys: array of toy;
  i: integer;

procedure PrintToyData(t: toy);
begin
  writeln('Название: ', t.name);
  writeln('Цена: ', t.price:0:2);
  writeln('Возрастной диапазон: ', t.age);
  writeln;
end;

begin
  
  SetLength(toys, 3);
  
  with toys[0] do
  begin
    name := 'Мячик';
    price := 100;
    age := '0+';
  end;
  
  with toys[1] do
  begin
    name := 'Кукла';
    price := 249.99;
    age := '3+';
  end;
  
  with toys[2] do
  begin
    name := 'Конструктор';
    price := 2000;
    age := '5+';
  end;
  
  
  for i := 0 to High(toys) do
  begin
    writeln('Информация о товаре ', i + 1);
    PrintToyData(toys[i]);
  end;
  
end.
