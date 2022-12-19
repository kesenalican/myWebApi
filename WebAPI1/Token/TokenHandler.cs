//using Microsoft.IdentityModel.Tokens;
//using static System.Net.Mime.MediaTypeNames;
//using System.IdentityModel.Tokens.Jwt;
//using System.Text;

//namespace WebAPI1.Token
//{
//    public class TokenHandler
//    {
//        readonly IConfiguration _configuration;

//        public TokenHandler(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }
//        public Token CreateAccessToken(int minute)
//        {
//            Application.Dtos.Token token = new();
//            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

//            SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha256);

//            token.Expiration = DateTime.UtcNow.AddMinutes(minute);

//            JwtSecurityToken securityToken = new(
//                audience: _configuration["Token:Audience"],
//                issuer: _configuration["Token:Issuer"],
//                expires: token.Expiration,
//                notBefore: DateTime.UtcNow,
//                signingCredentials: signingCredentials
//                );

//            JwtSecurityTokenHandler tokenHandler = new();
//            token.AccessToken = tokenHandler.WriteToken(securityToken);
//            return token;
//        }
//    }
//}
