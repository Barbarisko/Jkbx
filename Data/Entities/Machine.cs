using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Machine:IDentity
    {
        private List<Album> _albums;
        public List<Album> albums { get { return _albums; } set { _albums = value; } }

        public int MachineId { get; set; }
    }
}
