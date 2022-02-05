using FamiliaControl.Domain.Models;
using FamiliaControl.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamiliaControl.Service.Interfaces
{
    public interface IUserServices : IRepository<User>
    {
    }
}
