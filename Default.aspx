<%@ Page Title="Product Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="proWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Product Management</h2>

        <table>
            <tr>
                <td><label for="txtCode">Code:</label></td>
                <td><asp:TextBox ID="txtCode" runat="server" Width="270px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtName">Name:</label></td>
                <td><asp:TextBox ID="txtName" runat="server" Width="270px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtAmount">Quantity:</label></td>
                <td><asp:TextBox ID="txtAmount" runat="server" Width="135px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="ddlCategory">Category:</label></td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server">
                        <asp:ListItem Text="Computing" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Telephony" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Gaming" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Home Appliances" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><label for="txtPrice">Price:</label></td>
                <td><asp:TextBox ID="txtPrice" runat="server" Width="135px"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="txtCreationDate">Creation Date:</label></td>
                <td><asp:TextBox ID="txtCreationDate" runat="server" Width="200px"></asp:TextBox></td>
            </tr>
        </table>

        <!-- Botones -->
        <div class="button-container">
            <asp:Button ID="btnRead" runat="server" Text="Read" CssClass="btn-spacing" OnClick="btnRead_Click" />
            <asp:Button ID="btnReadFirst" runat="server" Text="Read First" CssClass="btn-spacing" OnClick="btnReadFirst_Click" />
            <asp:Button ID="btnReadPrev" runat="server" Text="Read Previous" CssClass="btn-spacing" OnClick="btnReadPrev_Click" />
            <asp:Button ID="btnReadNext" runat="server" Text="Read Next" CssClass="btn-spacing" OnClick="btnReadNext_Click" />
            <asp:Button ID="btnCreate" runat="server" Text="Create" CssClass="btn-spacing" OnClick="btnCreate_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-spacing" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-spacing" OnClick="btnDelete_Click" />
        </div>

        <!-- Barra de mensajes de aviso -->
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
    </div>

    <style>
        .button-container {
            margin-top: 20px;
        }
        .btn-spacing {
            margin-right: 10px;
        }
    </style>
</asp:Content>


