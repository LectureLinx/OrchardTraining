using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LectureLinx.TrainingDemo.Module.Models;
using LectureLinx.TrainingDemo.Module.Services;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Environment;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module.Handlers
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class PersonListPartHandler : ContentHandler
    {
        public PersonListPartHandler(
            IRepository<PersonListPartRecord> repository,
            Work<IPersonManager> personManagerWork)
        {
            Filters.Add(StorageFilter.For(repository));

            OnActivated<PersonListPart>((context, part) =>
                part.PersonsField.Loader(() => personManagerWork.Value.GetPersons(part.Sex).Take(part.MaxCount)));
        }
    }
}