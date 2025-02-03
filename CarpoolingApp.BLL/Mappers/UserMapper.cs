using CarpoolingApp.DB.Entities;

namespace CarpoolingApp.BLL.Mappers;

public static class UserMapper
{
    public static User ToEntity(this Models.User user)
    {
        return new User
        {
            Id = user.Id,
            LastName = user.LastName,
            FirstName = user.FirstName,
            Email = user.Email,
            InstitutionId = user.InstitutionId,
            IsActive = user.IsActive,
        };
    }

    public static User ToModel(this User user)
    {
        return new User
        {
            Id = user.Id,
            LastName = user.LastName,
            FirstName = user.FirstName,
            Email = user.Email,
            InstitutionId = user.InstitutionId,
            IsActive = user.IsActive,
        };
    }
}