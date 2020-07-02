using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserService
    {
        User Login(string email, string password);
        void Add(User user);
        User GetByMail(string email);
    }
}
