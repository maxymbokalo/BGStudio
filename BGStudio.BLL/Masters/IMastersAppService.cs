using System.Collections;
using System.Collections.Generic;
using BGStudio.App.Models;

namespace BGStudio.BLL.Masters
{
    public interface IMastersAppService
    {
        IEnumerable<UserERD> GetAllMasters();
    }
}