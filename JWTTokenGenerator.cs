using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace JWTtoken
{
    public class JWTTokenGenerator
    {
        private readonly string _key;
        public JWTTokenGenerator(IConfiguration configuration)
        {
            _key = configuration["JWT:Key"];

        }
        public string GetToken()
        {
            var algo = SecurityAlgorithms.HmacSha256;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));

            var credentials = new SigningCredentials(securityKey, algo);

            var payload = new JwtPayload
            {
                {"timestamp",DateTimeOffset.Now.ToUnixTimeMilliseconds()},
                {"partnerId","PS001" },
                {"reqid","12233773" }
            };

            var header = new JwtHeader(credentials);

            var secToken = new JwtSecurityToken(header, payload);
            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenString = jwtHandler.WriteToken(secToken);

            return tokenString;
        }
    }
}
