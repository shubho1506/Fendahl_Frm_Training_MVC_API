using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fendahl_Frm_Training_MVC.DTO;
using Fendahl_Frm_Training_MVC.Models;
using Fendahl_Frm_Training_MVC.Repositories;

namespace Fendahl_Frm_Training_MVC.Services
{
    public class RegistrationServices : IRegistrationServices
    {
        private readonly IRegisterRepository _repository;

        public RegistrationServices()
        {
            _repository = new RegisterRepository();
        }
        public bool AddAsync(REGISTRATION registration)
        {
            //registration.ID = Convert.ToInt32(registration.ID);
            registration.AGE = Convert.ToInt32(registration.AGE);
            return _repository.AddAsync(registration);
        }

        public bool DeleteAsync(int id)
        {
            return (_repository.DeleteAsync(id));
        }

        public List<REGISTRATION> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public REGISTRATION GetByValueAsync(UpdateDTO updateDTO)
        {
            return _repository.GetByValueAsync(updateDTO.NAME,updateDTO.MOBILE_NUMBER);
        }

        public bool UpdateAsync(REGISTRATION registration)
        {
            return _repository.UpdateAsync(registration);
        }
    }
}