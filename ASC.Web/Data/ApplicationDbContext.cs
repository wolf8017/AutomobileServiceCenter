﻿using ElCamino.AspNetCore.Identity.AzureTable;
using ElCamino.AspNetCore.Identity.AzureTable.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASC.Web.Data
{
    public class ApplicationDbContext : IdentityCloudContext
    {
       // public ApplicationDbContext() : base() { }
        public ApplicationDbContext(IdentityConfiguration config) : base(config) { }
    }
}
