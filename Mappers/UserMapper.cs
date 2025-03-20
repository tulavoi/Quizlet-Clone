using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuizletClone.Areas.Identity.Data;
using QuizletClone.DTOs.User;

namespace QuizletClone.Mappers
{
	public static class UserMapper
	{
		public static UserDTO ToUserDTO(this AppUser user)
		{
			return new UserDTO
			{
				Id = user.Id,
				Username = user.UserName ?? string.Empty
			};
		}
	}
}
