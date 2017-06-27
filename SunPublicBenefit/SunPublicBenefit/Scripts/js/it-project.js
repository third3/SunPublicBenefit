//************yanzhenma*************
var captcha_img = $('#imgCode');
var verifyimg = captcha_img.attr("src");
captcha_img.attr('title', '点击刷新');
captcha_img.click(function () {
    if (verifyimg.indexOf('?') > 0) {
        $(this).attr("src", verifyimg + '&random=' + Math.random());
    } else {
        $(this).attr("src", verifyimg.replace(/\?.*$/, '') + '?' + Math.random());
    }
});
//***************省市************
$.get("/Approve/LoadAllProvinceInfo", function (data) {
    $("#province-id").html(data);
    bindProSelectChangeEvent();//绑定省的下拉列表的change事件
    $("#province-id").change();
});
function bindProSelectChangeEvent() {
    $("#province-id").change(function () {
        var pId = $(this).val();
        $.get("/Approve/GetAllCityByProvinceID", { pId: pId }, function (data) {
            $("#city-id").html(data);
        });
    });
}
//***************切换到下一步的资料填写************
var oField = document.getElementById('p_Field');
var aField = oField.getElementsByTagName('a');
for (var i = 0; i < aField.length; i++) {
    aField[i].onclick = function () {
        for (var i = 0; i < aField.length; i++) {
            aField[i].className = '';
        }
        this.className = 'field';
    }
}
var oBmi = document.getElementById('sbmit');
var oNext = oBmi.getElementsByTagName('a')[0];
var oh3 = document.getElementsByClassName('h3')[0];
var oInf = document.getElementById('inf');
var aLis = oInf.getElementsByTagName('li');
var center = document.getElementById('p_Center');
var oDetails = document.getElementById('p_Details');
var oMub = document.getElementById('mubiao');
var oMy = oMub.getElementsByTagName('input')[0];

oNext.onclick = function () {//保存，下一步
    if (oMy.value == '') {
        alert('请输入目标金额！');
        return false;
    } else if (!Nameber(oMy.value)) {
        alert('请输入数字！');
    }
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
