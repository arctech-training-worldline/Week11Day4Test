<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormDemo.aspx.cs" Inherits="Week11Day4Test.WebFormDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <a href="Services/BankBranchDataService.cs">Services/BankBranchDataService.cs</a>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <%--BAD BAD BAD--%>
            Name: <asp:TextBox runat="server" ID="TextBoxName" />
            <asp:Button Text="Save" runat="server" />
        </div>
    </form>
</body>
</html>
