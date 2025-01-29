type
  PNode = ^Node;
  Node = record
    int: integer;
    next: PNode;
end;

var head, p: PNode;
i,b:byte;
a,min,max:integer;


function NewNode(NewWord: integer): PNode;
begin
  New(Result);
  Result^.int := NewWord;
  Result^.next := nil;
end;

procedure add(str:integer);
begin
  p^.next := NewNode(str);
  p := p^.next;
end;
Begin
  min:=32767;
  max:=-32768;
  readln(a);
  head:=NewNode(a);
  p:=head;
  for i:=1 to 3 do
  begin
    readln(a);
    add(a);
  end;
  
  p:=head;
  
  while p^.next <> nil do
    begin
      if p^.int > max then
        max:= p^.int;
      if p^.int < min then
        min:= p^.int;
      p:=p^.next;
    end;
  if p^.int > max then
    max:= p^.int;
  if p^.int < min then
    min:= p^.int;
  write(min,' ', max);
end.
