var Effect = {};
Effect.setAlpha = function(element, opacity){//设置透明度
	opacity=Math.round(opacity * 1000)/1000;
	var	style = getElement(element).style;
	style.opacity = style.MozOpacity = style.KhtmlOpacity = opacity / 100;
	style.filter = "alpha(opacity=" + opacity + ")";
}

Effect.clear = function(element){//清除指定元素的动画效果
	var	interval = ["size", "scroll", "move", "fade", "color"],
		index = interval.length;
	while(index--)
		clearInterval(getElement(element).effect[interval[index]]);
}

Effect.color = function(element, style, start, end, speed, callback){//颜色渐变：style:要改变的style属性 "color"或"backgroundColor"；start:初始颜色 如#000000；end:结束颜色 如#FFFFFF；speed:速度 1-100 越大越快；
	var speed=speed||10;
	end = Effect.hex2RGB(end);
	clearInterval(getElement(element).effect.color);
	element.effect.color = setInterval(function(){
		var	color = Effect.hex2RGB(start),
			index = 3;
		while(index--)
			color[index] = getEnd(color[index], end[index], speed);
		element.style[style] = start = Effect.RGB2hex(color);
		if("" + color == "" + end)
			getCallback(element, "color", callback);
	}, 10);
}

Effect.fade = function(element, start, end, speed, callback){//透明度渐变：start:开始透明度 0-100；end:结束透明度 0-100；speed:速度0.1-100
	var speed=speed||1;
	clearInterval(getElement(element).effect.fade);
	element.effect.fade = setInterval(function(){
		start = getEnd(start, end, speed);
		Effect.setAlpha(element, start);
		//Console.log("设置元素",element.id," 透明度到",element.style.opacity);
		if(start == end)
			getCallback(element, "fade", callback);
	}, 10);
}

Effect.move = function(element, position, speed, callback){//移动到指定位置，position:移动到指定left及top 格式{x:200, y:250}；speed:速度 1-100
	var speed=speed||10;
	var	start = Effect.getPosition(getElement(element));
	getSetInterval(element, "move", speed / 100, start, position, ["x", "y"], "setPosition", callback);
}

Effect.setPosition = function(element, position){//设置位置
	var	style = getElement(element).style;
	style.position = "absolute";
	style.left = Math.round(position.x) + "px";
	style.top = Math.round(position.y) + "px";
}

Effect.scroll = function(element, speed, callback){//窗口滚动到指定元素处：speed:速度 1-100
	var speed=speed||10;
	function scroll(position){
		return document.documentElement ? document.documentElement[position] : document.body[position];
	};
	var	start = Effect.getScroll(),
		end = {x:start.x, y:Math.min(Effect.getPosition(element).y, Math.max(scroll("offsetHeight"), document.body.offsetHeight) - Math.min(scroll("clientHeight"), document.body.clientHeight))};
	getSetInterval(getElement(effect), "scroll", speed / 100, start, end, ["x", "y"], "setScroll", callback ? function(){callback.call(element)} : null);
}

Effect.size = function(element, size, speed, callback){//长宽渐变：size:要改变到的尺寸 格式 {width:400, height:250}或{width:400}或{height:250}；speed:速度 1-100
	var speed=speed||2;
	var	start = Effect.getSize(getElement(element)),
		tmp = window.opera;
	if(!/msie/i.test(navigator.userAgent) || (tmp && parseInt(tmp.version()) >= 9)){//针对ie的border-content式盒模型，使用附加的$width、$height修正
		if(size.$width)
			start.width -= size.$width;
		if(size.$height)
			start.height -= size.$height;
		if(size.width$)
			size.width -= size.width$;
		if(size.height$)
			size.height -= size.height$;
	};
	element.style.overflow = "hidden";
	var arrStyle=[];
	if(size.width)arrStyle.push("width");
	if(size.height)arrStyle.push("height");
	getSetInterval(element, "size", speed / 100, start, size, arrStyle, "setSize", callback);
}

Effect.RGB2hex = function(color){//例Effect.RGB2hex([255, 0, 0])  返回 #FF0000
	function tmp(index){
		var	tmp = color[index].toString(16);
		return tmp.length == 1 ? "0" + tmp : tmp;
	};
	return "#" + tmp(0) + tmp(1) + tmp(2);
}
Effect.hex2RGB = function(color){//例Effect.RGB2hex("#FF0000")  返回 [255, 0, 0]
	function tmp(index){
		return color.charAt(index);
	};
	color = color.substring(1);
	if(color.length == 3)
		color = tmp(0) + tmp(0) + tmp(1) + tmp(1) + tmp(2) + tmp(2);
	return [parseInt(tmp(0) + tmp(1), 16), parseInt(tmp(2) + tmp(3), 16), parseInt(tmp(4) + tmp(5), 16)];
}

Effect.getPosition = function(element){//取元素坐标，如元素或其上层元素设置position relative，应该getpos(子元素).y-getpos(父元素).y
	return $E.getPosition(element);
}

Effect.getScroll = function(){
	function scroll(position, scroll){
		return (document.documentElement ? document.documentElement[position] : w[scroll] || document.body[position]) || 0;
	};
	return {x:scroll("scrollLeft", "pageXOffset"), y:scroll("scrollTop", "pageYOffset")};
}

Effect.setScroll = function(element, position){
	window.scrollTo(position.x, position.y);
}

Effect.getSize = function(element){
	return {width:element.offsetWidth, height:element.offsetHeight};
}

Effect.setSize = function(element, size){
	var	style = element.style;
	if(size.width)style.width = Math.round(size.width) + "px";
	if(size.height)style.height = Math.round(size.height) + "px";
}

function getCallback(element, interval, callback){
	clearInterval(element.effect[interval]);
	if(callback)
		callback.call(element);
};

function getElement(element){
	if(!element.effect)
		element.effect = {color:0, drag:{}, fade:0, move:0, scroll:0, size:0};
	return element;
};

function getEnd(x, y, speed){
	return x < y ? Math.min(x + speed, y) : Math.max(x - speed, y);
};

function getSetInterval(element, interval, speed, start, position, style, tmp, callback){
	clearInterval(element.effect[interval]);
	element.effect[interval] = setInterval(function(){
		for(i=0;i<style.length;i++){
			start[style[i]] += (position[style[i]] - start[style[i]]) * speed;
		}
		Effect[tmp](element, start);
		for(i=0;i<style.length;i++){
			if(Math.round(start[style[i]]) == position[style[i]]){
				if(i!=style.length-1)continue;
			}else{
				break;
			}
			Effect[tmp](element, position);
			getCallback(element, interval, callback);
		}

	}, 10);
};

Effect.NextID = 0;
Effect.initCtrlStyle = function(ele){
  ele = $(ele);
	if(!ele.InitCtrlStyleFlag){//避免多次初始化
		var eletype = ele.type;
	  switch (eletype) {
	  case 'textarea':
	    if (ele.disabled == true) {
	      ele.addClassName("disabled");
	    };
	    break;  
	  case 'text':
	  case 'password':
	  case '':
	  	ele.addClassName("inputText");
	    ele.onmouseenter = function() {
	      this.style.borderColor = "#00aaee";
	    };
	    ele.onmouseleave = function() {
	      this.style.borderColor = "";
	    };
	 
		ele.onfocusFunc=ele.onfocus;
	    ele.onfocus = function() {
				if (typeof (ele.onfocusFunc) == "function"){
					try{
						ele.onfocusFunc();
					} catch(e){}
				}
	      this.style.borderColor = "#ff8800";
		  this.addClassName("inputTextFocus");
	      this.onmouseenter = null;
	      this.onmouseleave = null;
	    };
	
	    ele.onblurFunc=ele.onblur;
	    ele.onblur = function() {
			if (typeof (ele.onblurFunc) == "function"){
				try{
					ele.onblurFunc();
				} catch(e){}
			}
	      this.style.borderColor = "";
		  this.removeClassName("inputTextFocus");
	      this.onmouseenter = function() {
	        this.style.borderColor = "#00aaee";
	      };
	      this.onmouseleave = function() {
	        this.style.borderColor = "";
	      };
	    };
	    if (ele.disabled == true) {
	      ele.addClassName("disabled");
	    };
	
	    break;
	  case 'submit':
	  case 'reset':
	  case 'button':
	  	if(ele.className==""&&!(/border|background/).test(ele.style.cssText)){//在没有定义class或没有定义background的情况下对按钮应用圆角样式
			ele.addClassName("inputButton");
			ele.hideFocus = true;
			if (ele.parentElement.tagName != "A") {
			  ele.outerHTML = "<a href='javascript:void(0);' ztype='zInputBtnWrapper' class='zInputBtn' hidefocus='true' tabindex='-1'>" + ele.outerHTML + "<\/a>";
			}
		}
	    break;
	  case 'checkbox':
	  	ele.addClassName("inputCheckbox");
	    break;
	  case 'radio':
	  	ele.addClassName("inputRadio");
	    break;
	  case 'file':
	  	ele.addClassName("inputFile");
	    break;
	  case 'image':
	 	 ele.addClassName("inputImage");
	    break;
	  default:
	    ;
	  }
	  ele.InitCtrlStyleFlag = true;
	}
}

//所有的控件初始代码都要写在一起，以提高性能
Effect.initChildren = function(ele){
	ele = $(ele);
	var arr = ele.$T("div");
	var sarr = [];
	arr.each(function(div){
		var ztype = $(div).$A("ztype");
		if(ztype&&ztype.toLowerCase()=="select"){
			Selector.initHtml(div);
			sarr.push(div);
		}
	});
	sarr.each(function(ele){
		try{
			Selector.initMethod(ele);
		}catch(ex){
			Console.log(ex);
		}
		if(ele.Items.length>10){
			$(ele.id+"_ul").style.height = "15em";
		}
	});
	arr = ele.$T("input").concat(ele.$T("textarea"));
	arr.each(Effect.initOneCtrl);
}

Effect.initOneCtrl = function(ele){
	Effect.initCtrlStyle(ele); //Gecko下也必须加上这个,不然以前的focus事件会被履盖
	DateTime.initCtrl(ele);
	Verify.initCtrl(ele);
}

Page.onReady(function(){
	Effect.initChildren(document.body);
},1);

/********************************************
IE6下，在“严格模式”下横向滚动条会同竖向滚动条一齐出现，以下代码修正此问题
1、页面载入时强制设置页面overflowX="hidden"
2、页面载入完成时，检查页面内容是否宽于窗口宽度，然则overflowX="auto"，出现横向滚动条
3、页面载入完成后50毫秒，再次检查是否需要出现横向滚动条
4、在ie6下页面尺寸变化时会激发window.resize事件，此时再次检查是否需要出现横向滚动条
********************************************/
if(window.frameElement && isIE6 && !isQuirks){
	var htmlDom=document.getElementsByTagName('HTML')[0];
	if(htmlDom.style.overflow=="")htmlDom.style.overflow="auto";
	if(htmlDom.style.overflowY=="")htmlDom.style.overflowY="auto";
	if(htmlDom.style.overflowX=="")htmlDom.style.overflowX="hidden";//1
}
Effect.scrollFixOnresize=false;
Effect.ie6ScrollFix=function(){
	if(isIE6 && !isQuirks){
		var htmlDom=document.getElementsByTagName('HTML')[0];
		var sw = Math.max(document.documentElement.scrollWidth, document.body.scrollWidth);
		if((window.frameElement&&sw<window.frameElement.offsetWidth+30)||(!window.frameElement&&sw<document.documentElement.clientWidth+30)){
			htmlDom.style.overflowX="hidden";
			if(!Effect.scrollFixOnresize){
				if(window.frameElement){
					onWindowResize(Effect.runIe6ScrollFix);//4
				}
				Effect.scrollFixOnresize==true;
			}
		}else{//2
			htmlDom.style.overflowX="auto";
		}
		var sh = Math.max(document.documentElement.scrollHeight, document.body.scrollHeight);
		if((window.frameElement&&sh > window.frameElement.offsetHeight)||(!window.frameElement&&sh>document.documentElement.clientHeight)){
			htmlDom.style.overflowY="scroll";
			htmlDom.style.overflowX="hidden";
		}else{
			htmlDom.style.overflowY="auto";
		}
	}
}
Effect.runIe6ScrollFix=function(){
	setTimeout(Effect.ie6ScrollFix, 50)//3
}
Page.onLoad(function(){
	Effect.ie6ScrollFix();
	Effect.runIe6ScrollFix();
},1);
