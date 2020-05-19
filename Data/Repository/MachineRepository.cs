using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repository
{
    public class MachineRepository : IMachineRepo
    {
        private JukeBoxDBContext context;
         public MachineRepository(JukeBoxDBContext _context)
        {
            context = _context;

        }
        public void Add(Machine entity)
        {
            context.Machines.Add(entity);
        }

        public IEnumerable<Machine> GetAll()
        {
            return context.Machines.ToList();
        }
    }
}
