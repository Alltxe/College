unit Unit1;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, ExtCtrls, StdCtrls;

type

  { TFmain }

  TFmain = class(TForm)
    TitleEdit: TEdit;
    Nextt: TButton;
    CountL: TLabel;
    Previouss: TButton;
    ProducerEdit: TEdit;
    CountEdit: TEdit;
    WeightEdit: TEdit;
    WeightL: TLabel;
    LightCheckbox: TCheckBox;
    title: TLabel;
    ProducerL: TLabel;
    Light: TLabel;
    procedure FormClose(Sender: TObject; var CloseAction: TCloseAction);
    procedure FormShow(Sender: TObject);
    procedure NexttClick(Sender: TObject);
    procedure PrevioussClick(Sender: TObject);
  private
    procedure GetRow(i: integer);
    procedure editdata(i:integer);
  public

  end;

var
  Fmain: TFmain;
  Data: TStringList;
  cur_row: integer;

implementation

{$R *.lfm}

{ TFmain }


procedure TFmain.FormShow(Sender: TObject);
Begin
  Data := TStringList.create;
  cur_row := 0;
  if FileExists('data.csv') then begin
     Data.LoadFromFile('data.csv');
      getRow(cur_row);
  end;
end;

procedure TFmain.NexttClick(Sender: TObject);
begin
 editdata(cur_row);
 if cur_row < data.count-1 then
    begin
      cur_row := cur_row + 1;
      getRow(cur_row);
    end
    else
   begin
     data.add('');
     cur_row += 1;
     titleedit.Clear;
     produceredit.clear;
     lightcheckbox.checked := False;
     countedit.clear;
     weightedit.clear;
   end;
end;

procedure TFmain.PrevioussClick(Sender: TObject);
begin
 editdata(cur_row);
 if cur_row > 0 then
    begin
      cur_row := cur_row - 1;
      getRow(cur_row);
    end;
end;

procedure TFmain.FormClose(Sender: TObject; var CloseAction: TCloseAction);
begin
  editdata(cur_row);
  data.saveToFile('data.csv')
end;

procedure TFmain.GetRow(i: integer);
var str: string;
begin
   str := Data.Strings[i];

   TitleEdit.text:=copy(str, 1, pos(',',str)-1);
   delete(str,1,pos(',',str));

   ProducerEdit.text:=copy(str, 1, pos(',',str)-1);
   delete(str,1,pos(',',str));

   if copy(str, 1, pos(',',str)-1) = 'True' then
      LightCheckbox.checked := True
   else
      LightCheckbox.checked := False;
   delete(str,1,pos(',',str));

   CountEdit.text:=copy(str, 1, pos(',',str)-1);
   delete(str,1,pos(',',str));

   WeightEdit.text:=str;
end;

procedure TFmain.editdata(i:integer);
var str:string;
begin
   if LightCheckbox.checked = True then
      str:= 'True'
   else str:='False';
   data.strings[i]:= TitleEdit.text + ',' + ProducerEdit.text + ',' +  str + ',' + CountEdit.text + ',' + WeightEdit.Text;
end;

end.

