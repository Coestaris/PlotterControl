function Content(name,filename,level,islink,parent) {
  this.name = name;
  this.filename = filename;
  this.level = level;
  this.islink = islink;
  this.isHide = false;
  this.parent = parent;
  this.formalHide = false;
}

function set_cookie(name, value, exp_y, exp_m, exp_d, path, domain, secure) {
    var cookie_string = name + "=" + escape(value);
    if (exp_y) {
        var expires = new Date(exp_y, exp_m, exp_d);
        cookie_string += "; expires=" + expires.toGMTString();
    }
    if (path)
        cookie_string += "; path=" + escape(path);
    if (domain)
        cookie_string += "; domain=" + escape(domain);
    if (secure)
        cookie_string += "; secure";
    document.cookie = cookie_string;
}

var names = [new Content("Главная","home.html",1, true, 0),
             new Content("Функции программы", "", 1, false, 0),
             new Content("Меню", "", 2, true, 1),
             new Content("Настройки", "", 2, true, 1),
             new Content("Печать вектора", "", 2, true, 1),
             new Content("Ручное управление", "", 2, true, 1),
             new Content("Монитор порта", "", 2, true, 1),
             new Content("Векторный просмотрщик", "", 2, true, 1),
             new Content("Векторный редактор", "", 2, false, 1),
             new Content("Получить вектор", "", 2, false, 1),
             new Content("Макросы","",2,false,1),
			 new Content("Документация по API","",1, false, 0),
			 new Content("Основные понятия","ApiManual.html",2, true, 11),
			 new Content("Скетч контроллера","ArdSketch.html",2, true,11),
			 new Content("Прямые команды","DirectComands.html",2, true,11),
			 new Content("Список команд","ListOfDirectComands.html",3, true,11),
			 new Content("Список переменных","ListOfVars.html",3, true,11),
			 new Content("API Библиотеки","",2, false,11),
			 new Content("Connection", "API_CNCWFA_Connection.html", 3, true,17),
			 new Content("ManualControl","API_CNCWFA_ManualControl.html",3,true, 17),
			 new Content("MathParser","API_CNCWFA_MathParser.html",3,true, 17),
			 new Content("Printing","API_CNCWFA_Printing.html",3,true, 17),
  		     new Content("PrintMacros","API_CNCWFA_PrintMacros.html",3,true, 17),
			 new Content("VEditor","API_CNCWFA_VectEditorEnvironment.html",3,true, 17),
			 new Content("VectorHM","API_CNCWFA_VectorHM.html",3,true, 17),
			 new Content("Vectors", "API_CNCWFA_Vectors.html", 3, true, 17),
             new Content("Форматы файлов", "", 2, false, 11),
             new Content("Список форматов", "Format_List.html", 3, true, 26),
             new Content(".CVF", "Format_CVF.html", 3, true, 26),
             new Content(".PRRES", "Format_PRRES.html", 3, true, 26),
             new Content(".VDOC", "Format_VDOC.html", 3, true, 26),
             new Content(".PCMACROS", "Format_PCMACROS.html", 3, true, 26),
             new Content(".PCMPACK", "Format_PCMPACK.html", 3, true, 26)];
			 
function UpDateNames()
{
    /*var val = null;
    //var val = getCookie("hidded");
    //alert(val);
    if (val != null) {
        var res = val.split("%20");
        res.forEach(function (item, i, res) {
            if (item == "true") names[i] = true;
            else names[i] = false;
        });
    }*/
}

function FillTOC() 
{
  var Input = document.getElementById("toc");
  var s=location.href;
  var current = s.substr(s.lastIndexOf("/") + 1);
  var outstr = "<div class=\"toc_zag\">Table Of Content</div>";
  var rem = false;
  var ind = 0;
  names.forEach(function(item, i, names) {
   if (!item.islink) {
        if (!item.isHide) outstr += "<ul class=\"toc_link\" style=\"margin-left:" + item.level * 22 + "px;\"><li><a href='javascript:;' id = \"" + i + "\" onclick=\"clicked_list(this.id)\"><b>[" + item.name + "] -</b></a></li></ul>";
        else if (!names[item.parent].isHide) outstr += "<ul class=\"toc_link\" style=\"margin-left:" + item.level * 22 + "px;\"><li><a href='javascript:;' id = \"" + i + "\" onclick=\"clicked_list(this.id)\"><b>[" + item.name + "] +</b></a></li></ul>";
     }
    else {
       if (!item.isHide) {
           if (current == item.filename) { outstr += "<ul class=\"toc_link\" style=\"margin-left:" + item.level * 22 + "px;\"><li><b style=\"color:#F7FF9D;\">" + item.name + "</b></li></ul>"; }
           else outstr += "<ul class=\"toc_link\" style=\"margin-left:" + item.level * 22 + "px;\"><li><a href=\"" + item.filename + "\">" + item.name + "</a></li></ul>";
       }
     }
  })
  outstr += "<br><br><br><br>";
  Input.innerHTML = outstr;
}

function set(id, val)
{
    names.forEach(function (item, i, names) {
        if (names[i].parent == id) {
            names[i].isHide = val;
            if (!names[i].islink) {
                if (val) {
                    set(i, true);
                }
                else {
                    names[i].isHide = names[i].formalHide;
                    set(i, names[i].formalHide)
                }
            }
        }
    })
}

function clicked_list(id) {
    names[id].isHide = !names[id].isHide;
    if (names[id].level != 1)
        names[id].formalHide = names[id].isHide;
    set(id, names[id].isHide);
    var outstr = "";
    names.forEach(function (item, i, names) {
        outstr += item.isHide + " ";
    });
    FillTOC();
    var current_date = new Date;
    var cookie_year = current_date.getFullYear() + 1;
    var cookie_month = current_date.getMonth();
    var cookie_day = current_date.getDate();
}