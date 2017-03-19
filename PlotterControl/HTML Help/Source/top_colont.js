document.write('<link rel="shortcut icon" href="Source/main.ico" type="image/x-icon">');
document.write('<script language="javascript" type="text/javascript" src="Source/time.js"></script>');
document.write('<script language="javascript" type="text/javascript" src="Source/toc_former.js"></script>');

document.write('<table class="toc" width="250" border="2" cellspacing="0" cellpadding="5" align="left;"> <tr><td valign="top" style="padding-top: 20px; height:60px;"><div class=layer><span class="toc_id" id="toc"></span></div></td></tr></table>');
 
if(document.title == "Главная") {
document.write('</head> <body onLoad="Start(); UpDateNames(); FillTOC();">  <table class="top_colont" width="101%" border="2" cellspacing="0" cellpadding="5" align="left" > <tr><td height="15px" valign="top" width="89%" align="left"><span id="MyDate">--</span>.  <span id="MyTime">--</span></td><td width="120">By <b><a href="Coestaris.html">Coestaris</a></b></td></tr> </table>   <p>&nbsp;</p>   <div name="top" class="body_">'); } else { document.write('</head>  <body onLoad="Start(); FillTOC();">   <table class="top_colont" width="101%" border="2" cellspacing="0" cellpadding="5" align="left" > <tr><td height="15px" valign="top" width="80%" align="left"><span id="MyDate">--</span>.  <span id="MyTime">--</span></td><td  width="100"><a href="Home.html">Главная</a> </td><td width="120">By <b><a href="Coestaris.html">Coestaris</a></b></td></tr> </table>   <p>&nbsp;</p>   <div name="top" class="body_">'); }

