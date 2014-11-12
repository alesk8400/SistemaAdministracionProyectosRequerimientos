<%@ Page Title="" Language="C#" MasterPageFile="~/Neo.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SAPR.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css"> 
        body {background-color: #B0C4DE ;} 
</style>

        <div class="page-header text-center">
            <div class="row">
                <div class="col-lg-12">
                    <h1><i class="fa fa-truck"></i>¡Bienvenido a SAPRD!</h1>
                 </div>       
             </div>
            <div class="row">
                <div class ="col-lg-12">
                    <label>Sistema de Administración de Proyectos y Requerimientos Deluxe</label>
                </div>   
            </div>
        </div>

         <div class="col-lg-12">
             <div class="well bs-component">
            

                 <div class=" text-center">
                     <h2> ¿Qué es nuestra aplicación?</h2>
                     <div class ="row">   
                             <h3>Nuestro SAPR le permite a usted como usuario poder gestionar usuarios y proyectos. Le da la oportunidad al usuario
                             de Insertar,Modificar,Eliminar y Consultar :
                            </h3>                         
                     </div>

                 </div>
                 <fieldset>

                     <div class="row text-center">
                         <div class="col-lg-6">
                             <h4><font size = "4">Usuarios</font></h4>
                         </div>
                         
                         <div class="col-lg-6">
                             <h4><font size = "4">Proyectos</font></h4>
                         </div>
                     </div>

                     <div class="row">
                         <div class="col-lg-6">
                     <div id="wellMio">
                        <div class="row"><label><font size ="3">Se insertan usuarios para poder asignarlos a proyectos.</font></label></div>
                        <div class="row"><label><font size ="3">Se le da la opción de modificar los datos de los usuarios.</font></label></div>
                         <div class="row"><label><font size ="3">Posibilidad de eliminar usuarios no deseados.</font></label></div>
                         <div class="row"><label><font size ="3">Capacidad de consultar la información personal de un usuario.</font></label></div>
                     </div>
                         </div>
                     <div class =" col-lg-6">
                      <div id="wellMio">
                        <div class="row"><label><font size ="3">Poder crear proyectos, con usuarios asignados o vacíos.</font></label></div>
                        <div class="row"><label><font size ="3">Poder modificar datos del proyecto. </font></label></div>
                         <div class="row"><label><font size ="3">Eliminar proyectos liberando así sus usuarios asignados.</font></label></div>
                         <div class="row"><label><font size ="3">Consultar datos del proyecto, representante del mismo y usuarios asociados a él.</font></label></div>
                     </div>
                         </div>
                      </div>
                    
                     <div class="row text-center">
                         <div class="col-lg-6">
                         <h4><font size = "4">Iteraciones</font></h4>
                            </div>
                         <div class="col-lg-6">
                         <h4><font size = "4">Modulos</font></h4>
                            </div>
                     </div>

                     <div class="row">
                         <div class="col-lg-6">
                      <div id="wellMio">
                        <div class="row"><label><font size ="3">Posibilidad de agregar iteraciones a cada proyecto.</font></label></div>
                        <div class="row"><label><font size ="3">Se puede agregar un nombre y una descripción a cada iteración.</font></label></div>
                         <div class="row"><label><font size ="3">Capacidad de observar un árbol de jerarquía con cada iteración de cada proyecto.</font></label></div>
                         <div class="row"><label><font size ="3">Capaz de eliminar y consultar iteraciones.</font></label></div>
                     </div>
                             </div>

                    <div class="col-lg-6">
                      <div id="wellMio">
                        <div class="row"><label><font size ="3">Poder agregar módulos a cada iteración de cada proyecto.</font></label></div>
                        <div class="row"><label><font size ="3">Ver en la jerarquía los módulos de cada iteración.</font></label></div>
                         <div class="row"><label><font size ="3">Agregar nombre y descripción a cada módulo.</font></label></div>
                         <div class="row"><label><font size ="3">Capaz de eliminar y consultar módulos.</font></label></div>
                     </div>
                        </div>
                         </div>

                     <div class="row text-center">
                         <div class ="col-lg-6">
                             <div style="width:100%; margin-right: 800px; margin-left: 400px; position:relative; float: left">
                         <h4><font size = "4">Requerimientos</font></h4>
                              </div>
                            </div>
                     </div>
                     <div class ="col-lg-6">
                         <div style="width:100%; margin-right: 800px; margin-left: 400px; position:relative; float: left">
                      <div id="wellMio2">
                        <div class="row"><label><font size ="3">Se pueden agregar Requerimientos funcionales y no funcionales.</font></label></div>
                        <div class="row"><label><font size ="3">Los requerimientos pueden ser asociados a módulos directamente o huérfanos(directamente a su proyecto).</font></label></div>
                         <div class="row"><label><font size ="3">Posibilidad de subir archivos con requerimientos al sistema.</font></label></div>
                         <div class="row"><label><font size ="3">Modificar, consultar, eliminar requerimientos de una forma completa.</font></label></div>
                     </div>
                             </div>
                     </div>

                 </fieldset>

             </div>
          </div>



    <%--<img alt="HTML5 Icon" src="../Images/flecha.png" width="50" height="25" />--%>

</asp:Content>
