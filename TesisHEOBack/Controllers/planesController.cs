﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Text.Json.Serialization;
using System.Text.Json;
using TesisHEOBack.Modelos;
using Modelos.ModelosDTO;
using Google.Type;
using Datos;

namespace TesisHEOBack.Controllers
{
    [ApiController]
    [Route("planes")]
    public class planesController : Controller
    {
        [HttpGet]
        [Route("planesList")]
        public dynamic listarPlanes()
        {
            return planesNegocio.listarPlanes();

        }


        [HttpPost]
        [Route("crearPlan")]
        public dynamic crearPlan(servicioDTO plan)
        {
           string resultado = planesNegocio.crearPlan(plan);
            if(resultado.Equals("0"))
            {
                return false;
            } else
            {
                return true;
            }

        }

        [HttpDelete]
        [Route("borrarPlan")]
        public dynamic borrarPlan(int id)
        {
            return planesNegocio.eliminarPlan(id);

        }


        [HttpPatch]
        [Route("actualizarPlan")]
        public dynamic actualizarPlan(servicioDTO plan)
        {
            return planesNegocio.actualizarPlan(plan);
        }
       

    }
}







