//	WebHelp 5.10.006
var gaButtons=new Array();
var	gaTypes=new Array();
var gaBtnBgColor=new Array();
var gaSelBtnBgColor=new Array();
var gaOrders=null;
var gaObjBtns=new Array();
var BTN_TEXT=1;
var BTN_IMG=2;
var BTN_IMG_TOP=4
var BTN_IMG_BOTTOM=8;
var BTN_IMG_LEFT=16;
var BTN_IMG_RIGHT=32;
var gsAlign="left";
var gsBgImage="";
var gsBgColor="#99ccff";
var gsShadow="#cccccc";
var gsTBBgImage="";
var gnShowHideStyle=0;
var goTocInfo=null;
var gbTocInfoInited=false;
var goWebSearch=null;
var gsTBFontFamily="Arial";
var gsTBFontSize="xx-small";
var gsTBFontColor="#003063";
var gsTBDarkColor="#808080";
var gsTBLightColor="#FFFAFA";
var gsTBSelectedBgColor="#639ace";
var gsTBFontSelectedColor="#ffffff";
var gaOnLoads=new Array();
var goWebSearchEnable=true;

var goShow=null;
var goHide=null;
var goHide2=null;
var goSync=null;

var goToc=null;
var goIdx=null;
var goFts=null;
var goGlo=null;
var goNext=null;
var goPrev=null;
var goRole=null;

var LAYOUT=1;
var HLAYOUT=0;
var VLAYOUT=1;
var ALIGN=2;
var BALIGN=0;
var EALIGN=2;
var goEl=null;
var gnRE=0;

var gnButtonLayout=0;
var gnShowHide=-1;

var gbEqualSize=false;
var goCusButton=new Array();
var gsBtnStyle="";
var gaAvenues=null;
var gsCurAveName="";

var gsIToc=null;
var gsITocS=null;
var gsIIndex=null;
var gsIIndexS=null;
var gsISearch=null;
var gsISearchS=null;
var gsIGlossary=null;
var gsIGlossaryS=null;
var gsIBanner=null;
var gsIGo=null;

var gsIHide=null;
var gsIPrev=null;
var gsINext=null;
var gsISync=null;
var gsINextD=null;
var gsIPrevD=null;
var gsIWebSearch=null;
var gsIWebSearchD=null;

var gbAveButttnInited=false;
var goNextParent=null;
var goPrevParent=null;
var gsSearchPrompt="- Search -";

var gstrSearch="";
var gbPreview=false;
gbPreview=false; 
var gsSearchFormTitle="";
var gnHasNavPane=-1;
var gbInitBtn=false;
var gaBtns=new Array();
var gbWhTBar=false;
var goTextFont=null;
var goSelTextFont=null;
var gsPane="";
var gbNeedUpdateAve=false;
var gbUpdateTimerCount=0;

function setGoImage(sGoImage)
{
	if(sGoImage)
	{
		gsIGo=sGoImage;
	}
}

function btnBgColor(sType,sColor)
{
	this.sType=sType;
	this.sColor=sColor;
}

function setBackground(sBgImage)
{
	gsBgImage=sBgImage;
}

function setBackgroundcolor(sBgColor)
{
	gsBgColor=sBgColor;
}

function setAlignment(strAlignment)
{
	gnButtonLayout=0;
	if(strAlignment=="left")
	{
		gnButtonLayout=HLAYOUT|BALIGN;
	}
	else if(strAlignment=="right")
	{
		gnButtonLayout=HLAYOUT|EALIGN;
	}
	else if(strAlignment=="top")
	{
		gnButtonLayout=VLAYOUT|BALIGN;
	}
	else if(strAlignment=="bottom")
	{
		gnButtonLayout=VLAYOUT|EALIGN;
	}
}

function writeStyle(bMiniBar)
{
	var sStyle="";
	sStyle+="<style type='text/css'>\n";
	sStyle+="<!--\n";
	sStyle+=".clsBtnNormal {\n";
	if(!(gbNav4&&!gbNav6))
		if (bMiniBar)
			sStyle+="padding:2px;\n";
		else
			sStyle+="padding:5px;\n";
	sStyle+="cursor:hand;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsNoBNormal {\n";
	sStyle+="padding-left:2px;padding-right:2px;\n";
	sStyle+="cursor:hand;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsBtnDisable {\n";
	if(!(gbNav4&&!gbNav6))
		if (bMiniBar)
			sStyle+="padding:2px;\n";
		else
			sStyle+="padding:5px;\n";
	sStyle+="cursor:default;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsNoBDisable {\n";
	sStyle+="padding-left:2px;padding-right:2px;\n";
	sStyle+="cursor:default;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";


	sStyle+=".clsNotBtn {\n";
	if(!(gbNav4&&!gbNav6))
		if (bMiniBar)
			sStyle+="padding:2px;\n";
		else
			sStyle+="padding:5px;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsBtnUp{\n";
	if(!(gbNav4&&!gbNav6))
		if (bMiniBar)
			sStyle+="padding:1px;\n";
		else
			sStyle+="padding:4px;\n";
	sStyle+="border-bottom:"+gsTBDarkColor+" 1px solid;\n";
	sStyle+="border-left:"+gsTBLightColor+" 1px solid;\n";
	sStyle+="border-right:"+gsTBDarkColor+" 1px solid;\n";
	sStyle+="border-top:"+gsTBLightColor+" 1px solid;\n";
	sStyle+="cursor:hand;";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsNoBUp{\n";
	sStyle+="padding-left:2px;padding-right:2px;\n";
	sStyle+="cursor:hand;";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=".clsBtnDown{\n";
	if(!(gbNav4&&!gbNav6))
		if (bMiniBar)
			sStyle+="padding:1px;\n";
		else
			sStyle+="padding:4px;\n";
	sStyle+="border-bottom:"+gsTBLightColor+" 1px solid;\n";
	sStyle+="border-left:"+gsTBDarkColor+" 1px solid;\n";
	sStyle+="border-right:"+gsTBLightColor+" 1px solid;\n";
	sStyle+="border-top:"+gsTBDarkColor+" 1px solid;\n";
	sStyle+="color:"+gsTBFontColor+";\n";
	sStyle+="cursor:hand;\n";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";}\n";

	sStyle+=".clsNoBDown{\n";
	sStyle+="padding-left:2px;padding-right:2px;\n";
	sStyle+="cursor:hand;";
	sStyle+="font-family:"+gsTBFontFamily+";\n";
	sStyle+="font-size:"+gsTBFontSize+";\n";
	sStyle+="color:"+gsTBFontColor+";}\n";

	sStyle+=getDefaultButtonFont();
	sStyle+=gsBtnStyle;
	sStyle+=".clsToolbarBackground{\n";
	sStyle+="margin:2px;}\n";
	sStyle+="-->\n";
	sStyle+=" body {\n";
	if (gsBgImage)
		sStyle+="border-top:"+gsBgColor+" 1px solid;}\n";
	else
		sStyle+="border-top:black 1px solid;}\n";
	sStyle+="-->\n";
	sStyle+="</style>\n";
	document.write(sStyle);
}

function button(sType,sText,nWidth,nHeight)
{
	this.sType=sType;
	this.sText=sText;
	this.nWidth=nWidth;
	this.nHeight=nHeight;
	
	this.aIs=new Array();
	var i=0;
	while(button.arguments.length>i+4)
	{
		if (button.arguments[4+i])
			this.aIs[i]=_getFullPath(_getPath(document.location.href),button.arguments[4+i]);
		else
			this.aIs[i]="";
		i++;
	}
}

function getImage(oImage,sTitle)
{
	if(oImage.aIs[0])
	{
		var sI="";
		if(sTitle=="")
			sTitle=oImage.sText;
		sI+="<img alt=\""+sTitle+"\" src=\""+oImage.aIs[0]+"\"";
		if(oImage.nWidth>0)
			sI+=" width="+oImage.nWidth;
		if(oImage.nHeight>0)
			sI+=" height="+oImage.nHeight;
		sI+=" border=0 align=\"absmiddle\">";
		return sI;
	}
	return "";
}

function getCurrentAveName()
{
	var oSelect=getElement("avenue");
	if(oSelect)
		return oSelect.value;
	else
		return "";
}

function updateWebSearch(bEnable)
{
	var oWebSearch=getElement("btnwebsearch");
	var oWebSearchParent=null;
	if(oWebSearch)
		oWebSearchParent=getParentNode(oWebSearch);
	goWebSearchEnable=bEnable;
	if(oWebSearchParent)
	{
		if(bEnable)
			enableButton(oWebSearchParent,goWebSearch);
		else
			disableButton(oWebSearchParent,goWebSearch);
	}

}

function setState(oEL,sState)
{
	if(gbNav6||gbOpera)
		oEL.setAttribute("state",sState);
	else
		oEL.state=sState;	
}

function updateAvenueIfNeeded()
{
	gbUpdateTimerCount--;
	if (gbNeedUpdateAve&&gbUpdateTimerCount==0)
	{
		updateAvenue();
	}
}

function updateAvenue()
{
	var sSelect=getAvenueHTML(gaAvenues);
	var oSelect=getElement("avenue");
	if(oSelect)
	{
		if(gbNav6)
		{
			var oParent=getParentNode(oSelect);
			
			if(oParent)
			{
				removeThis(oSelect);
				oParent.insertAdjacentHTML("afterBegin",sSelect);
			}
		}
		else
			oSelect.outerHTML=sSelect;	
		oSelect=getElement("avenue");
		if(isValidAvenue(gaAvenues,gsCurAveName))
			oSelect.value=gsCurAveName;
	}
	updateAveButton();
}

function initAveButtonObj()
{
	if(!gbAveButttnInited)
	{
		var oNext=getElement("btnavnext");
		if(oNext)
			goNextParent=getParentNode(oNext);

		var oPrev=getElement("btnavprev");
		if(oPrev)
			goPrevParent=getParentNode(oPrev);
	}
	gbAveButttnInited=true;
}

function disableAveButton()
{
	initAveButtonObj();
	if(goNextParent)
		disableButton(goNextParent,goNext);
	if(goPrevParent)
		disableButton(goPrevParent,goPrev);
}

function disableButton(oEl,oBtn)
{
	setState(oEl,"disable");
	var sPF=oEl.className.substring(0,6);
	oEl.className=sPF+"Disable";
	var oAs = getElementsByTag(oEl,"a");
	if (oAs.length>0)
	{
		oAs[0].style.cursor="default";
	}
	var oIs=getElementsByTag(oEl,"img");
	if(oIs.length>0&&oBtn&&oBtn.aIs&&oBtn.aIs.length>3)
	{
		if(oBtn.aIs[3])
			oIs[0].src=oBtn.aIs[3];
	}
	else
		oEl.style.visibility="hidden";
}

function enableButton(oEl,oBtn)
{
	setState(oEl,"normal");
	if(oEl==goEl)
	{
		var sPF=oEl.className.substring(0,6);
		oEl.className=sPF+"Up";
	}
	var oAs = getElementsByTag(oEl,"a");
	if (oAs.length>0)
	{
		oAs[0].style.cursor="hand";
	}
	var oIs=getElementsByTag(oEl,"img");
	if(oIs.length>0&&oBtn&&oBtn.aIs&&oBtn.aIs.length>0)
	{
		if(oBtn.aIs[0])
			oIs[0].src=oBtn.aIs[0];
	}
	oEl.style.visibility="visible";
}

function updateAveButton()
{
	initAveButtonObj();	
	var strAveName=getCurrentAvenue();
	if(strAveName!="")
	{
		if(gaAvenues)
		{
			for(var i=0;i<gaAvenues.length;i++)
			if(gaAvenues[i].sName==strAveName)
			{
				if(goNextParent)
				{
					if(gaAvenues[i].sNext!=null&&gaAvenues[i].sNext!="")
						enableButton(goNextParent,goNext);
					else
						disableButton(goNextParent,goNext);
				}
				if(goPrevParent)
				{
					if(gaAvenues[i].sPrev!=null&&gaAvenues[i].sPrev!="")
						enableButton(goPrevParent,goPrev);
					else
						disableButton(goPrevParent,goPrev);
				}	
				break;
			}
		}
	}
	else
	{
		var bNext=false;
		var bPrev=false;
		if(gaAvenues&&gaAvenues.length>0)
		{
			for(var i=0;i<gaAvenues.length&&(!bNext||!bPrev);i++)
			{
				if(!bNext)
					if(gaAvenues[i].sNext!=null&&gaAvenues[i].sNext!="")
						bNext=true;	
				if(!bPrev)
					if(gaAvenues[i].sPrev!=null&&gaAvenues[i].sPrev!="")
						bPrev=true;	
			}
		}
		if(goNextParent)
		{
			if(bNext)
				enableButton(goNextParent,goNext);
			else
				disableButton(goNextParent,goNext);
		}
		
		if(goPrevParent)
		{
			if(bPrev)
				enableButton(goPrevParent,goPrev);
			else
				disableButton(goPrevParent,goPrev);
		}
	}
	
}

function isValidAvenue(aAvenues,sValue)
{
	if(aAvenues)
	{
		for(var i=0;i<aAvenues.length;i++)
		{
			if(aAvenues[i].sName==sValue)
				return true;
		}
	}
	return false;
}

function getAvenueHTML(aAvenues)
{
	var sSelect="<select id=\"avenue\" size=\"1\" name=\"avenue\" onchange=\"updateAveButton();\">";
	sSelect+="<option value=\"\" selected> - Select Avenue - </option>";
	if(aAvenues)
	{
		for(var i=0;i<aAvenues.length;i++)
		{
			sSelect+="<option value=\""+aAvenues[i].sName+"\">"+aAvenues[i].sName+"</option>";
		}
	}
	sSelect+="</select>";
	return sSelect;
}

function addAvenueSelection()
{
	var oMsg=new whMessage(WH_MSG_GETAVIAVENUES,this,1,new Object());
	var sButton="";
	if(SendMessage(oMsg))
	{
		sButton=getAvenueHTML(oMsg.oParam.aAvenues);
	}
	else
	{
		sButton=getAvenueHTML(null);
	}
	gaButtons[gaButtons.length]="<td NOWRAP align=\"center\" valign=\"middle\">"+sButton+"</td>";
}

function setSearchFormTitle(sTitle)
{
	gsSearchFormTitle=sTitle;
}

function highLightIfNeeded()
{
	if(document.searchForm.searchString.value==gsSearchPrompt)
	{
		document.searchForm.searchString.select();
	}
}

function addSearchForm()
{
	var sPropmptString=gsSearchPrompt;

	var nWidth=20;
	if(!nWidth) nWidth=20;
	if(gbNav4) nWidth=nWidth*.6;

	if(gsSearchFormTitle)
		sPropmptString="";
	var sButton="<table id=\"searchInput\" CELLSPACING=0 CELLPADDING=1><tr><td valign=\"middle\" NOWRAP class=\"clsNotBtn\"><span class=\"btnsearchform\">"+_textToHtml(gsSearchFormTitle)+"</span></td><td NOWRAP valign=\"middle\"><input class=\"inputsearchform\" type=\"text\" onfocus=\"highLightIfNeeded();\" name=\"searchString\" value=\""+sPropmptString+"\" size=\""+nWidth+"\"></td>";
	if(gbNav6)
		sButton="<form id=\"searchInput\" name=\"searchForm\" method=\"POST\" action=\"javascript:searchB()\">"+sButton;
	if("image"=="text")
	{
		sButton+="<td NOWRAP valign=\"middle\"><a class=\"searchbtn\" href=\"javascript:void(0);\" onclick=\"searchForm.submit(); return false;\"></a></td>";
	}
	else if("image"=="image"&&gsIGo)
	{
		sButton+="<td NOWRAP valign=\"middle\"><a class=\"searchbtn\" href=\"javascript:void(0);\" onclick=\"searchForm.submit(); return false;\">"
		sButton+="<img alt=\"Go\" src=\""+gsIGo+"\" border=0 align=\"absmiddle\"></a></td>";
	}
	sButton+="</tr></table>";
	if(gbNav6)
		sButton+="</form>";
	var nBtn=gaButtons.length;
	gaButtons[nBtn]="<td NOWRAP align=\"center\" valign=\"middle\">"+sButton+"</td>";
	gaTypes[nBtn]="searchform";
}

function getShowHide()
{
	var sText="";
	var sI="";
	if(hasNavPane())
	{
		if(goHide)
		{
			if(gnShowHideStyle&BTN_TEXT)
				sText=goHide.sText;
			if(gnShowHideStyle&BTN_IMG)
			sI=getImage(goHide,"Hide");
		}
	}
	else
	{
		if(goShow)
		{
			if(gnShowHideStyle&BTN_TEXT)
				sText=goShow.sText;
			if(gnShowHideStyle&BTN_IMG)
				sI=getImage(goShow,"Show");
		}
	}
	var sButton=genButton(sText,sI,gnShowHideStyle);
	return sButton;
}

function addBanner(sImage)
{
	if(sImage)
	{
		var nBtn=gaButtons.length;
		gaButtons[nBtn]="<td NOWRAP align=\"center\" valign=\"middle\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href=\"javascript:void(0);\" onclick=\"showBanner();return false;\"><img alt=\"About WebHelp\"src=\""+sImage+"\" border=0 align=\"absmiddle\"></a></td>";
		gaTypes[nBtn]="banner";
	}
}

function showBanner()
{
	if (!gbPreview)
	{
		var nWidth=390;
		var nHeight=204;
		var	nScreenWidth=screen.width;
		var	nScreenHeight=screen.height;
		var nLeft=(nScreenWidth-nWidth)/2;
		var nTop=(nScreenHeight-nHeight)/2;
		if (gbIE4)
		{
			if (gbIE5)
				nHeight+=20;
			else
				nHeight+=40;
			window.showModalDialog("whskin_banner.htm","","dialogHeight:"+nHeight+"px;dialogWidth:"+nWidth+"px;resizable:no;status:no;scroll:no;help:no;center:yes;");
		}
		else
			window.open("whskin_banner.htm","banner","dependent,innerHeight="+nHeight+",innerWidth="+nWidth+",height="+nHeight+",width="+nWidth+",resizable=no,menubar=no,location=no,personalbar=no,status=no,scrollbar=no,toolbar=no,screenX="+nLeft+",screenY="+nTop);
	}
}

function showHelpSystem(id)
{
       var strURL = document.getElementById(id).value;
       if(strURL != "")
       {
              if(top.frames.length > 0 && top.frames[0].name == "ContentFrame")
                     top.frames[0].location = document.getElementById(id).value;
              else
                     top.location = document.getElementById(id).value;
       }
}

function addButton(sType,nStyle,sTitle,sHref,sOnClick,sOnMouseOver,sOnLoad,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6)
{
	var sButton="";
	var bMini=false;
	var sText="";
	var sI="";
	var bState=false;
	var nBtn=gaButtons.length;
	var bHref=false;
	if(sType=="show"&&isShowHideEnable())
	{
		var svTitle="Show Navigation Component";
		sButton="<a title=\""+svTitle+"\" id=\"btnshowhide\" class=\"btnshow\" href=\"javascript:void(0);\" onclick=\"showHidePane();return false;\">";
		gnShowHideStyle=nStyle;
		goShow=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3);
		gaObjBtns[nBtn]=goShow;
		if(gnShowHide!=-1)
		{
			nBtn=gnShowHide;
		}
		else
		{
			gnShowHide=nBtn;
		}
		sButton+=getShowHide();
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="hide"&&isShowHideEnable())
	{
		var svTitle="Hide Navigation Component";
		sButton="<a title=\""+svTitle+"\" id=\"btnshowhide\" class=\"btnhide\" href=\"javascript:void(0);\" onclick=\"showHidePane();return false;\">";
		gnShowHideStyle=nStyle;
		goHide=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3);
		gaObjBtns[nBtn]=goHide;
		if(gnShowHide!=-1)
		{
			nBtn=gnShowHide;
		}
		else
		{
			gnShowHide=nBtn;
		}
		sButton+=getShowHide();
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="hide2")
	{
		var svTitle="Hide Navigation Component";
		sButton="<a title=\""+svTitle+"\" id=\"btnhide\" class=\"btnhide\" href=\"javascript:void(0);\" onclick=\"showHidePane();return false;\">";
		gnShowHideStyle=nStyle;
		if(!sI1)
			sI1=gsIHide;
		goHide2=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3);
		gaObjBtns[nBtn]=goHide2;
		if(nStyle&BTN_TEXT)
			sText=goHide2.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goHide2,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bMini=true;
	}
	else if(sType=="synctoc")
	{
		var svTitle="Sync TOC";
		sButton="<a title=\""+svTitle+"\" id=\"btnsynctoc\" class=\"btnsynctoc\" href=\"javascript:void(0);\" onclick=\"syncWithShow();return false;\">";
		if(!sI1)
			sI1=gsISync;
		goSync=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3);
		gaObjBtns[nBtn]=goSync;
		if(nStyle&BTN_TEXT)
			sText=goSync.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goSync,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bMini=true;
	}
	else if(sType=="toc")
	{
		var svTitle="Contents";
		sButton="<a title=\""+svTitle+"\" id=\"btntoc\" class=\"btntoc\" href=\"javascript:void(0);\" onclick=\"showToc();return false;\">";
		if(!sI1)
			sI1=gsIToc;
		if(!sI2)
			sI2=gsITocS;
		if(!sI4)
			sI4=gsITocS;
		goToc=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goToc;
		if(nStyle&BTN_TEXT)
			sText=goToc.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goToc,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="rolesel")
	{
		var svTitle="Select a content category";
		var contentListPath = "contentlist.xml";
		var xmlreader = new XmlReadWriteHelper();
		xmlreader.strFilePath = contentListPath;
		xmlreader.loadFromFile(false);
		var xmlDoc = xmlreader.getXmlDoc();
		if(xmlDoc != null)
		{
			sButton="<select title=\""+svTitle+"\" style=\"background-color:"+gsBgColor+";\" id=\"selectRole\" name=\"selectRole\" class=\"btnrolesel\" size=\"1\" onchange=\"showHelpSystem(this.id)\">";

			var elemNode = xmlDoc.getElementsByTagName("content");
			for(i=0; i< elemNode.length; i++)
			{
				var name= elemNode[i].getAttribute("name");
				var value = elemNode[i].getAttribute("value");
				var selected = elemNode[i].getAttribute("selected");
				if(selected == null)
					sButton += "<option value=\""+ value +"\">"+ name +"</option>";
				else
					sButton += "<option value=\""+ value +"\" selected=\"selected\">"+ name +"</option>";
			}
			sButton+="</select>";
			goRole=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3);
			gaObjBtns[nBtn]=goRole;
			bMini=true;
		}
		delete xmlreader;
	}
	else if(sType=="idx")
	{
		var svTitle="Index";
		sButton="<a title=\""+svTitle+"\" id=\"btnidx\" class=\"btnidx\" href=\"javascript:void(0);\" onclick=\"showIndex();return false;\">";
		if(!sI1)
			sI1=gsIIndex;
		if(!sI2)
			sI2=gsIIndexS;
		if(!sI4)
			sI4=gsIIndexS;
		goIdx=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goIdx;
		if(nStyle&BTN_TEXT)
			sText=goIdx.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goIdx,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="fts")
	{
		var svTitle="Search";
		sButton="<a title=\""+svTitle+"\" id=\"btnfts\" class=\"btnfts\" href=\"javascript:void(0);\" onclick=\"showFts();return false;\">";
		if(!sI1)
			sI1=gsISearch;
		if(!sI2)
			sI2=gsISearchS;
		if(!sI4)
			sI4=gsISearchS;
		goFts=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goFts;
		if(nStyle&BTN_TEXT)
			sText=goFts.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goFts,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="glo")
	{
		var svTitle="Glossary";
		sButton="<a title=\""+svTitle+"\" id=\"btnglo\" class=\"btnglo\" href=\"javascript:void(0);\" onclick=\"showGlossary();return false;\">";
		if(!sI1)
			sI1=gsIGlossary;
		if(!sI2)
			sI2=gsIGlossaryS;
		if(!sI4)
			sI4=gsIGlossaryS;
		goGlo=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goGlo;
		if(nStyle&BTN_TEXT)
			sText=goGlo.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goGlo,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bState=true;
	}
	else if(sType=="avnext")
	{
		var svTitle="Next Topic";
		sButton="<a title=\""+svTitle+"\" id=\"btnavnext\" class=\"btnavnext\" href=\"javascript:void(0);\" onclick=\"goAveNext();return false;\">";
		if(!sI1)
			sI1=gsINext;
		if(!sI4)
			sI4=gsINextD;
		goNext=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goNext;
		if(nStyle&BTN_TEXT)
			sText=goNext.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goNext,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bMini=true;
	}
	else if(sType=="avprev")
	{
		var svTitle="Previous Topic";
		sButton="<a title=\""+svTitle+"\" id=\"btnavprev\" class=\"btnavprev\" href=\"javascript:void(0);\" onclick=\"goAvePrev();return false;\">";
		if(!sI1)
			sI1=gsIPrev;
		if(!sI4)
			sI4=gsIPrevD;
		goPrev=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goPrev;
		if(nStyle&BTN_TEXT)
			sText=goPrev.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goPrev,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
		bMini=true;
	}
	else if(sType=="blankblock")
	{
		gaButtons[nBtn]=null;
		gaTypes[nBtn]=sType;
	}
	else if(sType=="websearch")
	{
		var svTitle="WebSearch";
		sButton="<a title=\""+svTitle+"\" id=\"btnwebsearch\" class=\"btnwebsearch\" href=\"javascript:void(0);\" onclick=\"doWebSearch();return false;\">";
		if(!sI1)
			sI1=gsIWebSearch;
		if(!sI4)
			sI4=gsIWebSearchD;
		goWebSearch=new button(sType,sTitle,nWidth,nHeight,sI1,sI2,sI3,sI4,sI5,sI6);
		gaObjBtns[nBtn]=goWebSearch;
		if(nStyle&BTN_TEXT)
			sText=goWebSearch.sText
			
		if(nStyle&BTN_IMG)
			sI=getImage(goWebSearch,svTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
	}
	else if(sType.indexOf("custom")==0)
	{
		var nCusBtnIdx=goCusButton.length;
		goCusButton[nCusBtnIdx]=new cusButton(sType,sTitle,sOnClick,sOnMouseOver,sOnLoad,nWidth,nHeight,sI1,sI2,sI3);
		gaObjBtns[nBtn]=goCusButton[nCusBtnIdx];
		var re=new RegExp("\"","g");
		var svTitle=sTitle.replace(re, "&quot;");
		if(sHref&&sHref.length!=0)
		{
			sButton="<a title=\""+svTitle+"\" id=\"btn"+sType+"\" class=\"btn"+sType+"\" target=\"bsscright\" href=\""+sHref+"\" onclick=\"cusOnClick("+nCusBtnIdx+");";
			bHref=true;
		}
		else
			sButton="<a title=\""+svTitle+"\" id=\"btn"+sType+"\" class=\"btn"+sType+"\" href=\"javascript:void(0);\" onclick=\"cusOnClick("+nCusBtnIdx+");return false;";
		sButton+="\" onmouseover=\"cusOnMouseOver("+nCusBtnIdx+");\" title=\""+sType+"\">";
		if(nStyle&BTN_TEXT)
			sText=sTitle;
		if(nStyle&BTN_IMG)
			sI+=getImage(goCusButton[nCusBtnIdx],sTitle);
		sButton+=genButton(sText,sI,nStyle);
		sButton+="</a>";
	}
	if(sButton.length!=0)
	{
		var btnClass="";
		if(sText||bMini)
			btnClass="clsBtnNormal";
		else
			btnClass="clsNoBNormal";

		if(!bState)
		{
			if(bHref)
				gaButtons[nBtn]="<td NOWRAP valign=\"middle\" align=\"center\" class="+btnClass+" onclick=\"onBtnClick(event);\" onmousedown=\"onBtnMouseDown(event, "+nBtn+");\" onmouseup=\"onBtnMouseUp(event, "+nBtn+");\" onmouseover=\"onBtnMouseOver(event, "+nBtn+");\" onmouseout=\"onBtnMouseOut(event, "+nBtn+");\">"+sButton+"</td>";
			else
				gaButtons[nBtn]="<td NOWRAP valign=\"middle\" align=\"center\" class="+btnClass+" onclick=\"onBtnClick(event);return false;\" onmousedown=\"onBtnMouseDown(event, "+nBtn+");\" onmouseup=\"onBtnMouseUp(event, "+nBtn+");\" onmouseover=\"onBtnMouseOver(event, "+nBtn+");\" onmouseout=\"onBtnMouseOut(event, "+nBtn+");\">"+sButton+"</td>";
		}
		else
			gaButtons[nBtn]="<td NOWRAP valign=\"middle\" align=\"center\" class="+btnClass+" state=\"up\" onclick=\"onBtnClick(event);return false;\" onmousedown=\"onBtnMouseDown(event, "+nBtn+");\" onmouseup=\"onBtnMouseUp(event, "+nBtn+");\" onmouseover=\"onBtnMouseOver(event, "+nBtn+");\" onmouseout=\"onBtnMouseOut(event, "+nBtn+");\">"+sButton+"</td>";
		gaTypes[nBtn]=sType;
	}

	if(sType=="avenuesel")
		addAvenueSelection();
	else if(sType=="searchform")
		addSearchForm();
	else if(sType=="banner")
	{
		if(!sI1)
			sI1=gsIBanner;
		addBanner(sI1);
	}
}

function isShowHideEnable()
{
	if(gbIE4)
		return true;
	else
		return false;
}

function genButton(sText,sI,nStyle)
{
	var sButton="";
	var sShowText=_textToHtml(sText);
	if (gbNav4 && !gbNav6)
		sShowText += "&nbsp;";
	if(sText!=""&&sI!="")
	{
		if(nStyle&BTN_IMG_TOP)
			sButton+=sI+"<br>"+ sShowText;
		else if(nStyle&BTN_IMG_BOTTOM)
			sButton+=sText+"<br>"+sI;
		else if(nStyle&BTN_IMG_RIGHT)
			sButton+=sText+"&nbsp;"+sI;
		else
			sButton+=sI+"&nbsp;"+sShowText;
	}
	else if(sText!="")
	{
		sButton+=sShowText;
	}
	else if(sI!="")
	{
		sButton+=sI;
	}
	return sButton;
}

function searchB()
{
	var onMsg=new whMessage(WH_MSG_SHOWFTS,this,1,null);
	SendMessage(onMsg);

	var oMsg=new whMessage(WH_MSG_SEARCHTHIS,this,1,document.searchForm.searchString.value);
	if(!SendMessage(oMsg))
		gstrSearch=document.searchForm.searchString.value;
	else
		gstrSearch="";
}

function ReSortToolbarButtons()
{
	var bSearchEnabled=isSearchEnabled();
	var strOrder="";
	var oMsg=new whMessage(WH_MSG_TOOLBARORDER,this,1,null);
	if(SendMessage(oMsg))
	{
		strOrder=oMsg.oParam;
	}
	if(strOrder.length>0)
	{
		gaOrders=strOrder.split("|");
		var aTempButtons=new Array();
		var ti=0;
		for(var si=0;si<gaOrders.length;si++)
		{
			if(gaOrders[si]!="searchform"||bSearchEnabled)
			{
				var sb=-1;
				for(var st=0;st<gaTypes.length;st++)
				{
					if(gaOrders[si]==gaTypes[st])
					{
						sb=st;
						break;
					}
				}
				if(sb!=-1)
				{
					aTempButtons[aTempButtons.length]=gaButtons[sb];
				}
			}
		}
		gaButtons=aTempButtons;
	}
}

function isSyncEnabled()
{
	var bEnabled=false;
	var oMsg=new whMessage(WH_MSG_ISSYNCSSUPPORT,this,1,null);
	if(SendMessage(oMsg))
	{
		bEnabled=oMsg.oParam;
	}
	return bEnabled;
}

function isAvenueEnabled()
{
	var bEnabled=false;
	var oMsg=new whMessage(WH_MSG_ISAVENUESUPPORT,this,1,null);
	if(SendMessage(oMsg))
	{
		bEnabled=oMsg.oParam;
	}
	return bEnabled;
}

function isSearchEnabled()
{
	var bEnabled=false;
	var oMsg=new whMessage(WH_MSG_ISSEARCHSUPPORT,this,1,null);
	if(SendMessage(oMsg))
	{
		bEnabled=oMsg.oParam;
	}
	return bEnabled;
}

function ReSortMinibarButtons()
{
	var bSyncEnabled=isSyncEnabled();
	var bAvenueEnabled=isAvenueEnabled();
	var strOrder="";
	var oMsg=new whMessage(WH_MSG_MINIBARORDER,this,1,null);
	if(SendMessage(oMsg))
	{
		strOrder=oMsg.oParam;
	}
	if(strOrder.length>0)
	{
		gaOrders=strOrder.split("|");
		var aTempButtons=new Array();
		var ti=0;
		for(var si=0;si<gaOrders.length;si++)
		{
			if((gaOrders[si]!="synctoc"||bSyncEnabled)&&
				((gaOrders[si]!="avnext"&&gaOrders[si]!="avprev")||bAvenueEnabled))
			{
				var sb=-1;
				for(var st=0;st<gaTypes.length;st++)
				{
					if(gaOrders[si]==gaTypes[st])
					{
						sb=st;
						break;
					}
				}
				if(sb!=-1)
				{
					aTempButtons[aTempButtons.length]=gaButtons[sb];
				}
			}
		}
		gaButtons=aTempButtons;
	}
}

function writeToolBar()
{
	var sHTML="";
	if(gaButtons.length>0)
	{
		var strHeight="100%";
		var strWidth="100%";
		if (gbNav4)
		{
			strHeight=window.innerHeight-4;
			strWidth=window.innerWidth-4;
		}
		if (gbIE4)
		{
			strHeight=document.body.clientHeight-4;
			strWidth=document.body.clientWidth-4;
		}
		if(gbNav6)
			sHTML="<table class=\"clsToolbarBackground\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" height=\""+strHeight+"\" width=\""+strWidth+"\">";
		else
			sHTML="<form name=\"searchForm\" method=\"POST\" action=\"javascript:searchB()\"><table class=\"clsToolbarBackground\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\" height=\""+strHeight+"\" width=\""+strWidth+"\">";
		if((gnButtonLayout&LAYOUT)==HLAYOUT)
		{
			sHTML+="<tr>";
			for(var i=0;i<gaButtons.length;i++)
			{
				if(gaButtons[i])
					sHTML+=gaButtons[i];
				else
					sHTML+="<td width=\"100%\"></td>";
			}
			sHTML+="</tr>";
		}
		else
		{
			for(var i=0;i<gaButtons.length;i++)
			{
				if(gaButtons[i])
					sHTML+="<tr width=\"100%\">"+gaButtons[i]+"</tr>";
				else
					sHTML+="<tr height=\"100%\"><td></td></tr>";
			}
		}
		if(gbNav6)
			sHTML+="</table>";
		else
			sHTML+="</table></form>";
	}
	document.write(sHTML);
	if(document.body)
		document.body.onselectstart=onSelect;
	updateAveButton();
}

function hasNavPane()
{
	if(gnHasNavPane==-1)
	{
		gnHasNavPane=0;
		var oParam=new Object();
		oParam.bVisible=false;
		var oMsg=new whMessage(WH_MSG_ISPANEVISIBLE,this,1,oParam);
		if(SendMessage(oMsg))
		{
			if(oParam.bVisible)
				gnHasNavPane=1;
		}
		
	}
	if(gnHasNavPane==1)
		return true;
	else
		return false;
}

function getTocInfo()
{
	var oParam=new Object();
	oParam.oTocInfo=null;
	var oMsg=new whMessage(WH_MSG_GETTOCPATHS,this,1,oParam);
	if(SendMessage(oMsg))
	{
		goTocInfo=oParam.oTocInfo;
		gbTocInfoInited=true;
	}
}

function onBtnClick(e)
{
	var oEl=null;
	var oElo=null;
	if(gbNav6)
	{
		oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
	{
		oElo=event.srcElement;
		oEl=oElo;
		event.cancelBubble=true;
	}
	while(-1==oEl.className.indexOf("clsBtn")&&-1==oEl.className.indexOf("clsNoB"))
	{
		oEl=getParentNode(oEl);
		if(!oEl) return;
	}
	if(oElo.tagName=="A"||oElo.tagName=="IMG") return true;
	var oaA=getElementsByTag(oElo,"A");
	if(oaA&&oaA.length)
	{
		var oA=oaA[0];
		if(gbNav6)
		{
			var sCmd=oA.getAttribute("onclick");
			var nCmd=sCmd.indexOf("return false;");
			if(nCmd!=-1);
				sCmd=sCmd.substring(0,nCmd);
			setTimeout(sCmd,1);
		}
		else
			oA.onclick();
	}
}

function onBtnMouseDown(e,nBtn)
{
	var oEl=null;
	if(gbNav6)
	{
		var oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
	{
		oEl=event.srcElement;
		event.cancelBubble=true;
	}
	while(-1==oEl.className.indexOf("clsBtn")&&-1==oEl.className.indexOf("clsNoB"))
	{
		oEl=getParentNode(oEl);
		if(!oEl) return;
	}
	var sPF=oEl.className.substring(0,6);
	var oIs=getElementsByTag(oEl,"img");
	if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>2)
	{
		if(gaObjBtns[nBtn].aIs[2])
			oIs[0].src=gaObjBtns[nBtn].aIs[2];
	}
	var sState=getState(oEl);
	if(sState!="disable")
	{
		oEl.className=sPF+"Down";
	}
}

function onBtnMouseUp(e,nBtn)
{
	var oEl=null;
	if(gbNav6)
	{
		var oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
	{
		oEl=event.srcElement;
		event.cancelBubble=true;
	}
	while(-1==oEl.className.indexOf("clsBtn")&&-1==oEl.className.indexOf("clsNoB"))
	{
		oEl=getParentNode(oEl);
		if(!oEl) return;
	}
	var sPF=oEl.className.substring(0,6);
	var sState=getState(oEl);
	if(sState=="down"||sState=="disable")
	{
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>3)
		{
			if(gaObjBtns[nBtn].aIs[3])
				oIs[0].src=gaObjBtns[nBtn].aIs[3];
		}
	}
	else
	{
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>0)
		{
			if(gaObjBtns[nBtn].aIs[0])
				oIs[0].src=gaObjBtns[nBtn].aIs[0];
		}
	}
	if(goEl==oEl)
	{
		if(sState!="down"&&sState!="disable")
		{
			oEl.className=sPF+"Up";
		}
	}
}

function getState(oEl)
{
	var sState="";
	if(gbNav6||gbOpera)
		sState=oEl.getAttribute("state");
	else
		if(oEl.state)
			sState=oEl.state;
	return sState;
}

function onBtnMouseOver(e,nBtn)
{
	markButton(e);
	var oEl=null;
	if(gbNav6)
	{
		var oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
	{
		oEl=event.srcElement;
		event.cancelBubble=true;
	}
	while(-1==oEl.className.indexOf("clsBtn")&&-1==oEl.className.indexOf("clsNoB"))
	{
		oEl=getParentNode(oEl);
		if(!oEl) return;
	}
	var sPF=oEl.className.substring(0,6);
	var sState=getState(oEl);
	if(sState=="down"||sState=="disable")
	{
		if(sState=="down")
			oEl.className=sPF+"Down";
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>4)
		{
			if(gaObjBtns[nBtn].aIs[4])
				oIs[0].src=gaObjBtns[nBtn].aIs[4];
		}
	}
	else
	{
		oEl.className=sPF+"Up";
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>1)
		{
			if(gaObjBtns[nBtn].aIs[1])
				oIs[0].src=gaObjBtns[nBtn].aIs[1];
		}
	}
}

function onBtnMouseOut(e,nBtn)
{
	goEl=null;
	var oEl=null;
	if(gbNav6)
	{
		var oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
	{
		oEl=event.srcElement;
		event.cancelBubble=true;
	}
	while(-1==oEl.className.indexOf("clsBtn")&&-1==oEl.className.indexOf("clsNoB"))
	{
	oEl=getParentNode(oEl);
	if(!oEl) return;
	}
	var sPF=oEl.className.substring(0,6);
	var sState=getState(oEl);
	if(sState=="down"||sState=="disable")
	{
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>3)
		{
			if(gaObjBtns[nBtn].aIs[3])
				oIs[0].src=gaObjBtns[nBtn].aIs[3];
		}
		if(sState=="down")
			oEl.className=sPF+"Down";
	}
	else
	{
		var oIs=getElementsByTag(oEl,"img");
		if(oIs.length>0&&gaObjBtns[nBtn]&&gaObjBtns[nBtn].aIs&&gaObjBtns[nBtn].aIs.length>0)
		{
			if(gaObjBtns[nBtn].aIs[0])
				oIs[0].src=gaObjBtns[nBtn].aIs[0];
		}
		oEl.className=sPF+"Normal";
	}
}

function showToc()
{
	var oMsg=new whMessage(WH_MSG_SHOWTOC,this,1,null)
	SendMessage(oMsg);
}

function showIndex()
{
	var oMsg=new whMessage(WH_MSG_SHOWIDX,this,1,null)
	SendMessage(oMsg);
}

function showFts()
{
	var oMsg=new whMessage(WH_MSG_SHOWFTS,this,1,null)
	SendMessage(oMsg);
}

function showGlossary()
{
	var oMsg=new whMessage(WH_MSG_SHOWGLO,this,1,null)
	SendMessage(oMsg);
}

function syncWithShow()
{
	if(!gbTocInfoInited)
	{
		getTocInfo();
	}
	if(goTocInfo)
	{
		showToc();
		var oParam=goTocInfo;
		var oMsg=new whMessage(WH_MSG_SYNCTOC,this,1,oParam);
		SendMessage(oMsg);
	}
}

function markButton(e)
{
	var oEl=null;
	if(gbNav6)
	{
		var oElo=e.target;
		while(oElo&&oElo.nodeName.indexOf("#")==0) oElo=getParentNode(oElo);
		oEl=oElo;
	}
	else
		oEl=event.srcElement;
	while(oEl&&oEl.tagName!="TD") oEl=getParentNode(oEl);
	if(oEl)
		goEl=oEl;
}

function showHidePane()
{
	var oMsg=null;
	if(hasNavPane())
		oMsg=new whMessage(WH_MSG_HIDEPANE,this,1,null);
	else
		oMsg=new whMessage(WH_MSG_SHOWPANE,this,1,null);
	SendMessage(oMsg);
}

function goAveNext()
{
	goAvenue(true);
}

function goAvePrev()
{
	goAvenue(false);
}

function doWebSearch()
{
	if (goWebSearchEnable)
	{
		var oMsg=new whMessage(WH_MSG_WEBSEARCH,this,1,null);
		SendMessage(oMsg);
	}
}

function goAvenue(bNext)
{
	var oMsg=null;
	initAveButtonObj();
	gsCurAveName=getCurrentAveName();
	if(gbNav4&&!gbNav6)
	{
		if(bNext)
		{
			gaAvenues=null;
			updateAvenue();
			oMsg=new whMessage(WH_MSG_NEXT,this,1,null);
			SendMessage(oMsg);
		}
		else if(!bNext)
		{
			gaAvenues=null;
			updateAvenue();
			oMsg=new whMessage(WH_MSG_PREV,this,1,null);
			SendMessage(oMsg);
		}
	}
	else
	{
		if(bNext&&goNextParent)
		{
			var sState=getState(goNextParent);
			if(sState!="disable")
			{
				gaAvenues=null;
				gbNeedUpdateAve=true;
				gbUpdateTimerCount++;
				setTimeout("updateAvenueIfNeeded();", 2000);
				oMsg=new whMessage(WH_MSG_NEXT,this,1,null);
				SendMessage(oMsg);
			}
		}
		else if(!bNext&&goPrevParent)
		{
			var sState=getState(goPrevParent);
			if(sState!="disable")
			{
				gaAvenues=null;
				gbNeedUpdateAve=true;
				gbUpdateTimerCount++;
				setTimeout("updateAvenueIfNeeded();", 2000);
				oMsg=new whMessage(WH_MSG_PREV,this,1,null);
				SendMessage(oMsg);
			}
		}
	}
}

function window_Unload()
{
	if(!gbNav4||gbNav6)
	{
		UnRegisterListener2(this,WH_MSG_GETSEARCHS);
		UnRegisterListener2(this,WH_MSG_PANESTATUE);
		UnRegisterListener2(this,WH_MSG_SYNCINFO);
		UnRegisterListener2(this,WH_MSG_PANEINFO);
		UnRegisterListener2(this,WH_MSG_AVENUEINFO);
		UnRegisterListener2(this,WH_MSG_GETCURRENTAVENUE);
		UnRegisterListener2(this,WH_MSG_ENABLEWEBSEARCH);
		UnRegisterListener2(this,WH_MSG_INITSEARCHSTRING);
		UnRegisterListener2(this,WH_MSG_NOSEARCHINPUT);
		UnRegisterListener2(this,WH_MSG_NOSYNC);
	}
}

function window_OnLoad()
{
	if(!gbOpera7&&document.body)
	{
		if(gsBgImage&&gsBgImage.length>0)
		{
			document.body.background=gsBgImage;
		}
		if(gsBgColor&&gsBgColor.length>0)
		{
			document.body.bgColor=gsBgColor;
		}
	}
	doCusOnLoad();
	var oMsg=new whMessage(WH_MSG_GETPANEINFO,this,1,null);
	if(SendMessage(oMsg))
	{
		setTimeout("flipPaneButton(\""+oMsg.oParam+"\");",1);
	}
	if (!gaAvenues)
	{
		var oMsg2=new whMessage(WH_MSG_GETAVIAVENUES,this,1,new Object());
		if(SendMessage(oMsg2))
		{
			gaAvenues=oMsg2.oParam.aAvenues;
			gbNeedUpdateAve=false;
			setTimeout("updateAvenue();",1);
		}
	}
}

function onSendMessage(oMsg)
{
	var nMsgId=oMsg.nMessageId;
	if(nMsgId==WH_MSG_GETSEARCHS)
	{
		if(document.searchForm&&document.searchForm.searchString)
		{
			oMsg.oParam.sValue=document.searchForm.searchString.value;
			return false;
		}
	}
	else if(nMsgId==WH_MSG_PANESTATUE)
	{
		if(oMsg.oParam=="visible")
		{
			if(isShowHideEnable())
				setTimeout("flipShowHide(true);",1);
			setTimeout("showPaneButton();",1);
		}
		else
		{
			if(isShowHideEnable())
				setTimeout("flipShowHide(false);",1);
			setTimeout("hidePaneButton();",1);
		}
	}
	else if(nMsgId==WH_MSG_PANEINFO)
	{
		if(oMsg.oParam)
			setTimeout("flipPaneButton(\""+oMsg.oParam+"\");",1);
		else
			setTimeout("hidePaneButton();",1);
	}
	else if(nMsgId==WH_MSG_SYNCINFO)
	{
		if(oMsg.oParam)
			goTocInfo=oMsg.oParam;
		else
			goTocInfo=null;
		gbTocInfoInited=true;
	}
	else if(nMsgId==WH_MSG_AVENUEINFO)
	{
		gaAvenues=oMsg.oParam;
		gbNeedUpdateAve=false;
		setTimeout("updateAvenue();",1);
	}
	else if(nMsgId==WH_MSG_GETCURRENTAVENUE)
	{
		var sAveName=getCurrentAvenue();
		if(sAveName!="")
		{
			oMsg.oParam.sAvenue=sAveName;
			return false;
		}
		else
			return true;
	}
	else if(nMsgId==WH_MSG_ENABLEWEBSEARCH)
	{
		setTimeout("updateWebSearch("+oMsg.oParam+");",1);
	}
	else if(nMsgId==WH_MSG_INITSEARCHSTRING)
	{
		if(gstrSearch!="")
		{
			oMsg.oParam=gstrSearch;
			gstrSearch="";
			return false;
		}
	}
	else if(nMsgId==WH_MSG_NOSEARCHINPUT)
	{
		var oSearchInput = getElement("searchInput");
		if (oSearchInput)
		{
			oSearchInput.style.visibility = "hidden";
			return false;
		}
	}
	else if(nMsgId==WH_MSG_NOSYNC)
	{
		var oSync = getElement("btnsynctoc");
		if (oSync)
		{
			oSync.style.visibility = "hidden";
			return false;
		}
	}
	return true;
}

function getCurrentAvenue()
{
	var strAveName="";
	var oSelect=getElement("avenue");
	if(oSelect)
	{
		strAveName=oSelect.value;
	}
	return strAveName;
}

function initBtn()
{
	var oBtn=null;
	oBtn=getElement("btntoc");
	if(oBtn)
		gaBtns[gaBtns.length]=oBtn;
	oBtn=getElement("btnidx");
	if(oBtn)
		gaBtns[gaBtns.length]=oBtn;
	oBtn=getElement("btnfts");
	if(oBtn)
		gaBtns[gaBtns.length]=oBtn;
	oBtn=getElement("btnglo");
	if(oBtn)
		gaBtns[gaBtns.length]=oBtn;
	gbInitBtn=true;
}

function showPaneButton()
{
	flipPaneButton(gsPane);
}

function hidePaneButton()
{
	flipPaneButton("");
}

function flipPaneButton(sPane)
{
	if (sPane)
		gsPane=sPane;
	if(!gbInitBtn)
		initBtn();

	var oUp=null;
	if(sPane)
	{
		oUp=getElement("btn"+sPane);
	}
	for(var i=0;i<gaBtns.length;i++)
	{
		if(gaBtns[i])
		{
			if(gaBtns[i]==oUp)
			{
				var oEl=getParentNode(oUp);
				var sPF=oEl.className.substring(0,6);
				var sState=getState(oEl);
				if(sState=="up")
				{
					setState(oEl,"down");
					oEl.className=sPF+"Down";
					if(sPF=="clsBtn")
					{
						if(gaBtns[i].id)
						{
							var sColor=getBtnColor(gaBtns[i].id.substring(3),true);
							if(sColor)
							{
								oEl.style.backgroundColor=sColor
							}
							else
							{
								oEl.style.backgroundColor="";
							}
						}
						var oaA=getElementsByTag(oEl,"A");
						if(oaA.length>0)
						{
							var strClassName=oaA[0].className;
							oaA[0].className="btnsel"+strClassName.substring(3);
						}
					}
					var oIs=getElementsByTag(oEl,"img");
					var oBtn=getButtonObjByType(gaBtns[i].id.substring(3));
					if(oIs.length>0&&oBtn&&oBtn.aIs&&oBtn.aIs.length>3)
					{
						if(oBtn.aIs[3])
							oIs[0].src=oBtn.aIs[3];
					}
				}
			}
			else
			{
				var oEl=getParentNode(gaBtns[i]);
				var sState=getState(oEl);
				var sPF=oEl.className.substring(0,6);
				if(sState=="down")
				{
					setState(oEl,"up");
					if(oEl==goEl)
						oEl.className=sPF+"Up";
					else
						oEl.className=sPF+"Normal";

					if(sPF=="clsBtn")
					{
						if(gaBtns[i].id)
						{
							var sColor=getBtnColor(gaBtns[i].id.substring(3),false);
							if(sColor)
							{
								oEl.style.backgroundColor=sColor
							}
							else
							{
								oEl.style.backgroundColor="";
							}
						}

						var oaA=getElementsByTag(oEl,"A");
						if(oaA.length>0)
						{
							var strClassName=oaA[0].className;
							oaA[0].className="btn"+strClassName.substring(6);
						}
					}
					var oIs=getElementsByTag(oEl,"img");
					var oBtn=getButtonObjByType(gaBtns[i].id.substring(3));
					if(oIs.length>0&&oBtn&&oBtn.aIs&&oBtn.aIs.length>0)
					{
						if(oBtn.aIs[0])
							oIs[0].src=oBtn.aIs[0];
					}
				}
			}
		}
	}
}

function flipShowHide(bShow)
{
	gnHasNavPane=-1;	
	var oA=getElement("btnshowhide");
	if(oA)
	{
		var oEl=getParentNode(oA);
		var sPF=oEl.className.substring(0,6);
		if(oEl&&oEl.state)
		{
			if(bShow)
			{
				oEl.state="down";
				oEl.className=sPF+"Down";
			}
			else
			{
				oEl.state="up";
				
				if(oEl==goEl)
					oEl.className=sPF+"Up";
				else
					oEl.className=sPF+"Normal";
			}
		}
		oA.innerHTML=getShowHide();
	}
}

function cusOnClick(nIdx)
{
	if(goCusButton.length>nIdx)
	{
		var sOnClick=goCusButton[nIdx].sOnClick;
		if(sOnClick&&sOnClick.length>0)
		{
			if(!gbPreview)
				eval(sOnClick);
			return false;
		}
	}
	return true;
}

function cusOnMouseOver(nIdx)
{
	if(goCusButton.length>nIdx)
	{
		var sOnMouseOver=goCusButton[nIdx].sOnMouseOver;
		if(sOnMouseOver&&sOnMouseOver.length>0)
		{
			if(!gbPreview)
				eval(sOnMouseOver);
			return false;
		}
	}
	return true;
}

function doCusOnLoad()
{
	if(!gbPreview&&gaOrders)
	{
		for(var i=0;i<gaOrders.length;i++)
		{
			for(var j=0;j<gaOnLoads.length;j++)
			{
				if(gaOrders[i]==gaOnLoads[j].sType)
				{
					eval(gaOnLoads[j].sOnLoad);
					break;
				}
			}
		}
	}
}

function registerOnLoad(sOnLoad,sType)
{
	gaOnLoads[gaOnLoads.length]=new cusOnLoad(sType,sOnLoad);	
}

function cusOnLoad(sType,sOnLoad)
{
	this.sType=sType;
	this.sOnLoad=sOnLoad;
}

function cusButton(sType,sText,sOnClick,sOnMouseOver,sOnLoad,nWidth,nHeight)
{
	this.sType=sType;
	this.sText=sText;
	this.sOnClick=sOnClick;
	this.sOnMouseOver=sOnMouseOver;
	this.sOnLoad=sOnLoad;
	this.nWidth=nWidth;
	this.nHeight=nHeight;
	this.aIs=new Array();
	var i=0;
	while(cusButton.arguments.length>i+7)
	{
		if (cusButton.arguments[7+i])
			this.aIs[i]=_getFullPath(_getPath(document.location.href),cusButton.arguments[7+i]);
		else
			this.aIs[i]="";
		i++;
	}
	if(sOnLoad)
	{
		registerOnLoad(sOnLoad,sType);
	}
}

function getBtnColor(sType,bSel)
{
	var aBtnColors=null;
	if(bSel)
		aBtnColors=gaSelBtnBgColor;
	else
		aBtnColors=gaBtnBgColor;
	if(aBtnColors)
	{
		for(var i=0;i<aBtnColors.length;i++)
		{
			if(aBtnColors[i].sType==sType)
				return aBtnColors[i].sColor;
		}
	}
	return "";
}

function setButtonBgColor(sType,sColor,bSel)
{
	if(sColor)
	{
		var aBtnColors=null;
		if(bSel)
			aBtnColors=gaSelBtnBgColor;
		else
			aBtnColors=gaBtnBgColor;
		if(aBtnColors!=null)
		{
			for(var i=0;i<aBtnColors.length;i++)
			{
				if(aBtnColors[i].sType==sType)
				{
					aBtnColors[i].sColor=sColor;
					return;
				}
			}
			aBtnColors[aBtnColors.length]=new btnBgColor(sType,sColor);
		}
	}
}

function getDefaultButtonFont()
{
	var strFontStyle="";
	for(var i=0;i<gaTypes.length;i++)
	{
		strFontStyle+=".btnsel"+gaTypes[i]+"{"+getFontStyle(goSelTextFont)+"}";
		strFontStyle+=".btn"+gaTypes[i]+"{"+getFontStyle(goTextFont)+"}";
	}
	return strFontStyle;
}

function setButtonFont(sType,sFontName,sFontSize,sFontColor,sFontStyle,sFontWeight,sFontDecoration,bSel)
{
	if(sFontName)
	{
		var vFont=new whFont(sFontName,sFontSize,sFontColor,sFontStyle,sFontWeight,sFontDecoration);
		if(bSel)
			gsBtnStyle+=".btnsel"+sType+"{"+getFontStyle(vFont)+"}\n";
		else
			gsBtnStyle+=".btn"+sType+"{"+getFontStyle(vFont)+"}\n";
	}
	if (sType=="searchform"&&!bSel)
	{
		var vFont1=new whFont(sFontName,sFontSize,"black",sFontStyle,sFontWeight,sFontDecoration);
		gsBtnStyle+=".inputsearchform {" + getFontStyle(vFont1)+"}\n";
	}
}

function getButtonObjByType(sType)
{
	for(var i=0;i<gaObjBtns.length;i++)
	{
		if(gaObjBtns[i].sType==sType)
			return gaObjBtns[i];
	}
	return null;
}

function onSelect()
{
	if (event.srcElement&&event.srcElement.name)
	{
		if (event.srcElement.name=="searchString")
			return true;
	}
	return false;
}

function window_onResize()
{
	gnRE++;
	setTimeout("tryReload();", 100);
}

function tryReload()
{
	if (gnRE==1)
		document.location.reload();
	gnRE--;
}

if(window.gbWhUtil&&window.gbWhMsg&&window.gbWhVer&&window.gbWhProxy)
{
	RegisterListener2(this,WH_MSG_GETSEARCHS);
	RegisterListener2(this,WH_MSG_PANESTATUE);
	RegisterListener2(this,WH_MSG_SYNCINFO);
	RegisterListener2(this,WH_MSG_PANEINFO);
	RegisterListener2(this,WH_MSG_AVENUEINFO);
	RegisterListener2(this,WH_MSG_GETCURRENTAVENUE);
	RegisterListener2(this,WH_MSG_ENABLEWEBSEARCH);
	RegisterListener2(this,WH_MSG_INITSEARCHSTRING);
	RegisterListener2(this,WH_MSG_NOSEARCHINPUT);
	RegisterListener2(this,WH_MSG_NOSYNC);

	window.onload=window_OnLoad;
	window.onunload=window_Unload;
	window.onresize=window_onResize;
	goTextFont=new whFont("Verdana","8pt","#003063","normal","normal","none");
	goSelTextFont=new whFont("Verdana","8pt","white","normal","normal","none");
	gbWhTBar=true;
}
else
	document.location.reload();

