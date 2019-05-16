<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beskedside.aspx.cs" Inherits="GoodGuidance.Beskedside" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 576px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListBox ID="ListBoxBeskeder" runat="server" Height="367px" style="text-align: justify" Width="957px"></asp:ListBox>
        </div>
        <asp:Button ID="ButtonTilbage" runat="server" OnClick="ButtonTilbage_Click" Text="Tilbage" />
    </form>
</body>
</html>
