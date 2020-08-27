using System.Collections.Generic;
using System.Linq;
using System;

namespace Auto.Credibanco.Aplicacion.Dtos
{
	//MAPEADO Y GENERADO POR EXPRESS CODE
	public partial class TokenBlackListDto : EntidadDto
	{
	public int Id { get; set; }

	public string Token { get; set; }

	public DateTime FechaRegistro { get; set; }

	public string UserName { get; set; }

	public bool Eliminado { get; set; }

	}
	public static class TokenBlackListDtoExtensions
	{
		public static TokenBlackListDto ConvertToDto(this TokenBlackList entity)
		{
			if (entity == null)
			{
				return null;
			}
			return new TokenBlackListDto
			{
				Id = entity.Id,
				Token = entity.Token,
				FechaRegistro = entity.FechaRegistro,
				UserName = entity.UserName,
				Eliminado = entity.Eliminado,
			};
		}

		public static IEnumerable<TokenBlackListDto> ConvertToDto(this IEnumerable<TokenBlackList> entities)
		{
			return entities?.Select(x => x.ConvertToDto()).ToList();
		}

		public static TokenBlackList ConvertToEntity(this TokenBlackListDto entity)
		{
			if (entity == null)
			{
				return null;
			}

			return new TokenBlackList
			{
				Id = entity.Id,
				Token = entity.Token,
				FechaRegistro = entity.FechaRegistro,
				UserName = entity.UserName,
				Eliminado = entity.Eliminado,
			};
		}

		public static IEnumerable<TokenBlackList> ConvertToEntity(this IEnumerable<TokenBlackListDto> entities)
		{
			return entities?.Select(x => x.ConvertToEntity()).ToList();
		}

	}
}

