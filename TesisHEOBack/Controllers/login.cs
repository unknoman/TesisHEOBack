using Microsoft.AspNetCore.Mvc;
using Modelos;
using Modelos.ModelosDTO;
using Negocio;

namespace TesisHEOBack.Controllers
{
    [ApiController]
    [Route("Login")]
    public class loginController : Controller
    {
        private IConfiguration _configuration;

        public loginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

          [HttpPost]
          [Route("login")]
          public dynamic Login(UsuarioDTO login)
          {

              return loginNegocio.login(login, _configuration);
          }
    } 
}
