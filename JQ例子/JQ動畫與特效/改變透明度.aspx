<%@ Page Language="C#" AutoEventWireup="true" CodeFile="改變透明度.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>JQ隱藏與顯示</title>
    <style type="text/css">
        
    </style>
    <script src="jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#sel").change(function () {
                var opacity = $(this).val();
                $("img").fadeTo(1000, opacity);
            });
        });


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>
            <img src="images/P2.jpg"/>
        </p>
        <p>
            <select id="sel">
                <option value="0.2">0.2</option>
                <option value="0.4">0.4</option>
                <option value="0.6">0.6</option>
                <option value="0.8">0.8</option>
                <option value="1" selected="selected">1</option>
            </select>
        </p>
       
    </div>
    </form>
</body>
</html>
