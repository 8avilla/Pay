using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Blastic.Skylu.Transversal.Common;
using Blastic.Skylu.Aplicacion.Interface;
using Blastic.Skylu.Aplicacion.Dto;
namespace Blastic.Skylu.Servicio.Api.Controllers
{
	//MAPEADO Y GENERADO POR EXPRESS CODE

	[Route("api/[controller]")]
	[ApiController]
	public partial class TokenBlackListController : ControllerBase
	{
		private readonly ITokenBlackListApplication _tokenBlackListApplication;
		private readonly IAppLogger<TokenBlackListController> _logger;
		public TokenBlackListController(ITokenBlackListApplication tokenBlackListApplication, IAppLogger<TokenBlackListController> logger)
		{
			_tokenBlackListApplication = tokenBlackListApplication;
			_logger = logger;
		}

		//Buscar Todos
		[HttpGet]
		[Route("BuscarTodos")]
		public ActionResult<Respuesta<IEnumerable<TokenBlackListDto>>> BuscarTodos()
		{
			Respuesta<IEnumerable<TokenBlackListDto>> Respuesta = new Respuesta<IEnumerable<TokenBlackListDto>>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.BuscarTodos();
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		//Buscar Todos Con Dependencia
		[HttpGet]
		[Route("BuscarTodosConDependencia")]
		public ActionResult<Respuesta<IEnumerable<TokenBlackListDto>>> BuscarTodosConDependencia()
		{
			Respuesta<IEnumerable<TokenBlackListDto>> Respuesta = new Respuesta<IEnumerable<TokenBlackListDto>>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.BuscarTodosConDependencia();
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Buscar Por Id
		[HttpGet]
		[Route("BuscarPorId")]
		public ActionResult<Respuesta<TokenBlackListDto>> BuscarPorId(int iDtokenBlackList)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.BuscarPorId(iDtokenBlackList);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Buscar Por Id Con Dependencia
		[HttpGet]
		[Route("BuscarPorIdConDependencia")]
		public ActionResult<Respuesta<TokenBlackListDto>> BuscarPorIdConDependencia(int iDtokenBlackList)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.BuscarPorIdConDependencia(iDtokenBlackList);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Agregar
		[HttpPost]
		[Route("Agregar")]
		public ActionResult<Respuesta<TokenBlackListDto>> Agregar(TokenBlackListDto tipoArticulo)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.Agregar(tipoArticulo);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// METODO AGREGAR RANGO
		[HttpPost]
		[Route("AgregarRango")]
		public ActionResult<Respuesta<IEnumerable<TokenBlackListDto>>> AgregarRango([FromBody] IEnumerable<TokenBlackListDto> listaTokenBlackListDto)
		{
			Respuesta<IEnumerable<TokenBlackListDto>> Respuesta = new Respuesta<IEnumerable<TokenBlackListDto>>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.AgregarRango(listaTokenBlackListDto);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Modificar
		[HttpPut]
		[Route("Modificar")]
		public ActionResult<Respuesta<TokenBlackListDto>> Modificar(TokenBlackListDto tipoArticulo)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.Modificar(tipoArticulo);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Destruir
		[HttpDelete]
		[Route("Destruir")]
		public ActionResult<Respuesta<TokenBlackListDto>> Destruir(int iDtokenBlackList)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.Destruir(iDtokenBlackList);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// METODO ELIMINAR POR RANGO
		[HttpPost]
		[Route("EliminarRango")]
		public ActionResult<Respuesta<IEnumerable<TokenBlackListDto>>> EliminarRango([FromBody] IEnumerable<int> listaIDtokenBlackList)
		{
			Respuesta<IEnumerable<TokenBlackListDto>> Respuesta = new Respuesta<IEnumerable<TokenBlackListDto>>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.EliminarRango(listaIDtokenBlackList);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// METODO BUSCAR ELIMINADOS
		[HttpGet]
		[Route("BuscarEliminados")]
		public ActionResult<Respuesta<IEnumerable<TokenBlackListDto>>> BuscarEliminados()
		{
			Respuesta<IEnumerable<TokenBlackListDto>> Respuesta = new Respuesta<IEnumerable<TokenBlackListDto>>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.BuscarEliminados();
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

		// Eliminar
		[HttpDelete]
		[Route("Eliminar")]
		public ActionResult<Respuesta<TokenBlackListDto>> Eliminar(int iDtokenBlackList)
		{
			Respuesta<TokenBlackListDto> Respuesta = new Respuesta<TokenBlackListDto>();
			 try
			{
				Respuesta.Datos = _tokenBlackListApplication.Eliminar(iDtokenBlackList);
				_logger.LogInformation("Transaccion exitosa");
				return Ok(Respuesta);
			}
			catch (Exception e)
			{
				Respuesta.TieneErrores = true;
				Respuesta.Errores.AddRange(e.GetList());
				_logger.LogError(Respuesta.Errores);
				return BadRequest(Respuesta);
			}
		}

	}
}

