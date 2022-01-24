using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public async Task<RespuestaDto<List<Roles>>> ConsultarUsuarioPorNombre()
        {
            RespuestaDto<List<Roles>> resultado = new RespuestaDto<List<Roles>>();

            try
            {
                resultado = await _rolesService.ObtenerRoles();
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al consultar los roles: " + ex.Message;
            }

            return resultado;
        }
    }
}
