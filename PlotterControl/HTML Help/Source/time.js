var week = Array("воскресенье", "понедельник", "вторник", "среда", "четверг", "пятница", "суббота");
var month = Array("января", "февраля", "марта", "апреля", "мая", "июня", "июля", "августа", "сентября", "октября", "ноября", "декабря");

function Start()
{
    UpdateTime();
}

function UpdateTime()
{
    var CurrentTime = new Date();
    var InputTime = document.getElementById('MyTime');
    var InputDate = document.getElementById('MyDate');
    h = CurrentTime.getHours(); if (h < 10) h = "0" + h; m = CurrentTime.getMinutes();
    if (m < 10) m = "0" + m; s = CurrentTime.getSeconds();
    if (s < 10) s = "0" + s; outString = h + ":" + m + ":" + s;
    InputTime.innerHTML = outString;
    outString = CurrentTime.getDate() + " ";
    outString += month[CurrentTime.getMonth()] + " "; outString += CurrentTime.getFullYear() + " года";
    outString += " (" + week[CurrentTime.getDay()] + ")"; InputDate.innerHTML = outString; setTimeout("UpdateTime()", 1000);
}
