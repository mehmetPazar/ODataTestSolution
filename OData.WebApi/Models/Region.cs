﻿using System;
using System.Collections.Generic;

namespace OData.WebApi.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string? RegionName { get; set; }

    public virtual ICollection<Country> Countries { get; } = new List<Country>();
}
