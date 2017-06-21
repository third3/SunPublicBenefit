$(function () {
    // ************置顶按钮*************
    $(window).scroll(function () {
        ($(window).scrollTop() >= 200) ? $('.stick').fadeIn(300) : $('.stick').fadeOut(300);
    })
    $('.stick').click(function () { $('html,body').animate({ scrollTop: '0px' }, "slow"); });

    // ************轮播图*************
    var $lunbo_img_w = $(".slider").width();
    var $lunbo_img_h = $(".slider").height();
    $(".slider ul li img").css({ "width": $lunbo_img_w, "height": $lunbo_img_h });
    $(window).resize(function () {
        var $lunbo_w = $(".slider").width();
        var $lunbo_h = $(".slider").height();
        $(".slider ul li img").css({ "width": $lunbo_w, "height": $lunbo_h });
    })
    var index = 0;
    var i = setInterval(function () {
        index++;
        $(".slider ul li").eq(index).fadeIn();
        if (index == 4) {
            index = 0;
            for (var i = 1; i < 4; i++) {
                $(".slider ul li").eq(i).fadeOut();
            }
        }
    }, 5000);

    // ************菜单选项*************
    var index = 0;
    //for (var i = 0; i < $(".nav .nav_menu .cp_ul li a").size(); i++) {
    //    if ($(".nav .nav_menu .cp_ul li a").eq(i).attr("class") == "active") { index = i; $(".nav .nav_menu .cp_ul li a").eq(index).addClass("active"); };
    //}
    for (var j = 0; j < $(".nav .nav_menu .cp_ul li a").size() ; j++) {
        (function (j) {
            $(".nav .nav_menu .cp_ul li a").eq(index).addClass("active");
            $(".nav .nav_menu .cp_ul li a").eq(j).click(function () {
                for (var i = 0; i < $(".nav .nav_menu .cp_ul li a").size() ; i++) {
                    $(".nav .nav_menu .cp_ul li a").eq(i).removeClass("active");
                }
                $(this).addClass("active");
                //indexs = $(".active").index("a");
            })
        })(j)
    }

    

    // ************登陆验证*************
    $('#login').click(function () {
        var username = $('#username').val();
        var password = $('#password').val();
        $.post('Verify', { 'username': username, 'password': password }, function (data) {
            if (data == 1) {
                alert('用户名或密码错误');
            }
            else {
                alert('登录成功');
                $(".form_donation").css("display", "none");
            }
        })
    });

    //function myAddEvent(obj, sEv, fn) {
    //    if (obj.attachEvent) {
    //        obj.attachEvent('on' + sEv, fn);
    //    }
    //    else {
    //        obj.addEventListener(sEv, fn, false);
    //    }
    //};
    // ************注册验证*************
    var email = /^(\w-*\.*)+@(\w-?)+(\.\w{2,})+$/;
    var passOne = /[A-Za-z].*[0-9]|[0-9].*[A-Za-z]/;
    function formValidation(ipID, error, pClass, regular) {
        $('#' + ipID + '').blur(function () {
            if (!regular.test($('#' + ipID + '').val())) {
                $("." + pClass + "").text("*" + error + "");
            } else {
                $("." + pClass + "").text("");
            }
        })
    }
    new formValidation("add_username", "请输入正确的邮箱", "form_userEmail", email);
    new formValidation("add_password", "请输入正确的密码格式(至少要有一位字母)", "form_passOne", passOne);
    
    //**************表单提交判断文本框的信息是否完善***************
    $('#add').click(function () {
        var add_username = $('#add_username').val();
        var add_password = $('#add_password').val();
        var add_true_password = $('#add_true_password').val();
        if ($('.zc_mack input').val() == '') {
            alert('您的信息尚未录入完整');
            return false;
        }
        
        if (add_password != add_true_password) {
            $(".form_passTwo").text("*请输入两次相同的密码");
            return false;
        }
        $.post('addUser', { 'username': add_username, 'password': add_password }, function (data) {
            if (data == 1) {
                alert('该账号已被注册');
                return false;
            }
            else {
                alert('注册成功');
                window.location.href = "Index";
            }
        });
    });


    // ************加载图片*************
    for (var i = 1; i < 17; i++) {
        $(".persons_ms_tp ul").append("<li><img src='../images/loading.gif' data-original='../images/person/" + i + ".jpg'/></li>")
    }

    // ************图片懒加载技术*************
    $("img").lazyload({
        placeholder: "../images/loading.gif",
        effect: "fadeIn"
        // event : "sporty"  
    });
    // $(window).bind("load", function() {    
    //     var timeout = setTimeout(function() {$("img").trigger("sporty")},2000);    
    // }); 

    // ************AJAX提取公益动态据信息*************
    $.ajax({
        type: "GET",
        url: "/news.txt",
        dataType: "json",
        success: function (data) {
            // console.log(data[0].newsTitle);
            for (var i = 0; i < 4; i++) {
                $(".new_theme_activity span").eq(i).text(data[i].newsTitle);
                $(".new_theme_ms span").eq(i).text(data[i].newsMessage);
            }
        }
    });

    // ************AJAX提取公益人物据信息*************
    $.ajax({
        type: "GET",
        url: "/persons.txt",
        dataType: "json",
        success: function (data) {
            // for(var i=0;i<4;i++){
            // console.log(data[0].personsTitle);
            $(".persons_ms_zl_tl span").eq(0).text(data[2].personsTitle);
            $(".persons_ms_zl_ms span").eq(0).text(data[2].personsMessage);
            // }
        }
    });

    //************AJAX提取公益人物据信息*************
    for (var i = 0; i < $(".persons_ms_tp ul li img").size() ; i++) {
        (function (i) {
            $(".persons_ms_tp ul li img").eq(i).click(function () {
                $.ajax({
                    type: "GET",
                    url: "/persons.txt",
                    dataType: "json",
                    success: function (data) {
                        $(".persons_ms_zl_tl span").eq(0).text(data[i].personsTitle);
                        $(".persons_ms_zl_ms span").eq(0).text(data[i].personsMessage);
                    }
                });
            })
        })(i)
    }

    // ************注册窗口*************
    $(".zc_mack").css({ "width": $(window).width(), "height": $(window).height() });
    $(".zx_cs").click(function () {
        $(".zc_txt").val("");
        $(".zc_mack").css("display", "none");
        $(".zc_ct").css("transform", "translate(-50%,-50%) scale(0)");
    })
    $(".dt_zc").click(function () {
        $(".zc_mack").css("display", "block");
        
        $(".zc_ct").css("transform", "translate(-50%,-50%) scale(1)");
        console.log("sd");
    })

    // ************移动端界面的js代码*************
    var ap_wt = 250;
    var wt = window.innerWidth;
    $(".nav_menu_sl_ap").css({ "width": ap_wt + "px", "height": window.innerHeight, "left": 0 });
    $(".ap_id").css({ "width": wt - ap_wt + "px", "left": ap_wt + "px" });
    $(".slider_ap img").css({ "width": wt - ap_wt + "px", "height": "450px" });

    $(window).resize(function () {
        var ap_wt = 250;
        var wt = window.innerWidth;
        $(".nav_menu_sl_ap").css({ "width": ap_wt + "px", "height": window.innerHeight, "left": 0 });
        $(".ap_id").css({ "width": wt - ap_wt + "px", "left": ap_wt + "px" });
        $(".slider_ap img").css({ "width": wt - ap_wt + "px", "height": "450px" });
        $(".zc_mack").css({ "width": $(window).width(), "height": $(window).height() });
    })
    // ************导航栏下拉效果*************
    var tv_bol = true;
    for (var i = 0; i < $(".treeview").size() ; i++) {
        (function (i) {
            $(".treeview a").eq(i).click(function () {
                $(".treeview").eq(i).children(".treeview_sl").slideToggle();
                if (tv_bol) {
                    $(this).children(".tv_jt").css({ "transform": "rotate(90deg)" });
                    tv_bol = false;
                } else {
                    $(this).children(".tv_jt").css({ "transform": "rotate(0deg)" })
                    tv_bol = true;
                }
            })
        })(i)
    }
});