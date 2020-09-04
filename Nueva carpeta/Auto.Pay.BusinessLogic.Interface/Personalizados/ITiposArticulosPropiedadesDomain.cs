using System;
using Blastic.Skylu.Infraestructura.Entities;
using System.Collections.Generic;

namespace Blastic.Skylu.Dominio.Interface
{
    //MAPEADO Y GENERADO POR EXPRESS CODE

    public partial interface ITiposArticulosPropiedadesDomain
    {
        IEnumerable<TiposArticulosPropiedades> BuscarPropiedadPorIdTipoArticulo(int idTipoArticulo);

        IEnumerable<PropiedadesArticulos> BuscarPropiedadesExcluidasPorIdTipoArticulo(int idTipoArticulo);
    }
}
