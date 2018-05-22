$(function () {
    var xmlObj = checkXMLDocObj('Web.config');
    //alert(4);
    //alert(xmlOb);
    //var root = xmlObj.documentElement;
    //var add = root.getElementByTagName("add");
    //alert(add.length);
})

//加载xml文件  设计到浏览器兼容问题
var loadXML = function (xmlFile) {
    //alert(xmlFile);
    var xmlDoc;
    if (window.ActiveXObject) {
        //alert(1);
        xmlDoc = new ActiveXObject('Microsoft.XMLDOM');//IE浏览器
        xmlDoc.async = false;
        xmlDoc.load(xmlFile);
    }
    else if (isFirefox = navigator.userAgent.indexOf("Firefox") > 0) { //火狐浏览器
        //alert(2);
        //else if (document.implementation && document.implementation.createDocument) {//这里主要是对谷歌浏览器进行处理
        xmlDoc = document.implementation.createDocument('', '', null);
        xmlDoc.async = false;
        xmlDoc.load(xmlFile);
        console.log(xmlDoc);
    }
    else { //谷歌浏览器
        //alert(3);
        var xmlhttp = new window.XMLHttpRequest();
        xmlhttp.open("GET", xmlFile, false);
        //alert(4);
        xmlhttp.send();
        //alert(xmlhttp.readyState);
        if (xmlhttp.readyState == 4) {
            xmlDoc = xmlhttp.responseXML.documentElement;
        }
    }
    //alert($(xmlDoc).length);
    return xmlDoc;
}

// 首先对xml对象进行判断
var checkXMLDocObj = function (xmlFile) {
    var xmlDoc = loadXML(xmlFile);
    alert(xmlDoc);
    if (xmlDoc == null) {
        alert('您的浏览器不支持xml文件读取,于是本页面禁止您的操作,推荐使用IE5.0以上可以解决此问题!');
        window.location.href = '../err.html';

    }
    return xmlDoc;
}