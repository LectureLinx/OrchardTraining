using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard;

namespace LectureLinx.TrainingDemo.Module.Services
{
    public interface IPersonManager : IDependency
    {
        PersonRecord CreatePerson(string name, Sex sex, DateTime birthDateUtc, string biography);
        IEnumerable<PersonRecord> GetPersons(Sex sex);
    }
}
