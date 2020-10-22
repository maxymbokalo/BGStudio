using BGStudio.BLL.Registration.Dto;

namespace BGStudio.BLL.Registration
{
    public interface IRegistrationAppService
    {
         void RegisterNewUser(NewUserDto newUserDto);
    }
}