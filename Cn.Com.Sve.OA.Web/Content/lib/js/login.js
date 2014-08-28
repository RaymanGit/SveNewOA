LG.login = function ()
{
    $(document).bind('keydown.login', function (e)
    {
        if (e.keyCode == 13)
        {
            dologin();
        }
    });

    if (!window.loginWin)
    {
        var loginPanle = $("<form></form>");
        loginPanle.ligerForm({
            fields: [
                { display: '用户名', name: 'LoginUserName' },
                { display: '密码', name: 'LoginPassword', type: 'password' }
            ]
        });

        window.loginWin = $.ligerDialog.open({
            width: 400,
            height: 140, top: 200,
            isResize: true,
            title: '用户登录',
            target: loginPanle,
            buttons: [
            { text: '登录', onclick: function ()
            {
                dologin();
            } 
            },
            { text: '取消', onclick: function ()
            {
                window.loginWin.hide();
                $(document).unbind('keydown.login');
            } 
            }
            ]
        });
    }
    else
    {
        window.loginWin.show();
    }

    function dologin()
    {
                var username = $("#txtUsername").val();
                var password = $("#txtPassword").val();
                if (username == "") {
                    alert('账号不能为空!');
                    $("#txtUsername").focus();
                    return;
                }
                if (password == "") {
                    alert('密码不能为空!');
                    $("#txtPassword").focus();
                    return;
                }
                $.ajax({
                    type: 'post', cache: false, dataType: 'json',
                    url: '@Url.Action("Login", "System")',
                    data: [
                    { name: 'UserName', value: username },
                    { name: 'Password', value: password }
                    ],
                    success: function (result) {
                        if (!result) {
                            alert('登陆失败,账号或密码有误!');
                            $("#txtUsername").focus();
                            return;
                        } else {
                            location.href = decodeURIComponent(FromUrl);
                        }
                    },
                    error: function () {
                        alert('发送系统错误,请与系统管理员联系!');
                    },
                    beforeSend: function () {
                        $.ligerDialog.waitting("正在登陆中,请稍后...");
                        $("#btnLogin").attr("disabled", true);
                    },
                    complete: function () {
                        $.ligerDialog.closeWaitting();
                        $("#btnLogin").attr("disabled", false);
                    }
                });
//        var username = $("#LoginUserName").val();
//        var password = $("#LoginPassword").val();

//        $.ajax({
//            type: 'post', cache: false, dataType: 'json',
//            url: '../handler/validate.ashx',
//            data: [
//                    { name: 'Action', value: 'Login' },
//                    { name: 'username', value: username },
//                    { name: 'password', value: password }
//                    ],
//            success: function (result)
//            {
//                if (!result)
//                {
//                    LG.showError('登陆失败,账号或密码有误!');
//                    $("#LoginUserName").focus();
//                    return;
//                } else
//                {
//                    location.href = location.href;
//                }
//            },
//            error: function ()
//            {
//                LG.showError('发送系统错误,请与系统管理员联系!');
//            },
//            beforeSend: function ()
//            {
//                LG.showLoading('正在登录中...');
//            },
//            complete: function ()
//            {
//                LG.hideLoading();
//            }
//        });
    }

};