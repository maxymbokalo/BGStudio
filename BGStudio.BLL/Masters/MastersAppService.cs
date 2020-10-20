using System.Collections.Generic;
using System.Linq;
using BGStudio.App.Models;
using BGStudio.DAL.EntityFramework;

namespace BGStudio.BLL.Masters
{
    public class MastersAppService : IMastersAppService
    {
        private BGStudioAppContext _appContext;

        public MastersAppService(BGStudioAppContext bgStudioAppContext)
        {
            _appContext = bgStudioAppContext;
        }
        public IEnumerable<UserERD> GetAllMasters()
        {
            return _appContext.Users.Where(user => user.RoleId == 2);
        }
    }
}