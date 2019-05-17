
function Event_GridLoaded() {

    //数据网格加载完成事件   注意设置cookie的时候  防止名字重复  尽量设置一个唯一的cookie  key值
    var count = cookie.get("count_5183");
    if (count == undefined) {
        cookie.set("count_5183", 1, 1000);
        AppendButton1();
    }
    else {
        var htmlOld = unescape(cookie.get("html_5183"));
        //alert(htmlOld);
        //var btnGroupDiv = $('.rightBtnGroup_Div');
        var btnGroupDivHtml = unescape(cookie.get("html_5183_GroupDiv"));

        //href='../../TenantInfo/2845d6ce993a41969bc03c6d7469cb08/Knowledge/009e71841ea043168924427a79f1cee7.ppt'
        var btnHtml = "<a class='normalBtn'  onclick=\"IsSelectValidData()\"  href='javascript:void(0);'>导出当月明细</a><div style='display: none'><a id='downloadRul' href=''><p></p ></a></div >";
        var htmlNew = btnGroupDivHtml + btnHtml;
        if (htmlOld != htmlNew) {
            cookie.delete("html_5183");
            cookie.set("html_5183", escape(htmlNew), 1000);
        }
        //alert(htmlNew);
        AppendButton2(htmlNew);
    }

    //cookie.delete("count");
    //cookie.delete("html");

}


//这里这个函数为什么会执行两次？
function AppendButton1() {
    //<a class="normalBtn" onclick="Add(&quot;/Base/Layout/Edit.aspx?act=add&quot;,&quot;tbContent&quot;,&quot;&quot;)" identityname="btnAdd" href="javascript:void(0)">新建</a>
    //<a class="normalBtn" onclick="BulkDel(this,false);" href="javascript:void(0);" style="display: block;">永久删除</a>
    //var btnGroupDiv = $('.rightBtnGroup_Div');
    //因为该函数会执行两次，这样写会页面会出现两个按钮  只能是html直接赋值
    //var html ="<a class='normalBtn' onclick='Add(\"/Base/Layout/Edit.aspx?act=add\",\"tbContent\",\"\")' identityname=\"btnAdd\" href=\"javascript:void(0)\" >新建</a>"+"<a class='normalBtn' onclick=\"Test()\" href='javascript:void(0);'>新增按钮测试</a>"+"<a  class='normalBtn' onclick=\"OpenNewTab()\"  href=\"javascript:void(0);\" >点击开窗</a>";

    //var html = btnGroupDiv.html() + btnHtml;
    var btnGroupDiv = $('.rightBtnGroup_Div');
    var btnHtml = "<a class='normalBtn'  href=''>导出当月明细</a>";

    if (btnGroupDiv.html() != undefined) {
        var html = btnGroupDiv.html() + btnHtml;
        cookie.set("html_5183_GroupDiv", escape(btnGroupDiv.html()), 1000);
        cookie.set("html_5183", escape(html), 1000);
        btnGroupDiv.html(html);
    }
    else {
        setTimeout(AppendButton1, 1000);
    }

}

function AppendButton2(btnHtml) {
    var btnGroupDiv = $('.rightBtnGroup_Div');
    btnGroupDiv.html(btnHtml);
}

var cookie = {
    set: function (key, val, time) {//设置cookie方法
        var date = new Date(); //获取当前时间
        var expiresDays = time;  //将date设置为n天以后的时间
        date.setTime(date.getTime() + expiresDays * 24 * 3600 * 1000); //格式化为cookie识别的时间
        document.cookie = key + "=" + val + ";expires=" + date.toGMTString();  //设置cookie
    },
    get: function (key) {//获取cookie方法
        /*获取cookie参数*/
        var getCookie = document.cookie.replace(/[ ]/g, "");  //获取cookie，并且将获得的cookie格式化，去掉空格字符
        var arrCookie = getCookie.split(";")  //将获得的cookie以"分号"为标识 将cookie保存到arrCookie的数组中
        var tips;  //声明变量tips
        for (var i = 0; i < arrCookie.length; i++) {   //使用for循环查找cookie中的tips变量
            var arr = arrCookie[i].split("=");   //将单条cookie用"等号"为标识，将单条cookie保存为arr数组
            if (key == arr[0]) {  //匹配变量名称，其中arr[0]是指的cookie名称，如果该条变量为tips则执行判断语句中的赋值操作
                tips = arr[1];   //将cookie的值赋给变量tips
                break;   //终止for循环遍历
            }
        }
        return tips;
    },
    delete: function (key) { //删除cookie方法
        var date = new Date(); //获取当前时间
        date.setTime(date.getTime() - 10000); //将date设置为过去的时间
        document.cookie = key + "=v; expires =" + date.toGMTString();//设置cookie
    }
}


//判断员工是否有选中的数据行
function IsSelectValidData() {
    //先要给 最下面的单选框 设置id属性  拿到该span下属的checkbox元素 
    //给第一 和最后一个单选框 设置属性  筛选的时候 根据属性排除掉
    $('#selectall').attr("class", "selectall2");
    $('.selectAll_CkBox').children().attr("class", "selectall2");
    //$('.selectall2').attr("checked", "checked");  [checked='checked']

    //这样写是拿到 选中文本框中  class属性不为selectall2的对象集合
    var cBoxList = $('input:not(.selectall2)[type="checkbox"]:checked');
    if (cBoxList.length == 0) {
        AlertInfo("请先选择数据！！！", false);
    }
    else {
        ExportUsersAttendanceDetails(cBoxList);
    }
}


function ExportUsersAttendanceDetails(cBoxList) {
    //选择有效的数据行  之后 遍历cBox集合
    //AlertInfo("您选择了" + cBoxList.length + "条数据");
    var contractNumList = [];
    cBoxList.each(function (i, ele) {
        //编号  th  id fieldId_24631
        //这里  不能用合同编号  因为合同编号在数据表中不唯一
        var position = $('#fieldId_29523').prevAll().length;
        //这里用children()  函数 或者find('td')  【表示在当前元素的子孙元素中查找td元素】
        contractNumList.push($(ele).parent().parent().children().eq(position).text());
        //alert($(ele).parent().parent().children().eq(position).text());
    })

    //var excelPath ='../../TenantInfo/ExportDetailsDataToExcel/Test.xls';

    $.ajax({
        type: "POST",
        //这里一定要指定后台的pageName参数，即data参数通过后台那个页面来接收
        data: { arr: JSON.stringify(contractNumList), pageName: "DJ5186_PageHandle" },
        url: "/Extend/Ashx/Default.ashx",
        async: false,
        success: function (data) {
            $("#downloadRul").attr("href", data);
            //这里的>p是什么意思？
            $('#downloadRul>p').trigger("click");
        },
        error: function () {
            AlertInfo("导出未成功，请稍后重试", false);
        }
    })

}