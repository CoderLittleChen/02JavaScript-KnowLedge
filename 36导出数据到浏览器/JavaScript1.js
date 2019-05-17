$(document).ready(function () {
    //setTimeout(SS, 200);
    //setTimeout(AppendButton, 1);
    AppendButton();
});

function SS() {

}
function Event_GridLoaded() {
    //setTimeout(AppendButton, 1);
    AppendButton();
}
function AppendButton() {
    var more_Icon = $(".rightBtnGroup_Div");
    //var htmlstr = "<a class='normalBtn' style='display:block' onclick=\"De_ButtJoint(this,'tbContent',true,'对接')\" href='javascript:void(0);'>自动生成</a>"
    //var htmlstr = "<a class='normalBtn' style='display:none'  href='javascript:void(0);'>自动生成</a>"
    if (more_Icon.html() != null)
        more_Icon.html('');
}
var maxTimes = 100;

function De_ButtJoint1111() {
    //var str = "<iframe style=\"position:absolute;top:0;left:0;width:430px;height:100px;filter:alpha(opacity=0);opacity:0;z-index:-99\" id='Iframeshow'></iframe>";
    //str += "<div style='text-align:center;'><br/><table id='priceClass' cellspacing=0 cellpadding=0 border=0 style='line-height:24px;'>";
    ////multiLangObject.btnEdit
    //str += "<tr><td style='text-align:right;width:120px;'>部门全称：</td>";
    //str += "<td style='text-align:left'><input style='width:173px;' type=\"text\" maxlength=\"50\" class=\"inputText forEdit\" id=\"bm\"></td></tr>";
    //str += "</table></div>";
    //var dialogPara = {};
    //dialogPara.Title = "考勤部门"; //标题
    //dialogPara.Content = str; //内容
    //dialogPara.Enterfn = function () {  //确定事件
    //    $.ajax({
    //        type: "POST",
    //        data: { bm: GetParentWindow().$("#bm").val(), pageName: "DJ5183" },
    //        url: "/Extend/Ashx/Default.ashx",
    //        success: function (data) {
    //            var arr = data.split('|');
    //            if (arr[0] == "1") {
    //                //setTimeout(Tck, 1000);
    //                //if (maxTimes == 0) {
    //                ToClosePmwayDialog(dialogPara.Id, dialogPara.IsRemoveWhenClose);
    //                $(".refresh-Icon").click();
    //                // }
    //                AlertInfo("请稍作等待！", true);
    //            }
    //            else {
    //                //AlertInfo(arr[1], false);
    //                ToClosePmwayDialog(dialogPara.Id, dialogPara.IsRemoveWhenClose);
    //                AlertInfo("生成完毕！", true);
    //            }
    //        },
    //        error: function (msg) { AlertError("生成完毕！"); }
    //    });
    //};
    //dialogPara.Width = 430; //宽度
    //dialogPara.Height = 280; //高度
    //dialogPara.IsModal = true; //是否模态
    //dialogPara.IsRemoveWhenClose = true; //关闭时是否移除掉 
    //OperatorDialog(dialogPara);

    $.ajax({
        type: "POST",
        //GetQueryString方法  获取当前页面url中指定key的值
        data: { act: GetQueryString("act"), pageName: "DJ5183" },
        url: "/Extend/Ashx/Default.ashx",
        success: function (data) {
            var arr = data.split('|');
            if (arr[0] == "1") {
                //setTimeout(Tck, 1000);    我什么
                //AlertInfo("请稍作等待！", true);
            }
            else {
                //AlertInfo("生成完毕，请刷新查看！", true);
                //setTimeout(Tck, 1000);
                //return;
            }
        },
        error: function (msg) { AlertError(msg); }
    });
    AlertInfo("正在生成，请稍作等待", true);
    //alert("第一次执行");
    maxTimes = 100;
    setTimeout(Tck, 5000);
}

window.onload = function () {
    setTimeout(Tck1, 1000);
}




function Tck() {
    //alert("开始执行"+maxTimes);
    ToShowAjaxStatus(false);
    maxTimes = maxTimes - 1;
    if (maxTimes <= 0) {
        return;
    }
    $.ajax({
        type: "POST",
        data: { pageName: "IsOver5183", moduleId: "5183" },
        url: "/Extend/Ashx/Default.ashx",
        success: function (data) {
            //alert("data:"+data);
            if (data == "") {
                maxTimes = 0;
                AlertInfo("生成完成，请刷新后查看", true);
                ToShowAjaxStatus(true);
            }
            else {
                //alert("第一次执行失败");
                AlertInfo("正在生成，请稍作等待", true);
                setTimeout(Tck, 5000);
            }
        },
        error: function (msg) { AlertError(msg); }
    });
}

function Tck1() {
    ToShowAjaxStatus(false);
    maxTimes = maxTimes - 1;
    if (maxTimes <= 0) {
        return;
    }
    $.ajax({
        type: "POST",
        data: { pageName: "IsOver5183", moduleId: "5183" },
        url: "/Extend/Ashx/Default.ashx",
        success: function (data) {
            if (data == "") {
                maxTimes = 0;
                ToShowAjaxStatus(true);
            }
            else {
                AlertInfo("正在生成，请稍作等待", true);
                setTimeout(Tck1, 5000);
            }
        },
        error: function (msg) { AlertError(msg); }
    });
}