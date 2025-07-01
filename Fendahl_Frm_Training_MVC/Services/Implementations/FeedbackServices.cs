using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fendahl_Frm_Training_MVC.Models;
using Fendahl_Frm_Training_MVC.Repositories;

namespace Fendahl_Frm_Training_MVC.Services
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackServices()
        {
            _repository = new FeedbackRepository();
        }

        public bool AddFeedBack(FEEDBACK feedback)
        {
            if (_repository.AddFeedBack(feedback))
            {
                return true;
            } 
            return false;
        }
    }
}