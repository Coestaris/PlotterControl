const BaseName = 'Form_ViewVect';

const InDesignerCode = 'source.txt';
const OutCSCode = 'OutputCS.txt';
const OutXMLCode = 'OutputXML.txt';

procedure MakeCSCode();
begin
  var j := System.IO.File.ReadAllLines(InDesignerCode, encoding.UTF8).OrderBy(p->p).ToArray()
  .FindAll(p->p.contains('.Text ='))
  .Select(p->p.trim())
  .Select(p->P.replace('this.',''))
  .Select(p->P.replace('.Text',''));
 // var s := '';
 var a := OpenWrite(OutCSCode);
  Writeln(a,'         public static '+BaseName+' Translate('+BaseName+' form)');
  Writeln(a,'        {');
  Writeln(a,'            var a = TranslateBase.CurrentLang.Menu;');
  foreach var i in j.Select(p->P.split('=')[0].trim()) do
  begin
  if(i.EndsWith('Text')) then Writeln(a,'            form.',i,' = a["'+BaseName+'.',i,'"];')
    else   Writeln(a,'            form.',i,'.Text = a["'+BaseName+'.',i,'"];');
  end;
  Writeln(a,'            return form;');
  Writeln(a,'        }');
  a.Close();
end;

procedure MakeXMLCode();
begin
 var j := System.IO.File.ReadAllLines(InDesignerCode, encoding.UTF8);
 var names := System.IO.File.ReadAllLines(OutCSCode,  encoding.UTF8).ToList.FindAll(p->p.trim()<>'').Select(p->p.trim()).ToArray;

 foreach var a in names do 
  Writeln(A);

 var t:text := openWrite(OutXMLCode);
 for var i:=3 to names.length-3 do
  begin
   var s := '    <menu id="'+BaseName+'.';
   if(names[i].trim() = 'form.Text = a["'+BaseName+'.Text"];')  then s += 'Text'
   else s += names[i].Split('.')[1];
   s += '">';
   var e :='';
   if(names[i].trim() = 'form.Text = a["'+BaseName+'.Text"];') then e := j.ToList().Find(p->p.trim.startsWith('this.Text'))
   else e := j.ToList().Find(p->p.trim.startsWith('this.' +  names[i].Split('.')[1] + '.Text'));
   e := e.split('=')[1].replace('"','').replace(';','').remove(0,1);
   e:= e.replace('\r','&#009;').replace('\n','&#xA;');
   s += e;
   s += '</menu>';
   writeln(t,s);
 end;
 t.Close();
end;

begin
  MakeCSCode();
  MakeXMLCode();
end.

