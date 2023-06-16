using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace Services.Authentication
{
    public class JwtAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {

            HttpRequestMessageProperty requestProperty = operationContext
        .IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;

            string jwtToken = requestProperty.Headers["Authorization"]?.Replace("Bearer ", "");
            
            if (ValidarTokenJwt(jwtToken))
            {
                return true;
            }
            else
            {
                return false; 
            }
        }

        private bool ValidarTokenJwt(string jwtToken)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Prueba_Tecnica_Lina_M_Bocanegra_B"));

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,           
                ValidateIssuerSigningKey = true,      


                ValidIssuer = "Prueba_Tecnica",
                ValidAudience = "Prueba_Tecnica",

                IssuerSigningKey = securityKey
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                SecurityToken validatedToken;
                var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out validatedToken);

                if (claimsPrincipal.HasClaim(c => c.Type == "Name" && c.Value == "Prueba_Tecnica"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SecurityTokenException)
            {
                return false;
            }
        }

    }



       
    

}