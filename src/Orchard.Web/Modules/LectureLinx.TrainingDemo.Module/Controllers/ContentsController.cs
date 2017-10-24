using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module.Controllers
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class ContentsController : Controller
    {
        public string Index()
        {
            return "OK";
        }
    }
}