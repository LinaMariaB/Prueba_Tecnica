<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsuarioGestionar.aspx.cs" Inherits="PruebaTecnica.UsuarioGestionar" MasterPageFile="~/Default.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="Content1">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <h1>Usuarios Gestionar</h1>

    <div class="miga-Pan" style="margin: 30px">
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li>
                    <a href="/Usuario.aspx">Usuario</a>
                </li>
                <li class="active" aria-current="page" runat="server" id="Gestionar">Usuario Gestionar</li>
            </ol>
        </nav>
    </div>
    <div class="Agregar" runat="server" id="Agregar">
        <label class="lblSubtitulo" runat="server" id="texto">Ingrese los datos que desea adicionar</label>
        <div class="filas">
            <div class="columnas" runat="server" id="DivId" visible="false">
                <label>Id</label>
                <input type="text" name="name" value="" runat="server" id="IdTxt" disabled/>
            </div>
            <div class="columnas">
                <label>Nombre</label>
                <input type="text" name="name" value="" runat="server" id="NombreAgregar"/>
            </div>
            <div class="columnas">
                <label>Fecha de nacimiento</label>
                <input type="date" name="name" value="" runat="server" id="FechaNacimientoAgregar"/>
            </div>
            <div class="columnas">
                <label>Sexo</label>
                <select class="form-select" title="sexo" runat="server" id="SexoAgregar">
                    <option disabled selected>Seleccione uno</option>
                    <option value="F">Femenino</option>
                    <option value="M">Masculino</option>
                </select>
            </div>
        </div>
        <button runat="server" onserverclick="Confirmar_ServerClick" id="button" style="margin-bottom:20px" class="btn">Adicionar</button>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="top: 30%;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body" style="margin-top:30px;">
                    <label style="font-size:18px">Confirmar cambios a guardar</label>
                </div>
                <div class="modal-footer" style="border-top:none; padding-top: 0;">
                    <button type="button" class="btn" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" runat="server" onserverclick="Aceptar_ServerClick" class="btn">Aceptar</button>
                </div>
            </div>
        </div>
    </div>



    <script>
        function Panel() {
            setTimeout(Cambio, 200);
            function Cambio() {
                $('.modal').modal('show');
            }
        }
    </script>
</asp:Content>

