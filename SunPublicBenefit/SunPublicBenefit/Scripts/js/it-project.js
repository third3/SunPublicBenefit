alert(1);
var oBmi = document.getElementById('sbmit');
var oNext = oBmi.getElementsByTagName('a')[0];
var oh3 = document.getElementsByClassName('h3')[0];

var oInf = document.getElementById('inf');
var aLis = oInf.getElementsByTagName('li');
var center = document.getElementById('p_Center');
var oDetails = document.getElementById('p_Details');
alert(1);
oNext.onclick = function () {//保存，下一步
    center.style.display = 'none';
    oDetails.style.display = 'block';
    oh3.innerHTML = '项目详情';

    for (var i = 0; i < aLis.length; i++) {
        aLis[i].className = '';
    }

    aLis[1].className = 'tab';
}
var objSubimt = document.getElementsByClassName('sbmit_a')[0];
var detaLis = document.getElementsByClassName('detailed')[0];
var dLed_Inf = document.getElementsByClassName('detailed_Inf')[0];
var finish_Submit = document.getElementById('finish');
objSubimt.onclick = function () {//提交按钮
    oDetails.style.display = 'none';
    finish_Submit.style.display = 'block';
    detaLis.style.display = 'none';
    dLed_Inf.style.display = 'none';
}