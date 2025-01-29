program z3;
type
  PNode = ^Node;
  Node = record
    str: string;
    next: PNode;
end;

var head, p: PNode;
i:byte;



function NewNode(NewWord: string): PNode;
begin
  New(Result);
  Result^.str := NewWord;
  Result^.next := nil;
end;

procedure add(str:string);
begin
  p^.next := NewNode(str);
  p := p^.next;
end;

Begin
  head:=NewNode('headnode');
  p:=head;
  for i:=1 to 9 do
    add(IntToStr(i*3));
  p:=head;
  for i:=1 to 10 do begin
    if i mod 2 = 0 then
    writeln(p^);
    p:=p^.next;
  end;
end.