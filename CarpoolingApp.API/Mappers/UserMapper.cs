// using CarpoolingApp.API.DTOs;

using CarpoolingApp.API.DTOs;
using CarpoolingApp.BLL.Models;

namespace CarpoolingApp.API.Mappers;

public static class UserMapper
{
    public static UserDTO ToDTO(this User model)
    {
        return new UserDTO
        {
            Id = model.Id,
            FullName = $"{model.FirstName} {model.LastName}",
            Email = model.Email,
            IsActive = model.IsActive
        };
    }

    public static UserDetailDTO ToDetailDTO(this User model, string institutionName, List<int> requestIds, List<int> roleIds)
    {
        return new UserDetailDTO
        {
            Id = model.Id,
            FullName = $"{model.FirstName} {model.LastName}",
            Email = model.Email,
            IsActive = model.IsActive,
            InstitutionName = institutionName,
            RequestIds = requestIds,
            RoleIds = roleIds
        };
    }

    public static User ToModel(this RegisterDTO dto)
    {
        return new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            InstitutionId = dto.InstitutionId,
            // On ne gère pas Password dans le BLL model,
            // c'est AuthService/Register qui va hasher et stocker.
        };
    }
}
