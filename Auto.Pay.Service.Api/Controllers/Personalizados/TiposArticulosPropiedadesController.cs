using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Blastic.Skylu.Transversal.Common;
using Blastic.Skylu.Infraestructura.Entities;
using Blastic.Skylu.Infraestructura.Entities;

namespace Blastic.Skylu.Servicio.Api.Controllers
{
    public partial class TiposArticulosPropiedadesController
	{
        //BuscarPropiedadPorIdTipoArticulo
        [HttpGet]
        [Route("BuscarPropiedadPorIdTipoArticulo")]
        public ActionResult<Respuesta<IEnumerable<TiposArticulosPropiedades>>> BuscarPropiedadPorIdTipoArticulo(int idTipoArticulo)
        {
            Respuesta<IEnumerable<TiposArticulosPropiedades>> Respuesta = new Respuesta<IEnumerable<TiposArticulosPropiedades>>();
            try
            {
                Respuesta.Datos = _tiposArticulosPropiedadesApplication.BuscarPropiedadPorIdTipoArticulo(idTipoArticulo);
                Respuesta.TieneErrores = true;
                Respuesta.Errores.Add("Transacción exitosa");
                _logger.LogInformation("Transacción exitosa");
                return Ok(Respuesta);
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetList());
                Respuesta.TieneErrores = false;
                Respuesta.Errores.AddRange(e.GetList());
                return BadRequest(Respuesta);
            }
        }

        //BuscarPropiedadPorIdTipoArticulo
        [HttpGet]
        [Route("BuscarPropiedadesExcluidasPorIdTipoArticulo")]
        public ActionResult<Respuesta<IEnumerable<PropiedadesArticulos>>> BuscarPropiedadesPorIdTipoArticulo(int idTipoArticulo)
        {
            Respuesta<IEnumerable<PropiedadesArticulos>> Respuesta = new Respuesta<IEnumerable<PropiedadesArticulos>>();
            try
            {
                Respuesta.Datos = _tiposArticulosPropiedadesApplication.BuscarPropiedadesExcluidasPorIdTipoArticulo(idTipoArticulo);
                Respuesta.TieneErrores = true;
                Respuesta.Errores.Add("Transacción exitosa");
                _logger.LogInformation("Transacción exitosa");
                return Ok(Respuesta);
            }
            catch (Exception e)
            {
                _logger.LogError(e.GetList());
                Respuesta.TieneErrores = false;
                Respuesta.Errores.AddRange(e.GetList());
                return BadRequest(Respuesta);
            }
        }
    }
}

