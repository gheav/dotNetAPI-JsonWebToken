using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JsonWebToken_API.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "Y0ur_Secr3T-K3y-djhkkjhGFYUJHhjgjgKJLGHgljgblliGGLg6889yu9u9";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken( string id)
        {
            // Also note that securityKey length should be ? 256b
            // so you have to make sure that your private key has a proper length
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            // Finnaly create a Token
            var header = new JwtHeader(credentials);

            // Token will be good for 1 minutes
            DateTime Expiry = DateTime.UtcNow.AddMinutes(60);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            //Some PayLoad that contain information about the customer
            var payload = new JwtPayload
            {
               
                { "nip", id},
                { "exp", ts}
            };

            var secToken = new JwtSecurityToken(header, payload);

            var handler = new JwtSecurityTokenHandler();

            var tokenString = handler.WriteToken(secToken); // securityToken

            //Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;
        }
    }
}
