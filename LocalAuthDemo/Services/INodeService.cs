using LocalAuthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalAuthDemo.Services
{
    public interface INodeService
    {
        Task<int> GetLastId();
    }
}
