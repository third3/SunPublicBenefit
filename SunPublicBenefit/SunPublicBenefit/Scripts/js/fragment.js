(function($){
	var fragmentConfig = {
		container : '.img-flex',//显示容器
		line : 5,//多少行
		column : 10,//多少列
		width : $(window).width(),//显示容器的宽度
		height:$(window).height(),//显示容器的高度
		animeTime : 4000,//最长动画时间,图片的取值将在 animeTime*0.33 + animeTime*0.66之前取值 
		img : 'images/cy_ytuz.jpg'//图片路径
	};
	$(".box").animate({
		top:"50%"
	},3500);
	var fnName = 'fragmentImg';
	var _default = {};
	// alert(_default.height);
	window[fnName] = function(changeConfig){

		//判断传入的参数是否是一个对象类型
		if(typeof(changeConfig) == "object"){
			for( var n in changeConfig){
				//将changeConfig数组的值赋值给_default数组
				_default[n] = changeConfig[n];
				// console.log(_default[n]);
			}
		}
		//判断当前_default数组的中container属性是否有值
		if(!_default.container){

			alert('未选择显示容器(div.class or div#id)的类');
			return false;
		}
		//找到当前的选择器容器
		var container = $(_default.container);
			//在当前找到的容器中追加一个ul.clearfix标签和
			container.append("<ul class='clearfix'></ul>");
		//设置当前选择的容器的宽高
		container.css({
			width : _default.width,
			height:_default.height
		});
		//找到当前找到的容器下的ul标签
		var containerUl = container.find(" > ul");
		//_default.line*_default.column  代表着将要在ul标签下追加生成的li标签  多少行*多少列=li标签的个数
		for(var i = 0;i < (_default.line*_default.column);i++){
			//追加li标签元素
			containerUl.append("<li></li>");
		}	
		//找到ul标签下的li标签
		var	containerItem = containerUl.find("li");

		//加载图片
		//初始化图片
		var Img = new Image();
			//给图片的路径赋值为_default.img中的图片路径
			Img.src = _default.img;

		//图片加载完成时
		Img.onload = function(){
			//multiple  表示当前容器的宽度/当前初始化的图片的宽度
			// var multiple = container.width() / Img.width,
				// multiples = container.height() /Img.height,
				var
				//获取当前容器的宽高然后对应的赋值
				width = $(window).width(),
				height = $(window).height(),

				//获取当前对应li的宽高然后对应的赋值
				findWidth = width/_default.column,
				findHeight = height/_default.line;

				//获取当前显示器的宽高然后对应的赋值
			var windowWidth = screen.width,
				windowHeight = screen.height;

				//设置Li的样式
			containerItem.css({
				width : findWidth,
				height : findHeight,
				'background-image' : 'url('+Img.src+')',
				// 'background-size' : width+'px '+height+'px',
				'background-size' : ''+width+'px '+height+'px',
				opacity : 0
			});

			// container.css({
			// 	left : '50%',
			// 	top : '50%',
			// 	'margin-top' : -height/2,
			// 	'margin-left' : -width/2
			// });

			var x,y;
			for(i = 0; i < containerItem.length; i++){
				x = i%_default.column;
				y = Math.floor(i/_default.column);

				//遍历每一个li元素，然后设置相对应的li的样式
				containerItem.eq(i).css({

					//设置对应的li位置的图片的定位
					'background-position' : -x*findWidth+'px '+(-y*findHeight)+'px',

					//随机生成对应Li的left和top的绝对定位
					left :  Math.ceil(Math.random()*windowWidth*2) - windowWidth,
					top : Math.ceil(Math.random()*windowHeight*2) - windowHeight

				}).animate({
					//添加动画，所有的li样式全部设置成下面的样式
					left : 0,
					top : 0,
					opacity : 1
				},

				//设置完成动画的时间，时间为随机的！
				//ceil 对数进行上舍入。 
				Math.ceil(Math.random()*(0.64*_default.animeTime))+(0.22*_default.animeTime));
			}
		}
	}
	fragmentImg(fragmentConfig);
})(jQuery)