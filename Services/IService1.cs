using Services.Authentication;
using Services.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;

namespace Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<Persona> Consultar();

        [OperationContract]
        bool Eliminar(int id);

        [OperationContract]
        bool Adicionar(Persona persona);

        [OperationContract]
        
        bool Actualizar(Persona persona);

        [OperationContract]
        Persona ConsultarID(int id);
    }
}
