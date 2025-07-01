using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fendahl_Frm_Training_MVC.Models;

namespace Fendahl_Frm_Training_MVC.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {

        private readonly FENDAHL_EXAMINATION_Context _context;

        public FeedbackRepository()
        {
            _context =  new FENDAHL_EXAMINATION_Context();
        }

        public bool AddFeedBack(FEEDBACK feedback)
        {
            if (feedback == null)
            {
               return false;
            }
            _context.FEEDBACK.Add(feedback);
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
    }
}