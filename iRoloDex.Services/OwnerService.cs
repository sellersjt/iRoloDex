using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Services
{
    public class OwnerService
    {
        private readonly Guid _userId;

        public OwnerService(Guid userId)
        {
            _userId = userId;
        }
    }
}
