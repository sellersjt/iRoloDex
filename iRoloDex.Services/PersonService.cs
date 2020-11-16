using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models.PersonModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Services
{
    public class PersonService
    {
        private readonly int _ownerId;
        public PersonService(int ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreatePerson(PersonCreate model)
        {
            var entity = new Person()
            {
                OwnerId = _ownerId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                HouseholdId = model.HouseholdId,
                RelationshipId = model.RelationshipId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Persons.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

       public IEnumerable<PersonListItem> GetPersons()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Persons
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new PersonListItem
                                {
                                    PersonId = e.PersonId,
                                    FirstName = e.FirstName,
                                    LastName = e.LastName,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email,
                                    RelationshipId = e.RelationshipId,
                                    OwnerId = e.OwnerId,
                                    HouseholdId = e.HouseholdId,
                                    Household = e.Household,
                                    Relationship = e.Relationship
                                }
                );
                return query.ToArray();
            }
        }

        public PersonDetail GetPersonById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == id && e.OwnerId == _ownerId);
                return
                    new PersonDetail
                    {
                        PersonId = entity.PersonId,
                        LastName = entity.LastName,
                        FirstName = entity.FirstName,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        RelationshipId = entity.RelationshipId,
                        HouseholdId = entity.HouseholdId,
                        OwnerId = entity.OwnerId
                    };
            }
        }

        public bool UpdatePerson(PersonEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Persons
                        .Single(e => e.PersonId == model.PersonId && e.OwnerId == _ownerId);

                entity.PersonId = model.PersonId;
                entity.LastName = model.LastName;
                entity.FirstName = model.FirstName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.RelationshipId = model.RelationshipId;
                entity.HouseholdId = model.HouseholdId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeletePerson(int personId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Persons
                    .Single(e => e.PersonId == personId && e.OwnerId == _ownerId);

                ctx.Persons.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
