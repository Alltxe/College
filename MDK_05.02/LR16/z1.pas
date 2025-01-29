program z1;
type PNode = ^Node;
     Node = record
       data: integer;
       next: PNode;
     end;
     
var s: Pnode;
filee: text;
num:integer; 

procedure Push( var Head: PNode; x: integer);
var NewNode: PNode;
begin
  New(NewNode);
  NewNode^.data := x;
  NewNode^.next := Head; 
  Head := NewNode;
end;

function Pop ( var Head: PNode ): integer;
var q: PNode;
begin
  if Head = nil then begin { если стек пустой } 
    Exit;
  end;
  Result := Head^.data;  { берем верхний символ }
  q := Head;             { запоминаем вершину } 
  Head := Head^.next; { удаляем вершину }
  Dispose(q);            { удаление из памяти }
end;

function isEmptyStack ( S: Pnode ): Boolean;
begin
  Result := (S = nil);
end;

begin
  assign(filee, 'nums.txt');
  reset(filee);
  
  while not EOF(filee) do begin
    readln(filee,num);
    push(s,num);
  end;
  while not(isEmptyStack(s)) do begin
    num:=pop(s);
    write(num:4);
  end;
end.



