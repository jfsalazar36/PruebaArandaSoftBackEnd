using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using PruebaArandaSoft.Api.Controllers;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Servicios;
using PruebaArandaSoft.Core.Utilidades;
using PruebaArandaSoft.Infraestructura.Data;
using PruebaArandaSoft.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PruebaArandaSoft.Test
{
    public class UsuarioControllerTest
    {
        [Fact]
        public async Task ValidarInicioSesion()
        {
            Usuarios usuarioMock = new Usuarios
            {
                UsuarioId = 1,
                PrimerApellido = "Prueba"
            };

            RolesPorUsuario rolesPorUsuarioMock = new RolesPorUsuario
            {
                RolId = 1,
                UsuarioId = 1,
                Rol = new Roles { Nombre = "Administrador", RolId = 1}
            };

            LoginDto objLoginDto = new LoginDto
            {
                Nombre = "admon",
                Password = "123"
            };

            UsuarioLoginDto objUsuarioLoginDto = new UsuarioLoginDto
            {
                PrimerNombre = "Javier",
                SegundoNombre = "Fernando",
                PrimerApellido = "Salazar",
                SegundoApellido = "Briceño",
                Token = "Administrador",
                UsuarioId = 1
            };

            IEnumerable<RolesPorUsuario> listaRoles = new List<RolesPorUsuario>
            {
                rolesPorUsuarioMock
            };

            Mock<IUsuarioRepository> usuarioRepository = new Mock<IUsuarioRepository>();
            Mock<IRolesPorUsuarioRepository> rolesPorUsuarioRepository = new Mock<IRolesPorUsuarioRepository>();
            usuarioRepository.Setup(s => s.ValidarAutenticacion(objLoginDto)).Returns(Task.FromResult(objUsuarioLoginDto));
            rolesPorUsuarioRepository.Setup(s => s.ObtenerRolesPorUsuario(1)).Returns(Task.FromResult(listaRoles));
            IUsuarioService usuarioService = new UsuarioService(usuarioRepository.Object);
            IRolesPorUsuarioService rolesPorUsuarioService = new RolesPorUsuarioService(rolesPorUsuarioRepository.Object);
            var controller = new UsuarioController(usuarioService, rolesPorUsuarioService);

            var result = await controller.ValidarInicioSesion(objLoginDto);

            Assert.True(result.Exitoso);
        }

        [Fact]
        public async Task CrearUsuario()
        {
            UsuarioDto objUsuarioDto = new UsuarioDto
            {
                Nombre = "Laura2105",
                PrimerNombre = "Laura",
                SegundoNombre = "Meliza",
                PrimerApellido = "Pamplona",
                SegundoApellido = "Mazo",
                Direccion = "Cl 123",
                Telefono = "12345",
                Email = "jfsa@hotmail.com",
                Edad = 28
            };

            Usuarios usuarioMock = new Usuarios
            {
                Nombre = objUsuarioDto.Nombre,
                Password = objUsuarioDto.Password,
                PrimerNombre = objUsuarioDto.PrimerNombre,
                SegundoNombre = objUsuarioDto.SegundoNombre,
                PrimerApellido = objUsuarioDto.PrimerApellido,
                SegundoApellido = objUsuarioDto.SegundoApellido,
                Direccion = objUsuarioDto.Direccion,
                Telefono = objUsuarioDto.Telefono,
                Email = objUsuarioDto.Email,
                Edad = objUsuarioDto.Edad
            };

            RolesPorUsuario rolesPorUsuarioMock = new RolesPorUsuario
            {
                RolId = 1,
                UsuarioId = 1
            };

            Mock<IUsuarioRepository> usuarioRepository = new Mock<IUsuarioRepository>();
            Mock<IRolesPorUsuarioRepository> rolesPorUsuarioRepository = new Mock<IRolesPorUsuarioRepository>();
            usuarioRepository.Setup(s => s.ConsultarUsuarioNombre("")).Returns(Task.FromResult(usuarioMock));
            usuarioRepository.Setup(s => s.CrearUsuario(usuarioMock)).Returns(Task.FromResult(usuarioMock));
            rolesPorUsuarioRepository.Setup(s => s.CrearRolPorUsuario(rolesPorUsuarioMock)).Returns(Task.FromResult(rolesPorUsuarioMock));
            IUsuarioService usuarioService = new UsuarioService(usuarioRepository.Object);
            IRolesPorUsuarioService rolesPorUsuarioService = new RolesPorUsuarioService(rolesPorUsuarioRepository.Object);
            var controller = new UsuarioController(usuarioService, rolesPorUsuarioService);

            var result = await controller.CrearUsuario(objUsuarioDto);
            Assert.True(result.Exitoso);
        }
    }
}
