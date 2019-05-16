<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loginside.aspx.cs" Inherits="GoodGuidance.Loginside" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-weight: normal;
        }
        .auto-style2 {
            font-size: xx-large;
            text-align: center;
        }
        .auto-style3 {
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <p class="auto-style2"> <strong style="text-align: center">Fælles Forum </strong> </p>
        <div style="height: 345px; font-weight: 700;">
            <span class="auto-style1"><strong><span class="auto-style3">Velkommen.<br />
            </span><br />
            Login herunder</strong></span><br />
            <br />
            <asp:Label ID="LabelBrugernavn" runat="server" Text="Brugernavn:"></asp:Label>
            <br />
            <span class="auto-style1">
            <asp:TextBox ID="TextBoxBrugernavn" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxBrugernavn" ErrorMessage="Udfyld venligst navn"></asp:RequiredFieldValidator>
            </span>
            <br />
            <br />
            <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" />
            <span class="auto-style1">
            <asp:Label ID="LabelFejl" runat="server"></asp:Label>
            <asp:Label ID="LabelFejl2" runat="server"></asp:Label>
            <br />
            </span>
            <br />
            <asp:Button ID="ButtonOpretBruger" runat="server" OnClick="ButtonOpretBruger_Click" Text="Opret ny bruger" />
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Forsøg på login: "></asp:Label>
            <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
            &nbsp;ud af 3<br />
        </div>
    </form>
</body>
</html>
