<%@ Page Language="C#" AutoEventWireup="true" CodeFile="顯示與隱藏.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>JQ隱藏與顯示</title>
    <style type="text/css">
        img {
            display:none;
        }
    </style>
    <script src="jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn").click(function () {
                if ($(this).val() == "顯示") {
                    $("#pic").show("slow", function () {
                        $(this).css({ "border": "1px solid #ccc", "padding": "5px" });      //可將show()改為toggle()
                    });
                    $(this).val("隱藏")
                } else {
                    $("#pic").hide("slow");
                    $(this).val("顯示");
                }
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            <img src="images/P1.jpg" id="pic"/>
        </p>
        <input type="button" value="顯示" id="btn"/>
    </div>
    </form>
</body>
</html>
