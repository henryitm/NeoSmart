using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSmart.Shared.Entities
{
    public class CapacitationTheme
    {
        public int Id { get; set; }

        public int CapacitationId { get; set; }

        public Capacitation? Capacitation { get; set; }

        public int ThemeId { get; set; }

        public Theme? Theme { get; set; }

    }
}
