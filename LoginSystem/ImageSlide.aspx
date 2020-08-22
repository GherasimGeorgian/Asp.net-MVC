<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageSlide.aspx.cs" Inherits="LoginSystem.ImageSlide" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>

                    <asp:Image ID="Image1" runat="server" />
                </ContentTemplate>

            </asp:UpdatePanel>

        </div>

        <div>
            Select any name:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="True" ></asp:DropDownList>
            <br/>
            <asp:Image ID="Image2" runat="server" Height="304px" Width="539px" />
        </div>
    </form>
    </center>
</body>
</html>
