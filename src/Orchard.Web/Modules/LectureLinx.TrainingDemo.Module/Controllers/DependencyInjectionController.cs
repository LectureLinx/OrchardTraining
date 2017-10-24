using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LectureLinx.TrainingDemo.Module.Services;
using Orchard;
using Orchard.DisplayManagement;
using Orchard.Exceptions;
using Orchard.FileSystems.Media;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Mvc;
using Orchard.Themes;
using Orchard.UI.Notify;

namespace LectureLinx.TrainingDemo.Module.Controllers
{
    [Themed]
    public class DependencyInjectionController : Controller
    {
        private readonly INotifier _notifier;
        private readonly IHttpContextAccessor _hca;
        private readonly IWorkContextAccessor _wca;
        private readonly IPersonManager _personManager;
        private readonly IStorageProvider _storageProvider;
        private readonly dynamic _shapeFactory;

        public Localizer T { get; set; }

        public ILogger Logger { get; set; }


        public DependencyInjectionController(
            INotifier notifier,
            IHttpContextAccessor hca,
            IWorkContextAccessor wca,
            IPersonManager personManager,
            IStorageProvider storageProvider,
            IShapeFactory shapeFactory)
        {
            _notifier = notifier;
            _hca = hca;
            _wca = wca;
            _personManager = personManager;
            _storageProvider = storageProvider;
            _shapeFactory = shapeFactory;

            T = NullLocalizer.Instance;
            Logger = NullLogger.Instance;
        }


        public ActionResult NotificationDemo()
        {
            var workContext = _wca.GetContext();
            var currentUserName = workContext.CurrentUser == null ? T("Anonymous").Text : workContext.CurrentUser.UserName;

            _notifier.Information(
                T(
                    "Hello world! You're on page {0}. And you're named {1}, am I right?",
                    _hca.Current().Request.Url.ToString(),
                    currentUserName));

            return View();
        }

        public string LoggerDemo()
        {
            try
            {
                throw new Exception("Oh no!");
            }
            catch (Exception ex) // when (!ex.IsFatal())
            {
                if (ex.IsFatal())
                {
                    throw;
                }

                Logger.Error(ex, "Something bad happened.");
            }

            return "OK";
        }

        public string PersonManagerDemo()
        {
            //_personManager.CreatePerson("John Doe", Models.Sex.Male, DateTime.UtcNow, "This is my bio.");
            //_personManager.CreatePerson("Jane Doe", Models.Sex.Female, DateTime.UtcNow, "This is my bio.");
            //_personManager.CreatePerson("Jack Doe", Models.Sex.Male, DateTime.UtcNow, "This is my bio.");

            var persons = _personManager.GetPersons(Models.Sex.Male);

            //persons.First().Name = "Other name";

            return string.Join(", ", persons.Select(person => person.Name));
        }

        public string FileManagementDemo()
        {
            var file = _storageProvider.CreateFile("SubFolder/file.txt");
            using (var stream = file.OpenWrite())
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write("Hello files! " + DateTime.UtcNow.ToString());
            }

            return _storageProvider.ReadAllText("SubFolder/file.txt");
        }

        public ActionResult AdhocShapeDemo()
        {
            return new ShapeResult(this, _shapeFactory.DemoAdhocShape());
        }
    }
}