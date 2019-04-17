using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCFilters.Models.Filters
{
    public class LogExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var log = new ExceptionLog();
            log.Message = filterContext.Exception.Message;
            log.DateTime = DateTime.Now;

            var dbContext = new ApplicationDbContext();

            dbContext.ExceptionLogs.Add(log);
            dbContext.SaveChanges();

            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {   
                ViewName = "Error"
            };
        }
    }
}