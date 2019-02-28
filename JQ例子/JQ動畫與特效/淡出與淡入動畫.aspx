<%@ Page Language="C#" AutoEventWireup="true" CodeFile="淡出與淡入動畫.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>淡出與淡入</title>
    <style type="text/css">
        img {
            display:none;
        }
    </style>
    <script src="jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#btn").click(function () {
                if ($(this).val() == "淡入") {
                    $("#pic").fadeIn("slow", function () {
                        $(this).css({ "border": "solid 1px #ccc", "padding": "5px" });
                    });
                    $(this).val("淡出");
                } else {
                    $("#pic").fadeOut("slow");
                    $(this).val("淡入");
                }
            });
        });
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <p>
           <img src="images/P2.jpg" id="pic" />
       </p>
        <input type="button" value="淡入" id="btn">
    </div>
    </form>
</body>
</html>
