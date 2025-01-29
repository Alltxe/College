unit main;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls;

type

  { TForm1 }

  TForm1 = class(TForm)
    back: TButton;
    b6: TButton;
    b1: TButton;
    b2: TButton;
    b3: TButton;
    divide: TButton;
    prod: TButton;
    minus: TButton;
    plus: TButton;
    dot: TButton;
    b0: TButton;
    ce: TButton;
    btn_sqr: TButton;
    devidex: TButton;
    equalss: TButton;
    clr: TButton;
    btn_sqrt: TButton;
    b7: TButton;
    b8: TButton;
    b9: TButton;
    b4: TButton;
    b5: TButton;
    Edit1: TEdit;

    procedure backClick(Sender: TObject);
    procedure clrClick(Sender: TObject);
    procedure ceClick(Sender: TObject);
    procedure Click(Sender: TObject);
    procedure ClickAction(Sender: TObject);
    procedure devidexClick(Sender: TObject);
    procedure dotClick(Sender: TObject);
    procedure equalssClick(Sender: TObject);
    procedure btn_sqrClick(Sender: TObject);
    procedure btn_sqrtClick(Sender: TObject);
    procedure minusClick(Sender: TObject);
  private

  public

  end;

var
  Form1: TForm1;
  a, b, c: real;
  actionn: string;

implementation

{$R *.lfm}

{ TForm1 }



procedure TForm1.clrClick(Sender: TObject);
begin
Edit1.text := '';
  a:=0;
  b:=0;
  c:=0;
end;


procedure TForm1.Click(Sender: TObject);
begin
  edit1.text := edit1.text + (sender as TButton).caption
end;

procedure TForm1.ClickAction(Sender: TObject);
begin
  if (edit1.text <> '') and (edit1.text <> '-') then begin
  a := StrToFloat(Edit1.Text);
  Edit1.Clear;
  actionn :=(sender as TButton).caption;
  end;
end;

procedure TForm1.devidexClick(Sender: TObject);
begin
  if edit1.text <> '' then begin
   a := StrToFloat(Edit1.Text);
   if a <> 0 then begin
     a := 1/(a);
     Edit1.Text:=FloatToStr(a);
     a := 0;
   end
   else
     showmessage('Деление на 0 невозомжно.') ;
  end;
end;

procedure TForm1.dotClick(Sender: TObject);
begin
     if Pos(',', Edit1.Text) = 0 then
        edit1.text:= edit1.text + ','

end;

procedure TForm1.equalssClick(Sender: TObject);
begin
  if (a <> null) and (edit1.text <> '') and (edit1.text <> '-') then begin
  b := StrToFloat(Edit1.Text);
  if (actionn = '/') and (b = 0) then
  begin
    ShowMessage('Деление на ноль невозможно.');
    Edit1.Clear;
  end
  else
  begin
  Edit1.Clear;
  case actionn of
  '+' : c := a+b;
  '-' : c := a-b;
  '*' : c := a*b;
  '/' : c := a/b;
  end;

  Edit1.Text:= FloatToStr(c);
  end;
  end;
end;

procedure TForm1.btn_sqrClick(Sender: TObject);
begin
  if edit1.text <> '' then begin
   a := StrToFloat(Edit1.Text);
   a := sqr(a);
   Edit1.Text:=FloatToStr(a);
   a := 0;
  end;
end;

procedure TForm1.btn_sqrtClick(Sender: TObject);
begin
  if edit1.text <> '' then begin
   a := StrToFloat(Edit1.Text);
   if a >= 0 then begin
     a := sqrt(a);
     Edit1.Text:=FloatToStr(a);
     a := 0;
   end
   else
     showmessage('Невозомжно извлечь корень из отрицательного числа.')
  end;
end;

procedure TForm1.minusClick(Sender: TObject);
begin
  if edit1.text = '' then
    edit1.text := '-'
  else if edit1.text <> '-' then
  begin
    a := StrToFloat(Edit1.Text);
    Edit1.Clear;
    actionn :=(sender as TButton).caption;
  end;
end;

procedure TForm1.backClick(Sender: TObject);
  var s:string;
begin
   s:=edit1.text;
    if s <> '' then
    delete(s, length(s),1);
    edit1.text:=s;
end;

procedure TForm1.ceClick(Sender: TObject);
begin
  edit1.clear;
end;

end.

