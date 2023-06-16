
using OfficeOpenXml.Style;
using OfficeOpenXml;
using PruebaTecnica.Servicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PruebaTecnica
{
    public partial class Usuario : System.Web.UI.Page
    {
        Service1Client service = new Service1Client();
        private static Persona[] datos;
        private static string idSeleccion;

        protected void Adicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/UsuarioGestionar.aspx?Accion=Agregar");
        }

        protected void Modificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado())
                Response.Redirect("/UsuarioGestionar.aspx?Accion=Modificar&Id=" + idSeleccion);
        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado())
                Response.Redirect("/UsuarioGestionar.aspx?Accion=Eliminar&Id="+ idSeleccion);
        }


        public bool idSeleccionado()
        {
            int rowIndex = Grilla.SelectedIndex;
            if(rowIndex != -1)
            {
                GridViewRow selectedRow = Grilla.Rows[rowIndex];
                idSeleccion = selectedRow.Cells[0].Text;
                return true;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atención', text: 'Debe seleccionar alguno de los registros para realizar la acción', icon: 'warning'});", true);
                return false;
            }
            // Accede a los datos de la fila seleccionada
            
        }
        protected void Consultar_Click(object sender, EventArgs e)
        {
            datos = service.Consultar();
            LlenarGrilla();
            if(datos == null)
            {
                Modificar.Visible = false;
                Eliminar.Visible = false;
                Adicionar.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Información', text: 'No se encontro información en la base de datos, por favor agregue información', icon: 'info'});", true);
            }
            else
            {
                Modificar.Visible = true;
                Eliminar.Visible = true;
                Adicionar.Visible = true;
                exportar.Visible = true;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Información', text: 'Si desea modificar o eliminar alguno de los registros seleccione la fila correspondiente', icon: 'info'});", true);
            }
        }

        protected void Grilla_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Grilla.PageIndex = e.NewPageIndex;
            LlenarGrilla();

        }

        public void LlenarGrilla()
        {
            Grilla.DataSource = datos;
            Grilla.DataBind();
        }


        protected void exportar_ServerClick(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Panel();", true);
        }

        protected void Aceptar_ServerClick(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Nombre", typeof(string));
            dataTable.Columns.Add("Fecha Nacimiento", typeof(string));
            dataTable.Columns.Add("Sexo", typeof(string));

            foreach (Persona persona in datos)
            {
                dataTable.Rows.Add(persona.Id, persona.Nombre, persona.Fecha_Nacimiento.ToString("dd/MM/yyyy"), (persona.Sexo == "F") ? "Femenino" : (persona.Sexo == "M") ? "Masculino" : persona.Sexo);
            }
            if (RadioExcel.Checked)
            {  
                OfficeOpenXml.ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new OfficeOpenXml.ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Datos");
                    int columnIndex = 1;
                    foreach (DataColumn column in dataTable.Columns)
                    {
                        worksheet.Cells[1, columnIndex].Value = column.ColumnName;
                        columnIndex++;
                    }

                    int rowIndex = 2;
                    foreach (DataRow row in dataTable.Rows)
                    {
                        columnIndex = 1;
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            worksheet.Cells[rowIndex, columnIndex].Value = row[column.ColumnName];
                            columnIndex++;
                        }
                        rowIndex++;
                    }

                    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=datos.xlsx");

                    HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
                    HttpContext.Current.Response.End();
                }
                
            }
            if (Radiotxt.Checked) 
            {
                StringBuilder sb = new StringBuilder();
                int i = 0;
                // Agregar los encabezados de columna
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (i == 3)
                        sb.Append(column.ColumnName).Append("");
                    else
                        sb.Append(column.ColumnName).Append(",");

                    i++;
                }
                sb.AppendLine();

                // Agregar los datos de las filas
                foreach (DataRow row in dataTable.Rows)
                { 
                    i = 0;
                    foreach (var item in row.ItemArray)
                    {
                        if (i == 3)
                            sb.Append(item.ToString()).Append("");
                        else
                            sb.Append(item.ToString()).Append(",");

                        i++;
                    }
                    sb.AppendLine();
                }

                // Configurar la respuesta HTTP para descargar el archivo de texto
                HttpContext.Current.Response.ContentType = "text/plain";
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=datos.txt");

                // Escribir el contenido del archivo de texto en la respuesta HTTP
                HttpContext.Current.Response.Write(sb.ToString());
                HttpContext.Current.Response.End();
            }
        }

        protected void Grilla_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Grilla, "Select$" + e.Row.RowIndex); ;
                e.Row.CssClass = "fila";
            }
        }

    }
}