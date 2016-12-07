<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Laba1._Default" %>

<asp:Content ID="PageStyle" ContentPlaceHolderID="Styles" runat="server">
    <link href="Content/home-page.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h1><%:Title %>.</h1>
        <h2>Warrior can help you to find all you need for combat sports and personal trainings</h2>
        <p class="lead">You can order any of our product. Each product has detailed information to help you choose the right one.</p>
    </div>

    <div class="carousel-container">
        <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
            <!-- Indicators -->
            <ol class="carousel-indicators">
                <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                <li data-target="#carousel-example-generic" data-slide-to="2"></li>
            </ol>

            <!-- Wrapper for slides -->
            <div class="carousel-inner" role="listbox">
                <div class="item active">
                    <img src="Content/Images/slide1.jpg" alt="fitness-step">
                </div>
                <div class="item">
                    <img src="Content/Images/slide2.jpg" alt="fitness-power-squat">
                </div>
                <div class="item">
                    <img src="Content/Images/slide3.jpg" alt="fitness-boxing">
                </div>
            </div>

            <!-- Controls -->
            <a class="left carousel-control" href="#carousel-example-generic" role="button" data-slide="prev">
                <span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="right carousel-control" href="#carousel-example-generic" role="button" data-slide="next">
                <span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</asp:Content>
