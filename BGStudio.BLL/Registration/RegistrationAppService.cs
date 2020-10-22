using System.Threading.Tasks;
using BGStudio.App.Models;
using BGStudio.BLL.Registration.Dto;
using BGStudio.DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace BGStudio.BLL.Registration
{
    public class RegistrationAppService : IRegistrationAppService
    {
        private BGStudioAppContext _appContext;
        public RegistrationAppService(BGStudioAppContext bgStudioAppContext)
        {
            _appContext = bgStudioAppContext;
        }

        public void RegisterNewUser(NewUserDto newUserDto)
        {
            throw new System.NotImplementedException();
        }
    }
}