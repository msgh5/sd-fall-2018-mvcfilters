﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFilters.Models
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }
}