<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EduSharp.Pluralsight.ADO.ASPDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 264px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Employee Id:"></asp:Label>
            <asp:TextBox ID="TextBoxEID" runat="server"></asp:TextBox>
            <asp:LinkButton ID="LinkButtonGetEmployee" runat="server" OnClick="LinkButtonGetEmployee_Click">GO!</asp:LinkButton>
            <br />
            <br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">First Name:</td>
                    <td>
                        <asp:TextBox ID="TextBoxFName" runat="server" Width="391px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Last Name:</td>
                    <td>
                        <asp:TextBox ID="TextBoxLName" runat="server" Width="394px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Department</td>
                    <td>
                        <asp:TextBox ID="TextBoxDName" runat="server" Width="393px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
        </div>
    </form>
</body>
</html>
