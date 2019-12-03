using System;
using System.Collections.Generic;

namespace BRQ.HRTProject.WebAPI.DomainsContextDir
{
    public partial class TiposSkills
    {
        public TiposSkills()
        {
            Skills = new HashSet<Skills>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Skills> Skills { get; set; }
    }
}
