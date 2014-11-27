<%@ Page Title="Estructura" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="FormularioEstructura.aspx.cs" Inherits="SAPR.FormularioEstructura" %>

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
    



    
        <div class="page-header">
        <div class="row">
            <div class="col-lg-11">
                <h1><i class="fa fa-truck"></i> Estructura Proyecto</h1>
            </div>
            <div class =" col-lg-1">
                <a id="AYUDA" href="#modalAyuda" class="btn alert-link" role="button" data-toggle="modal" runat="server"><h4>Ayuda</h4></a> 
            </div>
        </div>
    </div>
    
            <div class ="row">
                    <div class="col-lg-8">
                    <div class="form-group">
                        <label for="textProyectos" class="col-sm-3 control-label"><font size ="4px">Seleccione Proyecto:</font> </label>
                       <div class="dropdown-toggle">
                                <asp:DropDownList ID="cmbProyecto" runat="server" AutoPostBack="True" OnSelectedIndexChanged="cmbProyecto_SelectedIndexChanged"></asp:DropDownList>           
                       </div>
                                       
                    </div>
                    </div>
            </div>
    <br />
    <br />
    <div class ="row">
        <asp:Button ID="btnManejarS" PostBackUrl="~/FormSprint.aspx" CssClass="btn btn-primary" runat="server" Text="Manejar Sprints" />
        <asp:Button ID="btnManejarM" PostBackUrl="~/FormModulo.aspx" CssClass="btn btn-primary" runat="server" Text="Manejar Módulos" />
    </div>
    <br />
    <br />
    

    <div class="col-lg-7">
            <div id="alertAlerta" class="alert alert-danger fade in" runat="server" hidden="hidden">
                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                <strong>
                    <asp:Label ID="labelTipoAlerta" runat="server" Text="Alerta! "></asp:Label></strong><asp:Label ID="labelAlerta" runat="server" Text="Mensaje de alerta"></asp:Label>
            </div>
    </div>

    <div >
        <asp:GridView ID="gridSprints" runat="server"  OnRowDataBound  ="OnRowDataBound" DataKeyNames="Identificador" CssClass=" table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <img alt="" style="cursor: pointer" src="Images/plus.png" />
                        <asp:Panel ID="pnlModulos" runat="server" Style="display: none">
                            <asp:GridView ID="gridModulos" runat="server" OnRowDataBound="OnRowDataBound2" DataKeyNames="Identificador" CssClass="table table-hover " BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <img alt="" style="cursor: pointer" src="Images/plus.png" />
                                            <asp:Panel ID="pnlReq" runat="server" Style="display: none">
                                                <asp:GridView ID="gridReq" runat="server" CssClass="table table-hover" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                    <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                                    <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                                                    <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                                                    <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

                                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

                                <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

                                <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

                                <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
        </asp:GridView>
    </div>

       <%--Modal AYUDA--%>
     <div class="modal fade" id="modalAyuda" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                    <h3 class="modal-title" id="modalAyudar"><i class="fa fa-exclamation-triangle text-danger fa-2x">Ayuda</i></h3>
                </div>
                <div class="modal-body">
                    En esta página se podrá seleccionar el proyecto al que se le desea revisar su jerarquía, o crear la misma. Si no hubiesen proyectos creados
                    con anticipación, entonces no podrían manejarse ni Sprints ni Módulos.
                    <br />
                    <br />
                    Los dos botones que se observan son: Manejar Sprints y Manejar Módulos. Los cuales sirven para <font color="blue" >Agregar</font>, <font color="green" >Modificar</font> y <font color="brown" >Eliminar</font> los mismos de ese proyecto
                    seleccionado.
                    <br />
                    <br />
                    Abajo de los botones se observa un árbol con la jerarquía del proyecto: Sprints, dentro sus módulos y dentro sus requerimientos.                 
                </div>
                <div class="modal-footer">
                    <button type="button" id="botonSalir" class="btn btn-danger" data-dismiss="modal">Salir</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>