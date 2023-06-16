using Microsoft.IdentityModel.Tokens;
using PruebaTecnica.Servicio;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaTecnica
{
    public partial class UsuarioGestionar : System.Web.UI.Page
    {
        private static string accion;
        Service1Client service = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    accion = Request.QueryString["Accion"];
                    if (accion == "Agregar")
                    {
                        Gestionar.InnerText = "Gestionar Usuario - Agregar";
                        Agregar.Visible = true;
                    }
                    else
                    {
                        var id = Request.QueryString["Id"];
                        if (id != null)
                        {
                            Persona persona = personaConsultar(id);
                            if (persona != null)
                            {
                                if (accion == "Modificar")
                                {
                                    Gestionar.InnerText = "Gestionar Usuario - Modificar";
                                    DivId.Visible = true;
                                    IdTxt.Value = persona.Id.ToString();
                                    IdTxt.Disabled = true;
                                    NombreAgregar.Value = persona.Nombre;
                                    FechaNacimientoAgregar.Value = persona.Fecha_Nacimiento.ToString("yyyy-MM-dd");
                                    SexoAgregar.Value = persona.Sexo;
                                    button.InnerText = "Modificar";
                                    texto.Visible = false;
                                }
                                if (accion == "Eliminar")
                                {
                                    Gestionar.InnerText = "Gestionar Usuario - Eliminar";
                                    DivId.Visible = true;
                                    IdTxt.Value = persona.Id.ToString();
                                    IdTxt.Disabled = true;
                                    NombreAgregar.Value = persona.Nombre;
                                    NombreAgregar.Disabled = true;
                                    FechaNacimientoAgregar.Value = persona.Fecha_Nacimiento.ToString("yyyy-MM-dd");
                                    FechaNacimientoAgregar.Disabled = true;
                                    SexoAgregar.Value = persona.Sexo;
                                    SexoAgregar.Disabled = true;
                                    button.InnerText = "Eliminar";
                                    texto.Visible = false;
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'El registro no existe', icon: 'error'});", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'No se encontro id para realizar la acción', icon: 'error'});", true);
                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public Persona personaConsultar(string id)
        {
            try
            {
                return service.ConsultarID(int.Parse(id));
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void Aceptar_ServerClick(object sender, EventArgs e)
        {
            bool respuesta;
            if (accion == "Agregar")
            {
                string jwtToken = ObtenerTokenJwt(); // Implementa la lógica para obtener el token JWT válido

                var request = HttpContext.Current.Request;
                request.Headers.Add("Authorization", "Bearer " + jwtToken);
                respuesta = service.Adicionar(new Persona
                {
                    Nombre = NombreAgregar.Value,
                    Fecha_Nacimiento = DateTime.Parse(FechaNacimientoAgregar.Value),
                    Sexo = SexoAgregar.Value,
                });
                if (respuesta)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se adicionaron los datos correctamente', icon: 'success'});", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se presento un inconveniente al adicionar los datos', icon: 'error'});", true);
                }
            }
            if (accion == "Modificar")
            {
                string jwtToken = ObtenerTokenJwt(); // Implementa la lógica para obtener el token JWT válido

                var request = HttpContext.Current.Request;
                request.Headers.Add("Authorization", "Bearer " + jwtToken);
                //service.ClientCredentials = new System.ServiceModel.Description.ClientCredentials();
                respuesta = service.Actualizar(new Persona
                {
                    Id = int.Parse(IdTxt.Value),
                    Nombre = NombreAgregar.Value,
                    Fecha_Nacimiento = DateTime.Parse(FechaNacimientoAgregar.Value),
                    Sexo = SexoAgregar.Value
                });
                if (respuesta)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se modificaron los datos correctamente', icon: 'success'});", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se presento un inconveniente al modificar los datos', icon: 'error'});", true);
                }
            }
            if (accion == "Eliminar")
            {
                string jwtToken = ObtenerTokenJwt(); // Implementa la lógica para obtener el token JWT válido

                var request = HttpContext.Current.Request;
                request.Headers.Add("Authorization", "Bearer " + jwtToken);
                respuesta = service.Eliminar(int.Parse(IdTxt.Value));
                if (respuesta)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se elimino el registro correctamente', icon: 'success'});", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Se presento un inconveniente al eliminar el registro', icon: 'error'});", true);
                }
            }
        }

        protected void Confirmar_ServerClick(object sender, EventArgs e)
        {
            if (NombreAgregar.Value == "" || FechaNacimientoAgregar.Value == "" || (SexoAgregar.Value != "F" && SexoAgregar.Value != "M"))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "swal({ title: 'Atencion', text: 'Ingrese todos los datos', icon: 'info'});", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "Panel();", true);
            }
        }

        private string ObtenerTokenJwt()
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Prueba_Tecnica")
                // Agrega otros claims según tus necesidades
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Prueba_Tecnica_Lina_M_Bocanegra_B"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "Prueba_Tecnica",
                audience: "Prueba_Tecnica",
                claims: claims,
                signingCredentials: credentials);
            // Implementa la lógica para obtener el token JWT válido desde tu fuente de autenticación (p. ej., almacenamiento, proveedor de identidad, etc.)
            // Puedes utilizar bibliotecas como System.IdentityModel.Tokens.Jwt para generar y validar tokens JWT.
            // Aquí tienes un ejemplo básico:
            var tokenHandler = new JwtSecurityTokenHandler();
            
            return tokenHandler.WriteToken(token);
        }
    }
}