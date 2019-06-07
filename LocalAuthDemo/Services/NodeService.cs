using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocalAuthDemo.Contexts;
using LocalAuthDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalAuthDemo.Services
{
    public class NodeService : INodeService
    {
        LocalAuthDemoContext _context;

        public NodeService(LocalAuthDemoContext context)
        {
            _context = context;
        }

        public async Task<int> GetLastId()
        {
            List<Node> data = await _context.Nodes.ToListAsync();
            Node Root = data.OrderByDescending(d => d.Id).First();
            return Root.Id;
        }
    }
}
