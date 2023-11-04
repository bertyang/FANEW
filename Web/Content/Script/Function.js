/********************************************************************
 *funtion:this function is used confirm whether string is a datetime type
 *author:bert yang
 *create date:2003/9/15
 *
 * Modifier: Aaron Yang
 * Modify date: 2005/08/24
 * Modify Description: merge select.cs const.js for ApproveModel
********************************************************************/
String.prototype.trim = function()
{
    return this.replace(/(^\s*)|(\s*$)/g, "");
}

Request = {
 QueryString : function(item){
  var svalue = location.search.match(new RegExp("[\?\&]" + item + "=([^\&]*)(\&?)","i"));
  return svalue ? svalue[1] : svalue;
 }
}

function getInternetExplorerVersion()
// Returns the version of Internet Explorer or a -1
// (indicating the use of another browser).
{
	var rv = -1; // Return value assumes failure
	if (navigator.appName == 'Microsoft Internet Explorer')
	{
		var ua = navigator.userAgent;
		var re = new RegExp("MSIE ([0-9]{1,}[\.0-9]{0,})");
		if (re.exec(ua) != null)
			rv = parseFloat(RegExp.$1);
	}
	return rv;
}
var OPENWINDOW = 'location=no,toolbar=no,titlebar=no,resizable=yes,scrollbars=yes';	
var POPWINDOW_NAME="POPUP";
var OPENWINDOW_NO_MENU="location=no,menubar=no,titlebar=no,scrollbars=yes,toolbar=no,resizable=no,left="+700 +",top="+200+",height=250,width=300";
var OPENWINDOW_INTO_ONE=false;
var OPENMINIDIALOG="status:no;dialogWidth:210px;dialogHeight:230px;center:yes;help:no;scroll:no";

//copy from const.js by Aaron Yang	
var OPENWINDOW_NO_MENU="location=no,menubar=no,titlebar=no,scrollbars=yes,toolbar=no,resizable=yes,left=0,top=0,height="+	(window.screen.height-4)+",width="+(window.screen.width-12);
var OPENMIDDLEWINDOW_NO_MENU="location=no,menubar=no,titlebar=no,scrollbars=yes,toolbar=no,resizable=yes,left=0,top=0,height="+	(window.screen.height*2/3)+",width="+(window.screen.width*2/3);
var OPENMINIWINDOW_NO_MENU="location=no,menubar=no,titlebar=no,scrollbars=yes,toolbar=no,resizable=yes,left=0,top=0,height=250,width=300";
///var OPENWINDOW_INTO_ONE=false;
///var POPWINDOW_NAME="POPUP";
var POPMIDDLEWINDOW_NAME="POPUP_MIDDLE";
var POPMINIWINDOW_NAME="POPUP_MINI";
//var OPENMINIDIALOG="dialogLeft:"+(window.screen.width-300)/2+";dialogTop:"+(window.screen.height-250)/2+";dialogWidth:204px;dialogHeight:200px;center:yes;help:no;scroll:no";
///var OPENMINIDIALOG="status:no;dialogWidth:204px;dialogHeight:185px;center:yes;help:no;scroll:no";
var OPENMIDDLEDIALOG="status:no;dialogWidth:295px;dialogHeight:185px;center:yes;help:no;scroll:no";
var OPENCOMMONDIALOG="dialogWidth:550px;dialogHeight:450px;center:yes;help:no;scroll:no;status:no";
var OPENDIALOG="dialogWidth="+(window.screen.width-12)+"px;dialogHeight="+	(window.screen.height-4)+"px;center=yes;help=no;scroll=no";//Add by Jenny on 2003/10/16 for FlowER integration
//end of copy from const.js by Aaron Yang	

//for Michad提出的更大的带提示的FuzzySelectEmployee by Aaron Yang 2005-09-09
var OPENMINIDIALOGBIG="status:no;dialogWidth:245px;dialogHeight:345px;center:yes;help:no;scroll:no";
var OPEN_CALENDAR_DIALOG = "status:no;dialogWidth:262px;dialogHeight:250px;center:yes;help:no;scroll:no";
//for approve list show
var OPENMIDDLEDIALOGLARGER="status:no;dialogWidth:500px;dialogHeight:450px;center:yes;help:no;scroll:no";

// For IE 7.0 or abover version
var TITLE_BAR_ESTIMATED = 22; // 29 pixels or so for XP, 22 for Win2K...etc.Also relate to various themes.
var CHROME_THICKNESS_ESTIMATED = 2; // about 2 pixels or so...
// For Service Pack 2
var STATUS_BAR_ESTIMATED = 0; // Roughly 25 pixels or so... *no status bar in default security zone.

var ADJUSTED_WIDTH = 2 * CHROME_THICKNESS_ESTIMATED;
var ADJUSTED_HEIGHT = 2 * CHROME_THICKNESS_ESTIMATED + TITLE_BAR_ESTIMATED + STATUS_BAR_ESTIMATED;
	
var BROWSER_VERSION = getInternetExplorerVersion();
if(BROWSER_VERSION > -1 && BROWSER_VERSION > 6.0)	// IE and version over than 6.0, redefine global variables.
{
    OPENMINIDIALOGBIG = "status:no;dialogWidth:" + (245 - ADJUSTED_WIDTH) + "px;dialogHeight:" + (295 - ADJUSTED_HEIGHT) + "px;center:yes;help:no;scroll:no";
	OPEN_CALENDAR_DIALOG = "status:no;dialogWidth:258px;dialogHeight:" + (245 - ADJUSTED_HEIGHT) + "px;center:yes;help:no;scroll:no";
	OPENMIDDLEDIALOGLARGER="status:no;dialogWidth:496px;dialogHeight:" + (450 - ADJUSTED_HEIGHT) + "px;center:yes;help:no;scroll:no";
}

var objPopup = window.createPopup();

// Begin for search dropdownlist item.
//copy from select.js by Aaron Yang
var timelimit=2000;    
var length;
var strText;
var timer;
var TheForm;
var strKey;
function onKeyPress()
{
 timer=Date.parse(Date());
 TheForm=event.srcElement;
 length=TheForm.length;
 if(strKey==null)
 {  
  strKey="";
  for(i=0;i<length;i++)
  {
     TheForm.options[i].selected=false;
  } 
  lasttimer=timer;
 }
 if(timer-lasttimer>timelimit)
 {
  strKey="";
  for(i=0;i<length;i++)
  {
     TheForm.options[i].selected=false;
  } 
  strText="";
 }
 lasttimer=timer;
 strKey=strKey + String.fromCharCode(window.event.keyCode); 
 
 for(i=0;i<length;i++){
  strText=TheForm.options[i].text;
  strText=strText.toLowerCase();
  intI=strText.indexOf(strKey);
  if (intI==0){
     TheForm.options[i].selected=true;
     window.event.returnValue=false;
     return;
    }  
  else{
   TheForm.options[i].selected=false;
 
   }
  } 
}
//end of copy from select.js


function ShowDivMenu(objID)
{	
	//三级功能数
	var intRowCount=document.all("div"+objID).childNodes(0).rows.length;	
	
	//如果没有三级功能，则不显示三级菜单
	if (intRowCount==0)
		return;
		
	//alert(document.all("div"+objID).childNodes(0).rows(2).cells(0).innerHTML.length);

	//设定显示的位置和宽度
	//alert(window.event.srcElement);
    var left = document.all(objID).offsetLeft;
    var top = document.all(objID).offsetTop+60;

	var width=115;
	var height=25*intRowCount;		
	
	//设定显示的样式	
	var oPopBody = objPopup.document.body;	
	
	oPopBody.style.border = "solid black 1px;";
	oPopBody.style.fontSize = "1pt";
	oPopBody.style.paddingBottom= "1px";
	oPopBody.style.paddingTop= "1px";
	oPopBody.style.paddingLeft= "1px";
	oPopBody.style.paddingRight= "1px";
	oPopBody.style.borderColor="#9E9EA0";
	oPopBody.innerHTML = document.all("div"+objID).innerHTML;
	
	var addHeight = document.all("div"+objID).clientHeight - 16*intRowCount;
	height += addHeight;
	
	//objPopup.document.createStyleSheet().addImport("../Css/FormDesign.css")
	try
	{
		objPopup.document.createStyleSheet().addImport(CURRENTCSSFILE);
	}
	catch(ex)
	{
	}
	//objPopup.document.createStyleSheet().addImport("http://localhost/webadmin/css/custom_flower.css");	
	
	//显示	
	objPopup.show(left, top, width, height, document.body);

}
	
function exitWindow()
{
	var TopWindow=null;
	TopWindow=window.parent;
	while (TopWindow.location!=TopWindow.parent.location)
	{
		TopWindow=TopWindow.parent;
	}
	TopWindow.opener = null;
	TopWindow.open("","_self");
	TopWindow.close();
}


function HideDivMenu()
{
	objPopup.hide();
}

function openMiniDialog(p_strURL,p_strURLRelative,p_strTitle)
{
	try
	{
		var strURL = (p_strURL == null ? "" : p_strURL);
		var strWindowSize = "";
		strURL = strURL.toUpperCase();	
		var strWindowSize = OPENMINIDIALOG;	
		if(strURL.indexOf("FUZZYSELECTEMPLOYEE.ASPX") != -1)
			strWindowSize = OPENMINIDIALOGBIG;	
		if(strURL.indexOf("SELECTFORMLIST.ASPX") != -1)
		{
			strWindowSize=OPENMINIDIALOGBIG;
		}

		var strURLRelative=(p_strURLRelative==null?"":p_strURLRelative);
//		var ObjReturn=showModalDialog(strURLRelative+"DialogFrame.aspx?Action="+p_strURL+"&Title="+p_strTitle,null,OPENMINIDIALOG);
		var ObjReturn=showModalDialog(strURLRelative+"DialogFrame.aspx?Title="+p_strTitle+"&Action="+p_strURL,null,strWindowSize);
		//p_ObjReturn.value=p_strReturn!=""?p_strReturn:p_ObjReturn.value;
		//p_ObjReturn=ObjReturn;
		//m_objModelReturn=ObjReturn;
		return ObjReturn;
	}
	catch(ex)
	{
	}
}

function openSelfDialog(p_strURL, p_strURLRelative, p_strTitle, p_strFeatures)
{
	try
	{
		var strURLRelative=(p_strURLRelative==null?"":p_strURLRelative);
		var ObjReturn=showModalDialog(strURLRelative+"DialogFrame.aspx?Title=" + p_strTitle + "&Action=" + p_strURL, null, p_strFeatures);
		return ObjReturn;
	}
	catch(ex)
	{
	}
}

function openMiddleDialog(p_strURL,p_strURLRelative)
{
	try
	{
		var strURLRelative=(p_strURLRelative==null?"":p_strURLRelative);
		var ObjReturn=window.showModalDialog(strURLRelative+"DialogFrame.aspx?Action="+p_strURL,null,OPENMIDDLEDIALOG);
		//p_ObjReturn.value=p_strReturn!=""?p_strReturn:p_ObjReturn.value;
		//p_ObjReturn=ObjReturn;
		//m_objModelReturn=ObjReturn;
		return ObjReturn;
	}
	catch(ex)
	{
	}
}
function isdate(str)
{
	var flag;            //the varant use to post the date position
	var strtemp=str;	
	
	if (strtemp.indexOf("/")!=-1)
	{
		//year
		flag=strtemp.indexOf("/"); 	
		if (flag==-1) return false;	
		var strYear=strtemp.substring(0,flag);
		if (!isint(strYear)) return false;
				
		//month
		strtemp=strtemp.substring(flag+1,strtemp.length);		
		flag=strtemp.indexOf("/");		
		if (flag==-1) return false;	
		strMonth=strtemp.substring(0,flag);
		if (!isint(strMonth)) return false;
		
		//Day
		var strDay=strtemp.substring(flag+1,strtemp.length);
		if (!isint(strDay))	return false;
				
		return isright(parseInt(strYear,10),parseInt(strMonth,10),parseInt(strDay,10));
	}
	
	if (strtemp.indexOf("-")!=-1)
	{
		flag=strtemp.indexOf("-"); 	
		if (flag==-1) return false;	
		var strYear=strtemp.substring(0,flag);
		if (!isint(strYear)) return false;
				
		//month
		strtemp=strtemp.substring(flag+1,strtemp.length);		
		flag=strtemp.indexOf("-");		
		if (flag==-1) return false;	
		strMonth=strtemp.substring(0,flag);
		if (!isint(strMonth)) return false;
		
		//Day
		var strDay=strtemp.substring(flag+1,strtemp.length);
		if (!isint(strDay))	return false;
				
		return isright(parseInt(strYear,10),parseInt(strMonth,10),parseInt(strDay,10));
	}
	
	return false;
	
}





/********************************************************************
 *funtion:this function is used confirm whether year and month and day is right year
 *author:bert yang
 *create date:2003/9/15
 *Last Modify Date: 
********************************************************************/
function isright(year,month,day)
{
 //alert(year);alert(month);alert(day);
 if (year<=100 ||year>=2099) return false;
 
 if ((month>12)||(month<=0)) return false;
 
 if ((day>31)||(day<=0)) return false;
 
 //do with special years and months
 if (((month==2)||(month==4)||(month==6)||(month==9)||(month==11))&&(day>30)) return false;
 
 if ((month==2)&&(day>29))  return false;
 
 if (!((((year/4)==parseInt(year/4))&&((year/100)!=parseInt(year/100)))||((year/400)==parseInt(year/400)))&&(month>28)) return false;
 
 if (year<1753) return false;
 
 return true;
}

/********************************************************************
 *funtion:this function is used confirm whether string can converted numeric
 *author:bert yang
 *create date:2003/9/15
 *Last Modify Date: 
********************************************************************/
function isint(str)
{
	var i;
	for(i=0;i<str.length;i++)
	{
		var strChar=str.substring(i,i+1);
		
		if(isNaN(parseInt(strChar)))
		{
			return false;		
		}
	}
	
	return true;
}

/********************************************************************
 *funtion:this function is used confirm whether string can converted float
 *author:bert yang
 *create date:2003/9/15
 *Last Modify Date: 
********************************************************************/
function isfloat(str)
{
	var i;
	var flag=true;
	
	for(i=0;i<str.length;i++)
	{
		var strChar=str.substring(i,i+1);
		
		if(isNaN(parseInt(strChar)))
		{	
			if(strChar=="." && flag==true)
			{ 
				flag=false;
			}
			else
			{
				return false;		
			}
		}
	}
	
	return true;
}
/********************************************************************
 *funtion:this function is used deal spaces in a string 
 *author:bert yang
 *create date:2003/9/15
 *Last Modify Date: 
********************************************************************/

function trim(str)   
{	
	var k=0;
	var m=0;
	for(i=0;i<str.length;i++)
	{
		if(str.charCodeAt(i)!=32)
		{
			k=i;
			break;   
		}
	}
	if(i==str.length)   {str=""; return(str);}
	for(i=str.length-1;i>-1;i--)
	{
		if(str.charCodeAt(i)!=32)
		{
			m=i;
			break;   
		}
	}
	str=str.substring(k,m+1);	
	return(str);
} 
/********************************************************************
 *funtion:this function is used check input
 *author:bert yang
 *create date:2003/9/15
 *Last Modify Date: 
********************************************************************/

function KeyPress()
{
//	if(event.keyCode>14906 && event.keyCode<22358)
//		event.keyCode=0;
	//alert(event.keyCode)
	if(shiftpress){
		if(event.keyCode==60||event.keyCode==62||event.keyCode==34)
			//if(!(event.keyCode<91&&event.keyCode>63))
			//	event.keyCode=0;	
			//alert("SDFSDF");
			{event.keyCode=0;}
	}
	else{
		//if(event.keyCode==45||event.keyCode==91||event.keyCode==93||event.keyCode==59||event.keyCode==61||event.keyCode==39)//event.keyCode==44||event.keyCode==13||event.keyCode==46||event.keyCode==47||event.keyCode==92
		if(event.keyCode==91||event.keyCode==93||event.keyCode==59||event.keyCode==61||event.keyCode==39)//event.keyCode==44||event.keyCode==13||event.keyCode==46||event.keyCode==47||event.keyCode==92
		event.keyCode=0;
	}
}
/*
function calendar(source) 
{	
//	var sPath = getRelativeHttpPath();
	var sPath = "../ApproveModel/Module/calendar1.htm";
	
	var strFeatures = OPEN_CALENDAR_DIALOG;		
	
	var inDate = "";
	var initialDate = "";
	initialDate = beforeCalendar(source.value);		
	inDate = initialDate.split(";")[1];
	
	var outDate = showModalDialog(sPath, inDate, strFeatures);
	if((outDate == null) || (outDate == ""))
	{
	    outDate = initialDate;	// Keep initial value as FlowER expected.
	}
	else if(outDate=="Clear")
		outDate = "";
	else
		outDate = afterCalendar(outDate);
	
	// Refresh source element's value.
	if(outDate != "")
	{
		source.value = outDate.split(";")[0];
		source.hideValue = outDate.split(";")[1];
    }
	else
	{
	    source.value = "";   
	    source.hideValue = "";
	}
	
	// Format input date.
	function beforeCalendar(inDate)
	{	
		if(inDate == "") return "";
		try
		{	
//			var relativePath = getRelativeHttpPath();
			var strUrl = "../ApproveModel/Module/Calendar.aspx?DateTime=" + inDate;
			objHttp = new ActiveXObject("Microsoft.XMLHTTP");
			objHttp.open("GET",strUrl,false);
			objHttp.send();
			if (objHttp.responseText != "Error")
			{
				return objHttp.responseText;
			}
			else
				return "";	
		}				
		catch(e)
		{	
			return "";				
		}
	}
	
	// Format output date.
	// Default date formate is [mm dd, yyyy] return by calendar. Sample: [February 4, 2006].
	function afterCalendar(outDate)
	{	
		var rtDate = "";
		if(outDate == "") return "";
		try
		{	
//			var relativePath = getRelativeHttpPath();				
			var strUrl = "../ApproveModel/Module/Calendar.aspx?DateTime=" + outDate;
			objHttp = new ActiveXObject("Microsoft.XMLHTTP");
			objHttp.open("GET",strUrl,false);
			objHttp.send();
			
			if (objHttp.responseText != "Error")
			{
				return objHttp.responseText;						
			}					
		}
		catch(e)
		{	
			return "";				
		}	
	}
}
*/
function formatDate(sDate) {
	var sScrap = "";
	var dScrap = new Date(sDate);
	if (dScrap == "NaN") return sScrap;
	
	iDay = dScrap.getDate();
	iMon = dScrap.getMonth();
	iYea = dScrap.getFullYear();

	sScrap = iYea + "/" + ((iMon + 1)<10?"0":"")+(iMon + 1) + "/" + (iDay<10?"0":"")+iDay;
	return sScrap;
}

//选择人员时候使用的功能，全部来自Facade add by Aaron Yang 2005/07/27
function GetTipLength(p_strTip)
{
	var objTDTip=document.getElementById("TipContainer");
	try
	{
		if (objTDTip==null)
		{
			if (!bDelay)
			{
				var bLoaded=TipLoading();
				if (!bLoaded)
					return 0;
				else
					bDelay=true;
			}

			var strContainerHTML="<table cellpadding='0' cellspacing='0' border='0'><tr><td id='TipContainer'class='DivTip' nowrap></td><tr></table>";
			var objOriginDiv=document.createElement("<div style='visibility:hidden;position:absolute;top:0px;'>");
			objOriginDiv.innerHTML=strContainerHTML;
			document.body.appendChild(objOriginDiv);
			//document.body.insertBefore(objOriginDiv);
			document.all.TipContainer.innerText=p_strTip;
		}
		else
		{
			objTDTip.innerText=p_strTip;
		}
		var objRect=document.all.TipContainer.getBoundingClientRect();
		var intTextWidth=objRect.right-objRect.left;
		return intTextWidth;
	}catch(e)
	{
		//alert("GetTipLength:"+e);
		return 0;
	}
}

/********************************************************************
 *funtion:this function is used to show tip
 *author:Diasy Qi
 *create date:2005/1/4
 *Last Modify Date: 
********************************************************************/

var oTipPopup = window.createPopup();
function GetTipLength2(p_strTip)
{
	var objTDTip=document.getElementById("TipContainer");
	try
	{
		if (objTDTip==null)
		{
			var strContainerHTML="<table style='visibility:hidden' cellpadding='0' cellspacing='0' border='0'><tr>"
									+ "<td id='TipContainer' nowrap></td><tr></table>";
			var objOriginDiv=document.createElement("<div>");
			objOriginDiv.innerHTML=strContainerHTML;
			document.body.appendChild(objOriginDiv);
			//document.body.insertBefore(objOriginDiv);
			document.all.TipContainer.innerText=p_strTip;
		}
		else
		{
			objTDTip.innerText=p_strTip;
		}
		var objRect=document.all.TipContainer.getBoundingClientRect();
		var intTextWidth=objRect.right-objRect.left;
		return intTextWidth;
	}catch(e)
	{
		alert("GetTipLength:"+e);
		return 0;
	}
}

function ShowCustomTip(p_strTip)
{
	if (p_strTip=="")
		return;
	p_strTip=trim(p_strTip);
	
	var objEventEle=event.srcElement;
	var objEventTextRect=objEventEle.getBoundingClientRect();

	var intTipDivLeft=event.x + 5;
	var intTipDivTop=objEventTextRect.bottom + 5;
	var intTipTextWidth=GetTipLength2(p_strTip);
	if (intTipTextWidth==0)
		return;

	var intRows=1;
	var intTipDivWidth=intTipTextWidth>300?300:intTipTextWidth;
	if (intTipTextWidth>intTipDivWidth)
	{
		intRows=parseInt(intTipTextWidth/intTipDivWidth,10);
		var intOther=intTipTextWidth%intTipDivWidth;
		intOther=intOther>0?1:0;
		intRows=intRows+intOther;
	}
	intTipDivWidth=intTipDivWidth+6;

	//alert(2);
	var objTipDiv=document.getElementById("TipContainerDiv");
	if (objTipDiv==null)
	{
		var strTipDiv="<div id='TipContainerDiv' style='background-color:lightyellow;font-size:10pt;font-family:Verdana;border:solid 1px black;";
		strTipDiv+="padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px; '>";
		objTipDiv=document.createElement(strTipDiv);
		objTipDiv.innerText=p_strTip;
		document.body.insertBefore(objTipDiv);
	}
	else
	{
		objTipDiv.innerText=p_strTip;
	}

	var objRect=document.all.TipContainerDiv.getBoundingClientRect();
	var intHeight=objRect.bottom-objRect.top;
	intHeight=intHeight*intRows;
	oTipPopup.document.body.innerHTML=document.all.TipContainerDiv.outerHTML;
	oTipPopup.show(intTipDivLeft, intTipDivTop, intTipDivWidth, intHeight, document.body);
}

function CloseCustomTip()
{
	oTipPopup.hide();	
}

//为Michad对通知设定页面tip的位置要求而对ShowCustomTip做了一点改动。 Aaron Yang 2005-09-15
function ShowCustomTip2(p_strTip)
{
	if (p_strTip=="")
		return;
	p_strTip=trim(p_strTip);
	
	var objEventEle=event.srcElement;
	var objEventTextRect=objEventEle.getBoundingClientRect();

	var intTipDivLeft=event.x + 5;		//modify
	var intTipDivTop=objEventTextRect.bottom + 5;
	var intTipTextWidth=GetTipLength2(p_strTip);
	if (intTipTextWidth==0)
		return;

	var intRows=1;
	var intTipDivWidth=intTipTextWidth>300?300:intTipTextWidth;
	if (intTipTextWidth>intTipDivWidth)
	{
		intRows=parseInt(intTipTextWidth/intTipDivWidth,10);
		var intOther=intTipTextWidth%intTipDivWidth;
		intOther=intOther>0?1:0;
		intRows=intRows+intOther;
	}
	intTipDivWidth=intTipDivWidth;

	//alert(2);
	var objTipDiv=document.getElementById("TipContainerDiv");
	if (objTipDiv==null)
	{
		var strTipDiv="<div id='TipContainerDiv' style='background-color:lightyellow;font-size:9pt;font-family:Arial;border:solid 1px black;";
		strTipDiv+="padding-bottom:1px;padding-left:2px;padding-right:2px;padding-top:2px;font-weight:normal '>";
		objTipDiv=document.createElement(strTipDiv);
		objTipDiv.innerText=p_strTip;
		document.body.insertBefore(objTipDiv);
	}
	else
	{
		objTipDiv.innerText=p_strTip;
	}

	var objRect=document.all.TipContainerDiv.getBoundingClientRect();
	var intHeight=objRect.bottom-objRect.top;
	intHeight=intHeight*intRows;
	oTipPopup.document.body.innerHTML=document.all.TipContainerDiv.outerHTML;
	oTipPopup.show(intTipDivLeft, intTipDivTop, intTipDivWidth, intHeight, document.body);
}


/// <summary>
/// 取得特定格式下的文本的px宽度。 Created by Aaron Yang 2005-09-13
/// </summary>
/// <param name="p_strText">文本</param>
/// <param name="p_strTextStyleString">文本的格式字符串，例如："font-size:9pt;font-family:Arial"。</param>
/// <returns>所给文本在所指定的格式下的宽度，以px为单位</returns>
function GetTextLengthInPX(p_strText, p_strTextStyleString)
{
	var objTextContainer = document.getElementById("TextContainer");	//用于测量文本宽度的临时容器
	try
	{
		if (objTextContainer == null)	//如果不存在文本容器则创建
		{
			var strContainerHTML = "<table style='visibility:hidden' cellpadding='0' cellspacing='0' border='0'><tr>"
									+ "<td id='TextContainer'"
									+ " style='" + p_strTextStyleString + "'"
									+ " nowrap></td><tr></table>";
			var objOriginDiv = document.createElement("<div>");
			objOriginDiv.innerHTML = strContainerHTML;
			document.body.appendChild(objOriginDiv);
			document.all.TextContainer.innerText = p_strText;
		}
		else							//否则存在文本容器则直接使用
		{
			objTextContainer.innerText = p_strText;
		}
		var objRect = document.all.TextContainer.getBoundingClientRect();
		var intTextWidth = objRect.right - objRect.left;
		if (objTextContainer == null)	//删除临时创建的文本容器
		{
			document.body.removeChild(document.body.lastChild);
		}
		return intTextWidth;
	}catch(e)
	{
//		alert("Error Occured! GetTextLengthInPX:"+e);
		return 0;
	}
}

/// <summary>
/// 给SELECT控件的“请选择”两边加若干“-”。 Created by Aaron Yang 2005-09-13
///		假定SELECT控件的第一项为“请选择”、“请选择表单”、“Please Select”等等诸如此类，
///		把例如“请选择”变成“-----请选择-----”以填满整个SELECT的宽度。
///		调用GetTextLengthInPX函数。
/// </summary>
/// <param name="p_strSelectObjName">SELECT控件的“NAME”或“ID”属性</param>
function AddBarToPleaseSelect(p_strSelectObjName)
{
	try
	{
		var intDropDownWidth = 25;	//SELECT控件的下拉按钮的宽度
		var strTextStyleString="";	//文本的格式字符串
		
		var objSelect = document.all(p_strSelectObjName);					//SELECT控件对象

		var strPleaseSelect = objSelect.options[0].text;					//请选择文本

		//拼装文本格式字符串，只包含影响文本Render宽度的属性
		strTextStyleString = strTextStyleString + "font-family:" + objSelect.currentStyle.fontFamily + ";";
		strTextStyleString = strTextStyleString + "font-size:" + objSelect.currentStyle.fontSize + ";";
		strTextStyleString = strTextStyleString + "font-style:" + objSelect.currentStyle.fontStyle + ";";
		strTextStyleString = strTextStyleString + "font-weight:" + objSelect.currentStyle.fontWeight + ";";
		strTextStyleString = strTextStyleString + "font-variant:" + objSelect.currentStyle.fontVariant + ";";
		strTextStyleString = strTextStyleString + "letter-spacing:" + objSelect.currentStyle.letterSpacing + ";";
		strTextStyleString = strTextStyleString + "word-spacing:" + objSelect.currentStyle.wordSpacing + ";";
		strTextStyleString = strTextStyleString + "text-transform:" + objSelect.currentStyle.textTransform + ";";

		var intSelectWholeWidth = parseInt(objSelect.currentStyle.width);	//整个SELECT控件的宽度
		if (isNaN(intSelectWholeWidth))		//如果没有明确定义Width属性，则SELECT的Width由最长item决定
		{
			intSelectWholeWidth = 0;
			for (var i = 0; i < objSelect.options.length; i++)
			{
				var strTemp = objSelect.options[i].text;
				var intTemp = GetTextLengthInPX(strTemp, strTextStyleString);
	//			alert(strTemp+intTemp);
				if (intTemp > intSelectWholeWidth)
				{
					intSelectWholeWidth = intTemp;
				}
			}
			intSelectWholeWidth = intSelectWholeWidth + intDropDownWidth + 10;	//加上SELECT控件的下拉按钮的宽度和误差
		}
		
		var intPleaseSelectWidth = GetTextLengthInPX(strPleaseSelect, strTextStyleString);	//请选择文本的px宽度
		var intBarCharWidth  = GetTextLengthInPX("-", strTextStyleString);					//请选择文本的px宽度
		var intBarCharCountOneSide = parseInt((intSelectWholeWidth - intDropDownWidth - intPleaseSelectWidth) / 2 / intBarCharWidth);//单边待加的“-”数
		
		for (var i = 0; i < intBarCharCountOneSide; i++)
		{
			strPleaseSelect = "-" + strPleaseSelect + "-";
		}
		strPleaseSelect = strPleaseSelect + "--";	//填补两边各不足一个“-”宽的空间

	//	alert(strTextStyleString);
	//	alert("old text=" + objSelect.options[0].text);
	//	alert("drop width=" + intSelectWholeWidth);
	//	alert("text width=" + intPleaseSelectWidth);
	//	alert("bar width=" + intBarCharWidth);
	//	alert("bar count=" + intBarCharCountOneSide);
	//	alert("new text=" + strPleaseSelect);
	//	return intBarCharCountOneSide;
		
		objSelect.options[0].text = strPleaseSelect;
	}
	catch(e)
	{
	}
}

/// <summary>
/// 单行SELECT对象中对于当前选中的文本过长不能显示完全则通过tip方式显示。 Created by Aaron Yang 2005-09-20
///		调用GetTextLengthInPX函数和closePopUp函数。
/// </summary>
/// <param name="obj">SELECT对象</param>
/// <param name="p_strPosType">tip显示位置类型，可省略，取值"MousePoint"则为鼠标下方，否则为SELECT对象下方</param>
/// <param name="p_intOffsetX">X方向偏移量,单位px，可省略，缺省为0</param>
/// <param name="p_intOffsetY">Y方向偏移量,单位px，可省略，缺省为0</param>
/// <param name="p_strDisplayText">要以Tips显示的文本,可省略，如果指定，则显示该文本，否则显示obj的当前文本</param>
/// <param name="p_isShowTips">是否不论超过长度，都显示Tips</param>
function ShowTips(obj, p_strPosType, p_intOffsetX, p_intOffsetY, p_strDisplayText, p_isMustShowTips)
{
	if (obj == null)
		return;
	if (obj.selectedIndex == -1)
		return;
		
	var strPosType = p_strPosType;
	var intOffsetX = parseInt(p_intOffsetX);
	var intOffsetY = parseInt(p_intOffsetY);
	var isMustShowTips = p_isMustShowTips;
	
	var strTips = "";
	
	if (isNaN(intOffsetX))
		intOffsetX = 0;
	if (isNaN(intOffsetY))
		intOffsetY = 0;
	
	if(p_strDisplayText)
	{
		strTips = p_strDisplayText;		
	}
	else
	{
		strTips = obj.options[obj.selectedIndex].text
	}
	
	var strTextStyleString="";	//文本的格式字符串
	//拼装文本格式字符串，只包含影响文本Render宽度的属性
	strTextStyleString = strTextStyleString + "font-family:" + obj.currentStyle.fontFamily + ";";
	strTextStyleString = strTextStyleString + "font-size:" + obj.currentStyle.fontSize + ";";
	strTextStyleString = strTextStyleString + "font-style:" + obj.currentStyle.fontStyle + ";";
	strTextStyleString = strTextStyleString + "font-weight:" + obj.currentStyle.fontWeight + ";";
	strTextStyleString = strTextStyleString + "font-variant:" + obj.currentStyle.fontVariant + ";";
	strTextStyleString = strTextStyleString + "letter-spacing:" + obj.currentStyle.letterSpacing + ";";
	strTextStyleString = strTextStyleString + "word-spacing:" + obj.currentStyle.wordSpacing + ";";
	strTextStyleString = strTextStyleString + "text-transform:" + obj.currentStyle.textTransform + ";";
	var intTipLength = GetTextLengthInPX(strTips, strTextStyleString);	
	var intSelectRealWidth = parseInt(obj.currentStyle.width) - 25;
	
	if(!isMustShowTips && (intTipLength > intSelectRealWidth) || isMustShowTips)	
	{
		objPopUp = window.createPopup();
		var oPopBody = objPopUp.document.body;	
		oPopBody.style.backgroundColor = "lightyellow";
		oPopBody.style.border = "solid black 1px;";
		oPopBody.style.fontSize = obj.currentStyle.fontSize;
		oPopBody.style.fontFamily = obj.currentStyle.fontFamily;
		oPopBody.style.paddingBottom= "1px";
		oPopBody.style.paddingTop= "2px";
		oPopBody.style.paddingLeft= "2px";
		oPopBody.style.paddingRight= "2px";
		oPopBody.innerHTML = strTips;
		var objRect=obj.getBoundingClientRect();
		if (strPosType == "MousePoint")
			objPopUp.show(event.x + intOffsetX, event.y + intOffsetY, intTipLength + 6, 20, document.body);
		else
			objPopUp.show(objRect.left + intOffsetX, objRect.bottom + intOffsetY, intTipLength + 6, 20, document.body);

		window.setTimeout("closePopUp();",3000);
	}
}

//隐藏tip。被ShowTips函数调用，请参考ShowTips函数说明。 Created by Aaron Yang 2005-09-20
function closePopUp()
{
	if (objPopUp != null)
	{
		objPopUp.hide();
	}
}

function GetReturnValue(p_objReturn)
{
	var objReturn=new Object();
	objReturn.text="";
	objReturn.value="";
	
	if (typeof(p_objReturn)!="undefined" && p_objReturn!=null)
	{
		if ("text" in p_objReturn)
			objReturn.text=p_objReturn.text;
		if ("value" in p_objReturn)
			objReturn.value=p_objReturn.value;	
	}	
	
	return objReturn;	
}

function openContainer(type, action, sourceID)
{
	var url = "../ApproveListContainer.aspx?Type=" + type + "&IfAction=" + action + "&SourceID=" + sourceID;						
	var objReturn = openSelfDialog(url, "Module/", "2012", OPENMIDDLEDIALOGLARGER);
	return objReturn;
}
function openContainer1(type, action, sourceID, guid) 
{
    var url = "../ApproveListContainer.aspx?Type=" + type + "&IfAction=" + action + "&SourceID=" + sourceID + "&guid=" + guid;
    var objReturn = openSelfDialog(url, "Module/", "2012", OPENMIDDLEDIALOGLARGER);
    return objReturn;
}
function openContainerOfApproveLevel(sourceID)
{
	var url = "../ApproverLevelContainer.aspx?SourceID=" + sourceID;						
	var objReturn = openSelfDialog(url, "Module/", "330106", OPENMIDDLEDIALOGLARGER);
	return objReturn;
}
function CheckKeypressNumic(id) 
{ 
    if (id.value.indexOf(".")==-1) 
    { 
        if (!((event.keyCode>47 && event.keyCode<58)||(event.keyCode==46)))  
        { 
            event.keyCode=0; 
        }
    } 
    else 
    { 
        if (!(event.keyCode>47 && event.keyCode<58)) 
        { 
            event.keyCode=0; 
        }
    }
}

 function checkPhone(objElement)	
{    
    var strPhone = objElement;     
    if (strPhone == "")	
    {
         return false;
    }
     
    //var regInput = /[^\d^;^#^\-^(^)]/;///(\d{3}-\d{8}|\d{4}-\d{8}|\d{4}-\d{4}|\d{4}|\d{4}-\d{7}|\d{3}-\d{7})(-\d{2,8})?/;
    var regInput = /^[0-9-\/+ ()]*$/;
    if(!regInput.test(strPhone))  
    { 
        return false
    }	
    else
        return true;
}

function checkMail(objElement)
{ 
  var strMail = objElement;	
  if (strMail == "")
  {
      return false;
  }
  var regInput = /^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/; 
  if(!regInput.test(strMail))  
  { 
      return false
  }
  else
      return true;
}

//打开表单多语言维护界面，返回languageId
function openMaintainGlossaryPage(url, languageId, languageType, referBy, maxLength, allowEmpty, multiLine, IsByByte,checkField)
{	
	var strFeatures,ObjReturn;
	if(BROWSER_VERSION > -1 && BROWSER_VERSION > 6.0)
	{
		if(multiLine == "1")
		{
			strFeatures = "status:no;dialogWidth:560px;dialogHeight:360px;center:yes;help:no;scroll:no;top:10px";
		}
		else
		{
			strFeatures = "status:no;dialogWidth:560px;dialogHeight:180px;center:yes;help:no;scroll:no;top:10px";
		}	
	}
	else
	{
		if(multiLine == "1")
		{
			strFeatures = "status:no;dialogWidth:560px;dialogHeight:395px;center:yes;help:no;scroll:no;top:10px";
		}
		else
		{
			strFeatures = "status:no;dialogWidth:560px;dialogHeight:205px;center:yes;help:no;scroll:no;top:10px";
		}
    }

	ObjReturn = showModalDialog(url + "?GLOSSARY_ID=" + languageId + "&REFER_BY=" + referBy + "&MAX_LENGTH=" + maxLength + "&ALLOW_EMPTY=" + allowEmpty + "&MULTILINE=" + multiLine + "&BY_BYTE=" + IsByByte + "&CHECK_FIELD=" + checkField, null, strFeatures);

	return ObjReturn;
}

function closeWindow() {
    try {
        window.returnValue = "ButtonRefresh";
    }
    catch (ex) {
    }
    window.close();
}

//根据中英文来判断最大长度（如中文10，英文30）
//For Oracle 
function checkMaxLength(input, maxLength) {
    var strValue = "";
    for (var i = 0, len = input.value.length; i < len; i++) {
        strValue += input.value.charAt(i);
        if (getCharLength(strValue) > maxLength) {
            input.value = input.value.substr(0, i);
            return;
        }
    }
}

function getCharLength(str) {
    var charLen = 0;
    for (var i = 0, len = str.length; i < len; i++) {
        if (str.charCodeAt(i) > 255) {
            charLen += 3;
        } else {
            charLen += 1;
        }
    }
    return charLen;
}