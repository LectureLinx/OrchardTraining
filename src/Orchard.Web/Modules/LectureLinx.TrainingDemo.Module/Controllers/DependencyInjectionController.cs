using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Notify;

namespace LectureLinx.TrainingDemo.Module.Controllers
{
    [Themed]
    public class DependencyInjectionController : Controller
    {
        private readonly INotifier _notifier;

        public Localizer T { get; set; }


        public DependencyInjectionController(INotifier notifier)
        {
            _notifier = notifier;

            T = NullLocalizer.Instance;
        }


        public ActionResult NotificationDemo()
        {
            _notifier.Information(T("Hello world!"));

            return View();
        }
    }
}