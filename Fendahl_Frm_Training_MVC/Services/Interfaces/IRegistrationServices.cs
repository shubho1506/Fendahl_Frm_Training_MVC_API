using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fendahl_Frm_Training_MVC.DTO;
using Fendahl_Frm_Training_MVC.Models;

namespace Fendahl_Frm_Training_MVC.Services
{
    public interface IRegistrationServices
    {
        List<REGISTRATION> GetAllAsync();
        REGISTRATION GetByValueAsync(UpdateDTO updateDTO);
        bool AddAsync(REGISTRATION registration);
        bool UpdateAsync(REGISTRATION registration);
        bool DeleteAsync(int id);
    }
}
