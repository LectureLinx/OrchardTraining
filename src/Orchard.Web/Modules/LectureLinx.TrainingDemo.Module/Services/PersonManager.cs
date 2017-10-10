using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LectureLinx.TrainingDemo.Module.Models;
using Orchard.Data;

namespace LectureLinx.TrainingDemo.Module.Services
{
    public class PersonManager : IPersonManager
    {
        private readonly IRepository<PersonRecord> _personRecordRepository;


        public PersonManager(IRepository<PersonRecord> personRecordRepository)
        {
            _personRecordRepository = personRecordRepository;
        }


        public PersonRecord CreatePerson(string name, Sex sex, DateTime birthDateUtc, string biography)
        {
            var newPerson = new PersonRecord
            {
                Name = name,
                Sex = sex,
                BirthDateUtc = birthDateUtc,
                Biography = biography
            };

            _personRecordRepository.Create(newPerson);

            return newPerson;
        }

        public IEnumerable<PersonRecord> GetPersons(Sex sex)
        {
            return _personRecordRepository.Table.Where(person => person.Sex == sex);
        }
    }
}