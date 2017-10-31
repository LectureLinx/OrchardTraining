using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module.Controllers
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class ContentsController : Controller
    {
        private readonly IContentManager _contentManager;


        public ContentsController(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }


        public string Index()
        {
            //_contentManager.Get(29, VersionOptions.Published);
            //_contentManager.GetMany()
            var itemsQuery = _contentManager
                .Query("Page")
                //.Where<PersonListPartRecord>(record => record.Sex == Sex.Female)
                .OrderBy<TitlePartRecord>(record => record.Title);

            var itemCount = itemsQuery.Count();
            var items = itemsQuery.List();

            return "OK";
        }
    }
}