<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laba1._Default" %>

<asp:Content ID="PageStyles" ContentPlaceHolderID="Styles" runat="server">
    <link href="Content/VideoBackground.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="background-wrap">
        <video id="video-bg-elem" preload="auto" loop="loop" autoplay="autoplay" muted="muted">
            <source src="Content/Images/video.mp4" type="video/mp4">
            Video not supported
        </video>
    </div>

    <div class="content">
        <h1>Sambo mix</h1>
        <p>Lorem Ipsum - це текст-"риба", що використовується в друкарстві та дизайні. Lorem Ipsum є, фактично, стандартною "рибою" аж з XVI сторіччя, коли невідомий друкар взяв шрифтову гранку та склав на ній підбірку зразків шрифтів. "Риба" не тільки успішно пережила п'ять століть, але й прижилася в електронному верстуванні, залишаючись по суті незмінною. Вона популяризувалась в 60-их роках минулого сторіччя завдяки виданню зразків шрифтів Letraset, які містили уривки з Lorem Ipsum, і вдруге - нещодавно завдяки програмам комп'ютерного верстування на кшталт Aldus Pagemaker, які використовували різні версії Lorem Ipsum.</p>
    </div>
</asp:Content>
