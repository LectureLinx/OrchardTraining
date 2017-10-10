using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data.Conventions;

namespace LectureLinx.TrainingDemo.Module.Models
{
    public class PersonRecord
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Sex Sex { get; set; }
        public virtual DateTime? BirthDateUtc { get; set; }
        [StringLengthMax]
        public virtual string Biography { get; set; }
    }


    public enum Sex
    {
        Male,
        Female,
        Other // Need to discuss with HR.
    }
}