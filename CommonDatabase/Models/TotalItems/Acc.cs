﻿using CommonDatabase.Models.Accessories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDatabase.Models.TotalItems
{
    public class Acc
    {
        public virtual Belt Belt { get; set; } = default!;
        public virtual EarRing EarRing { get; set; } = default!;
        public virtual Neckless Neckless { get; set; } = default!;
        public virtual Ring1 Ring1 { get; set; } = default!;
        public virtual Ring2 Ring2 { get; set; } = default!;
    }
}
