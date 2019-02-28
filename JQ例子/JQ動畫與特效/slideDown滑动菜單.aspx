<%@ Page Language="C#" AutoEventWireup="true" CodeFile="slideDown滑动菜單.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>slideDown滑入滑出</title>
    <style type="text/css">
        * {
            margin:0px; padding:0px;
        }

        body {
            font-size:14px;
        }

      
        ul {
            list-style:none;
        }      

        ul li a {
            text-decoration:none;
        }

        ul.firstMenu  {
           height:25px; border:solid 1px #ccc; width:450px; margin:12px auto;
        }

        ul.firstMenu li {
            float:left; padding:0 8px; height:25px; line-height:25px;
        }

        .secondLi {
            position:relative; cursor:pointer;
        }
        .firstMenu li ul {
            border:solid 1px red; border-top:none; width:90px; position:absolute; display:none; margin-left:-17px;
        }

        .firstMenu li ul a {
            margin-left:8px;
        }

       .firstMenu li ul li {
           float:none; height:18px;
       }
        .auto-style1 {
            width: 135px;
            height: 47px;
        }
    </style>
    <script src="jquery-1.8.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $(".secondLi").hover(function () {
                $(".secondLi ul").slideDown(2000);      //可改為slideToggle
            }, function () {
                $(".secondLi ul").slideUp(2000);          
           });
        });

        ////或者
        //$(function () {
        //    $(".secondLi").hover(function () {
        //        $(".secondLi ul").slideToggle(2000);
        //    });                
        //});

        //动画停止
        $(function () {
            $(".secondLi ul").hover(function () {
                $(".secondLi ul").stop().slideDown(1000);
            }, function () {
                $(".slideDown ul").stop().slideUp(1000);
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="menu">
        <ul class="firstMenu">            
            <li><a href="#">購物車</a></li>
            <li>|</li>

            <li class="secondLi">我的當當  
            <ul>
                <li><a href="#">珠寶手錶</a></li>
                <li><a href="#">手機數碼</a></li>
                <li><a href="#">家電辦公</a></li>
            </ul>        
            </li>

            <li>|</li>
            <li><a href="#">手機當當</a></li>
             <li>|</li>
            <li><a href="#">企業採購</a></li>
             <li>|</li>
            <li><a href="#">自助服務</a></li>
           
        </ul>
        
    </div>
    </form>
</body>
</html>
