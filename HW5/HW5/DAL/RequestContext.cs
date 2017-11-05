﻿using HW5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HW5.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=OurDBContext")
        { }

        public virtual DbSet<Request> Requests { get; set; } 
    }
}