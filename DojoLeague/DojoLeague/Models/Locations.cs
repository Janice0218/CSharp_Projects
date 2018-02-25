using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DojoLeague.Models
{
    public enum Locations
    {
        Rogue,
        Seattle,
        [Display(Name="San Jose")]
        SanJose,
        Dallas,
        Chicago,
        [Display(Name="Mountain View")]
        MountainView
    }
}
