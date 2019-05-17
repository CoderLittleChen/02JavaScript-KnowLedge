<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_19HTML测试.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        .pr {
            position: relative;
        }

        .pa {
            position: absolute;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%--<div>
            <strong>
                <span class="auto-style3" style="vertical-align:top">资产信息：</span>
            </strong>
            <asp:TextBox ID="TextBox8" ReadOnly="true" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
        </div>--%>
        <div>
            <p class="pr">
                <strong>
                    <span class="pa"  style="vertical-align: top">资产信息：</span>
                </strong>
                <asp:TextBox ID="TextBox1" ReadOnly="true" runat="server" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </p>
        </div>
    </form>
</body>
</html>
