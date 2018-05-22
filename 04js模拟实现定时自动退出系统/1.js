var _limitFreeMinutes = 1 / 6;
var _lastOperateDate = new Date();
//在页面除此加载的时候  设置定时计算函数  
$(function () {
    //模拟实现定时自动退出
    if (_limitFreeMinutes > 0) {
        //创建定时器
        _timer_Check_FreeOperate = setInterval(CheckFree_Operate, 1000);
    }
})


//var divObj = null;
//检测空闲  
function CheckFree_Operate() {
    //这里的new Date()获取当前时间   getTime()转换成时间戳
    //首先要 设置两个变量  最大空闲时长  最后操作时间

    //alert(new Date());
    //alert(_lastOperateDate);
    //这里拿到的时间差      对应的秒数
    var second = (new Date().getTime() - _lastOperateDate.getTime()) / 1000;
    var spanObj = $('#span');
    var html = "";
    if (second < _limitFreeMinutes * 60) {
        
    }


    //setInterval
    //alert(second);
}


//格式化数据
function FormatNumber(value, decimalDigits) {
    if (decimalDigits == undefined) {
        decimalDigits = consObject.theCounter;
    }
    if (isNaN(value)) value = 0;

    var finalNumber;
    var moduleId = GetQueryString('moduleId');
    if (moduleId != undefined && moduleId == '5111') {//成本分析固定值
        finalNumber = parseFloat(value).toFixed(8);
    }
    else {
        finalNumber = parseFloat(value).toFixed(decimalDigits);
    }
    var tempArray = finalNumber.split('.');
    if (tempArray.length == 1) {
        return finalNumber;
    }
    var length = finalNumber.length;
    if (tempArray[1].length > 2) {
        var str_After = tempArray[1];
        var charValue = "";
        var tempStr = "";
        var isBreak = true;
        for (var i = str_After.length - 1; i >= 0; i--) {
            charValue = str_After.charAt(i);
            if (charValue == "0" && isBreak) {
                continue;
            }
            else (charValue != "0")
            {
                isBreak = false;
            }
            tempStr += charValue;
        }
        tempStr = reverse(tempStr);
        if (tempStr.length < 2 && tempStr == '') {
            tempStr = "00";
        }
        tempArray[1] = tempStr;
    }
    return tempArray[0] + "." + tempArray[1];
}