<%@ Page Title="Estructura" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioEstructura.aspx.cs" Inherits="SAPR.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="head">

    
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type="text/javascript">
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "images/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "images/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>
    
    
    
    
    
    <div >
        <asp:GridView ID="gridSprints" runat="server" OnRowDataBound="OnRowDataBound" DataKeyNames="idSprint" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt = "" style="cursor: pointer" src="Images/plus.png" />
                        <asp:Panel ID="pnlOrders" runat="server" Style="display: none">
                            <asp:GridView ID="gridModulos" runat="server">
                            </asp:GridView>
                         </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>


</asp:Content>