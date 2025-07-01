using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fendahl_Frm_Training_MVC.Models;

namespace Fendahl_Frm_Training_MVC.Services
{
    public interface IFeedbackServices
    {
        bool AddFeedBack(FEEDBACK feedback);
    }
}
