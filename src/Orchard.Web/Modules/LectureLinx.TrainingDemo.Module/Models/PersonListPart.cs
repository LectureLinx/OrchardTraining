using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.ContentManagement.Utilities;
using Orchard.Environment.Extensions;

namespace LectureLinx.TrainingDemo.Module.Models
{
    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class PersonListPart : ContentPart<PersonListPartRecord>
    {
        public Sex Sex
        {
            get { return Retrieve(x => x.Sex, Sex.Female); }
            set { Store(x => x.Sex, value); }
        }

        [Range(1, int.MaxValue)]
        public int MaxCount
        {
            get { return this.Retrieve(x => x.MaxCount, 5); }
            set { this.Store(x => x.MaxCount, value); }
        }

        private readonly LazyField<IEnumerable<PersonRecord>> _persons = new LazyField<IEnumerable<PersonRecord>>();
        internal LazyField<IEnumerable<PersonRecord>> PersonsField { get { return _persons; } }
        public IEnumerable<PersonRecord> Persons { get { return _persons.Value; } }
    }


    [OrchardFeature("LectureLinx.TrainingDemo.Module.Contents")]
    public class PersonListPartRecord : ContentPartRecord
    {
        public virtual Sex Sex { get; set; }
    }
}