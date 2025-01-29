program z2;
type
  PNode = ^Node;
  Node = record
    words: string;
    count: integer;
    next: PNode;
end;

var head, p: PNode;
p1:pointer;
i: byte;
filetext: text;
s: string;


function NewNode(NewWord: string): PNode;
begin
  New(Result);
  Result^.words := NewWord;
  Result^.count := 1;
  Result^.next := nil;
end;

procedure add(str:string);
begin
  p^.next := NewNode(str);
  p := p^.next;
end;

function Find(Head: PNode; NewWord: string): PNode;
var pp: PNode;
begin
  pp := Head;
  while (pp <> nil) and (NewWord <> pp^.words) do 
    pp := pp^.next;
  Result := pp;
end;

Begin
  assign(filetext,'text.txt');
  reset(filetext);
  readln(filetext,s);
  head := NewNode(s);
  p:=head;
  
  while not EOF(filetext) do begin
    p:=head;
    readln(filetext,s);
    p1 := find(head,s);
    if p1 = nil then
    begin
      while (p^.next <> nil) do
      p:= p^.next;
      add(s)
    end
    else
      p:=p1;
      p^.count += 1;
  end;
  
  i:=1;
  p:=head;
  while p^.next <> nil do
  begin

    i+=1;
    p:=p^.next;
  end;
  write(i);
end.