
using Microsoft.AspNetCore.Mvc;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using JWT;
using JWT.Algorithms;
using System.IdentityModel.Tokens.Jwt;

namespace webApi_Turismo.utils.cls_tokenGenerator;
public class cls_tokenGenerator
    {
    private String _token = "ABE8CD119C28C_develop_AreaDev3456";
        private String token_id = null;
        public String fn_tokenBuilder(String usuario, String secuitykey) {
                var myKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._token));
                var claims = new[]
                   {
                        new Claim(ClaimTypes.NameIdentifier, usuario),
                        // Aquí podrías agregar más Claims del usuario
                    };

                var token = new JwtSecurityToken(
                    issuer: "demo",
                    audience: "henry15eaDEV",
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: new SigningCredentials(myKey, SecurityAlgorithms.HmacSha256Signature));

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                

                return tokenString.ToString(); 
        }// end token builderr

            public bool fn_ValidateToken(string token)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(this._token);

                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                try
                {
                    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            //end fn_tokenValidator
}
