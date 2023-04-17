using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
// Hola profe XD
namespace Negocio
{
    public class loginNegocio
    {

        public static dynamic login (Usuario login, IConfiguration _configuration)
        {

            Usuario usuario = new Usuario();

            usuario.Idusuario = 1;
            usuario.Usuario1 = "xD";
            usuario.Password = "xD";
            usuario.rolid = 1;



     
          /*   var usuario = LoginMetodos.login(login);
            if (usuario == null)
            {
                return new
                {
                    sucess = false,
                    message = "Usuario o contraseñas incorrectas"
                };
            } */


            var jwt = _configuration.GetSection("JwtSettings").Get<JwtModel>();

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, usuario.Idusuario.ToString()),
                    new Claim("usuario", usuario.Usuario1),
                    new Claim("idRol", usuario.rolid.ToString()),
                   // new Claim("rol", usuario.Idtipo.ToString()),
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));
            var SigIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.Now.AddDays(5),
                signingCredentials: SigIn);
             TokenJWT jwtObjeto = new TokenJWT();
             jwtObjeto.tokenJWT = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtObjeto;
        } 


    }

}

