type
  toy = record
    name: string;
    price: real;
    age: string;
  end;

var
  toys: array of toy;
  i: integer;
  f: text;

begin
  Assign(f, 'toys.txt');
  reset(f);

 
  SetLength(toys, 3);

  for i:=0 to 2 do
    with toys[i] do
    begin
      readln(f, name);
      readln(f, price);
      readln(f, age);
    end;
  
  for i := 0 to High(toys) do
  begin
    writeln('Информация о товаре ', i + 1);
    writeln('Название: ', toys[i].name);
    writeln('Цена: ', toys[i].price:0:2);
    writeln('Возрастной диапазон: ', toys[i].age);
  end;

  Close(f);
end.