using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using Services.Authentication;
using Services.Model;

namespace Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        BD_PruebasEntities1 bD_Pruebas;

        
        public bool Actualizar(Persona persona)
        {
            try
            {
                using (bD_Pruebas = new BD_PruebasEntities1())
                {
                    Persona datos = (from p in bD_Pruebas.Persona where p.Id == persona.Id select p).FirstOrDefault();
                    if (datos != null)
                    {
                        bD_Pruebas.Entry(datos).CurrentValues.SetValues(persona);
                        bD_Pruebas.SaveChanges();
                    }
                }
                insertLog("Se actualizo el registro con id = " + persona.Id, System.Reflection.MethodBase.GetCurrentMethod().Name, 1);
                return true;
            }
            catch (Exception ex)
            {
                insertLog(ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name, 2);
                return false;
            }
        }
        
        public bool Adicionar(Persona persona)
        {
            try
            {
                using (bD_Pruebas = new BD_PruebasEntities1())
                {
                    bD_Pruebas.Persona.Add(persona);
                    bD_Pruebas.SaveChanges();
                    insertLog("Se agrego el siguiente registro " + persona.Id, System.Reflection.MethodBase.GetCurrentMethod().Name, 1);
                    return true;
                }
            }
            catch (Exception ex)
            {
                insertLog(ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name, 2);
                return false;
            }
        }

        public IEnumerable<Persona> Consultar()
        {
            using (bD_Pruebas = new BD_PruebasEntities1())
            {
                return (from persona in bD_Pruebas.Persona select persona).ToList();
            }
        }

        public Persona ConsultarID(int id)
        {
            using (bD_Pruebas = new BD_PruebasEntities1())
            {
                return (from persona in bD_Pruebas.Persona where persona.Id == id select persona).FirstOrDefault();
            }
        }
        
        public bool Eliminar(int id)
        {
            try
            {
                using (bD_Pruebas = new BD_PruebasEntities1())
                {
                    var persona = bD_Pruebas.Persona.Find(id);
                    if (persona != null)
                    {
                        bD_Pruebas.Persona.Remove(persona);
                        bD_Pruebas.SaveChanges();
                        insertLog("Se elimino el registro con id = " + id, System.Reflection.MethodBase.GetCurrentMethod().Name, 1);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                insertLog(ex.StackTrace, System.Reflection.MethodBase.GetCurrentMethod().Name, 2);
                return false;
            }
        }

        public void insertLog(string log, string metodo, short tipoAccion)
        {
            using (bD_Pruebas = new BD_PruebasEntities1())
            {
                bD_Pruebas.Log.Add(new Log
                {
                    Metodo = metodo,
                    Descripcion = log,
                    Tipo_Accion = tipoAccion
                });
                bD_Pruebas.SaveChanges();
            }
        }
    }
}

