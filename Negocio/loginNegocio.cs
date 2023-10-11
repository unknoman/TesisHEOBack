using Datos;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Modelos;
using Modelos.ModelosDTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TesisHEOBack.Modelos;

namespace Negocio
{
    public class loginNegocio
    {

          public static dynamic login (UsuarioDTO login, IConfiguration _configuration)
      {

             Usuario usuario = new Usuario();


          usuario.Usuario1 = login.usuario1;
          usuario.Password = login.password;



           var usuario1 = loginDatos.login(usuario);
          if (usuario1 == null)
          {
              return new
              {
                  sucess = false
              };
          } 


          var jwt = _configuration.GetSection("JwtSettings").Get<JwtModel>();

          var claims = new[] 
          {
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                  new Claim(JwtRegisteredClaimNames.Sub, usuario1.Idusuario.ToString()),
                  new Claim("usuario", usuario1.Usuario1),
                  new Claim("idRol", usuario1.Idrol.ToString()),
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

