<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioProyecto.aspx.cs" Inherits="SAPR.FormularioProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <asp:TreeView ExpandDepth="1" runat="server">
    <Nodes>
      <asp:TreeNode Text="Employees">
        <asp:TreeNode Text="Bradley" Value="ID-1234" />
        <asp:TreeNode Text="Whitney" Value="ID-5678" />
        <asp:TreeNode Text="Barbara" Value="ID-9101" />
      </asp:TreeNode>
    </Nodes>
  </asp:TreeView>

</asp:Content>