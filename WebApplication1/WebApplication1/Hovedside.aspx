<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hovedside.aspx.cs" Inherits="GoodGuidance.Hovedside" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Good Guidance Hovedside</title>
</head>
<body style="text-align: left">
    <form id="form1" runat="server">
        <div style="height: 518px">

            <h3>BESKED</h3>
            <asp:Label ID="Label2" runat="server" Text="Email:  "></asp:Label>
            &nbsp;
            <asp:TextBox ID="TextBoxEmail" runat="server" AutoCompleteType="Email"></asp:TextBox>
            <asp:Label ID="LabelConfirmed" runat="server"></asp:Label>

            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Besked: "></asp:Label>
            <br />
            <asp:TextBox ID="TextBoxBesked" runat="server" Height="289px" Rows="20" Width="596px" Wrap="False" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="LabelAdresse" runat="server" Text="Adresse: "></asp:Label>
            &nbsp;<asp:TextBox ID="TextBoxAdressse" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Text="Mobil nr.:"></asp:Label>
            &nbsp;<asp:TextBox ID="TextBoxMobil" runat="server"></asp:TextBox>
            <asp:Label ID="LabelMobileFailure" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonSave" runat="server" OnClick="ButtonSave_Click" Text="Send" />
            <asp:Button ID="ButtonReset" runat="server" Text="Reset" OnClick="ButtonReset_Click" />
            <asp:Button ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" Text="Delete all messages" />
            <asp:Button ID="ButtonRead" runat="server" OnClick="ButtonRead_Click" Text="Read all messages" />
            <br />
            <br />
            <br />
            <asp:Button ID="ButtonLogout" runat="server" OnClick="ButtonLogout_Click" Text="Logout" />
            <br />
            <asp:Label ID="LabelConfirmed2" runat="server"></asp:Label>
            <br />
            <br />

        </div>
    </form>
</body>
</html>
