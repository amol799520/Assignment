using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.InterFaces
{
    public interface IMobileService
    {
        IEnumerable<Mobile> GetAllMobile();
        Mobile GetMobileById(int id);
        Mobile AddMobile(Mobile newItem);
        Mobile UpdateMobile(int id, Mobile newItem);
        void DeleteMobile(int id);
    }
}
