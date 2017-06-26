//(function ($) {
//    $.fn.simplePage = function (o) {
//        var options = {
//            pager: '.pager',//表格控件容器
//            container: '.pb_figures_ms',//放置表格数据的容器
//            form: '#form',//放置查询条件的表单
//            pageForm: '#pageForm',//放置隐藏与的DIV
//            url: '',//发送请求的地址
//            currentPage: 1,
//            pageSize: 2,
//            type: null,//可选:action
//            pageShow:7
//        }
//        return sth;
//    }
//})(jQuery)
$.ajax({
    type: "GET",
    url: "/persons.txt",
    dataType: "json",
    success: function (data) {
        var totalPage = Math.ceil(data.length / 4);
        for (var i = 0; i < 4; i++) {
            $("#pf_ct").append("<div class='pb_figures_ms'><div class='pb_figures_ms_ig'><a href=''><img src='../images/cy_ytuz.jpg' /></a></div><div class='pb_figures_ms_pr'><ul><li class='pfmp_tl'><a href=''>" + data[i].personsTitle + "</a></li><li class='pfmp_ms'><span>" + data[i].personsMessage + "</span></li><li class='pfmp_lb'><span>01月08日</span><span>Time</span><span>标签:<a>公益人物</a></span></li><li class='pfmp_details'><a href=''>查看详情</a></li></ul></div>");
        }
        for (var j = 1; j <= totalPage; j++) {
            $(".pageBar ul li.reset").append("<a href=''>" + j + "</a>");
        }
    }
});