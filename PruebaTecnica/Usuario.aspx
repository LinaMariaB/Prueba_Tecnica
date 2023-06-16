<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Usuario.aspx.cs" Inherits="PruebaTecnica.Usuario" MasterPageFile="~/Default.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head" ID="Content1">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <h1>Usuarios</h1>
    <div class="consultar" style="display: flex; justify-content: space-evenly; align-items: center;">
        <button runat="server" onserverclick="Consultar_Click" class="btn">Consultar</button>
    </div>
    <div class="table-users" style="display:flex; justify-content:center">
        <asp:GridView Width="800px" runat="server" ID="Grilla" CssClass="table Grilla"  OnRowDataBound="Grilla_RowCreated" Culture="co-CO" AutoGenerateColumns="false" AllowPaging="true"
             PageSize="10" OnPageIndexChanging="Grilla_PageIndexChanging"
            SelectedIndex="-1" PagerStyle-CssClass="pagination">
            <SelectedRowStyle Font-Bold="true"  />
           
            <PagerStyle HorizontalAlign="Center" />
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" HeaderStyle-CssClass="header"  ></asp:BoundField>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="header" ></asp:BoundField>
                <asp:BoundField DataField="Fecha_Nacimiento" HeaderText="Fecha de nacimiento" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-CssClass="header" ></asp:BoundField>
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" HeaderStyle-CssClass="header" ></asp:BoundField>
            </Columns>
            <RowStyle CssClass="fila" />
        </asp:GridView>
        
        
    </div>
    <div class="butoons" runat="server" id="Botones">
        <div>
            <button runat="server" id="exportar" onserverclick="exportar_ServerClick" class="btn" visible="false">Exportar tabla</button>
        </div>
        <button runat="server" id="Adicionar" onserverclick="Adicionar_Click" class="btn" visible="false">Adicionar</button>
        <button runat="server" id="Modificar" onserverclick="Modificar_Click" class="btn" visible="false">Modificar</button>
        <button runat="server" id="Eliminar" onserverclick="Eliminar_Click" class="btn" visible="false">Eliminar</button>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" style="top: 30%;">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <div class="modal-body" style="margin-top:30px;">
                    <label style="font-size:18px">Elija el formato a exportar</label>
                    <div class="row">
                        <div class="col">
                            <asp:RadioButton Width="200px" CssClass="radio" ID="RadioExcel" runat="server" Checked="true" GroupName="Formato" Text="Excel" ValidationGroup="Aplicacion" Visible="true" />
                        </div>
                        <div class="col">
                            <asp:RadioButton Width="125px" CssClass="radio" ID="Radiotxt" runat="server" GroupName="Formato" Text="txt" ValidationGroup="Aplicacion" Visible="true" />
                        </div>
                    </div>
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

        function seleccionarFila(row) {
            var claseSeleccionada = "seleccionada";
            if (row.className.indexOf(claseSeleccionada) === -1) {
                buscarClaseEnFilas(claseSeleccionada);
                row.className.A += " seleccionada";
                
            } else {
                row.className = row.className.replace(" seleccionada", "");
            }
        }

        function buscarClaseEnFilas(clase) {
            var filas = document.querySelectorAll(".Grilla tr");

            for (var i = 0; i < filas.length; i++) {
                if (filas[i].classList.contains(clase)) {
                    filas[i].classList.remove(clase)
                }
            }
        }
    </script>
</asp:Content>

