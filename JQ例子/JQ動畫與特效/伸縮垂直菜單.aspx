<%@ Page Language="C#" AutoEventWireup="true" CodeFile="伸縮垂直菜單.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>JQ隱藏與顯示</title>
    <style type="text/css">
        * {
            margin:0px; padding:0px;
        }

        body {
            font-size:14px;
        }

        #menu {
            margin:30px; width:100px;
        }

        ul {
            list-style:none;
        }

       ul li {
           height:30px; line-height:40px; text-align:center; border:1px solid #ccc; border-bottom:none;
       }

        ul li a {
            text-decoration:none;
        }

        .title {
            background-color:#f90;
        }

        .lastTtem {
            background-image:url(images/up.gif);
            background-position:center top;
            background-repeat:no-repeat;
            cursor:pointer; border:none; border-top: solid 1px #ccc;
        }

        ul li.down {
            background-image:url(images/down.gif);
        }

    </style>
    <script src="jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
      
        $(function () {
            $("#menu li.lastTtem").click(function () {
                //切換菜單
                $("#menu li:gt(5):not(:last)").toggle();
                //更換底部箭頭
                $(this).toggleClass("down")
            });

        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="menu">
        <ul>
            <li class="title">商品服務分類</li>
            <li><a href="#">鞋包配飾</a></li>
            <li><a href="#">運動戶外</a></li>
            <li><a href="#">珠寶手錶</a></li>
            <li><a href="#">手機數碼</a></li>
            <li><a href="#">家電辦公</a></li>
            <li><a href="#">護膚彩妝</a></li>
            <li><a href="#">母嬰用品</a></li>
            <li><a href="#">家紡居家</a></li>
            <li  class="lastTtem"></li>
        </ul>
        
    </div>
    </form>
</body>
</html>
