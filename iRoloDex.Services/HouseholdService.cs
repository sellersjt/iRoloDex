using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models.Household;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Services
{
    public class HouseholdService
    {
        private readonly int _ownerId;

        public HouseholdService(int ownerId)
        {
            _ownerId = ownerId;
        }

        public bool CreateHousehold(HouseholdCreate model)
        {
            var entity =
                new Household()
                {
                    OwnerId = _ownerId,
                    Street = model.Street,
                    City = model.City,
                    State = model.State,
                    Zip = model.Zip
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Households.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<HouseholdListItem> GetHouseholds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Households
                        .Where(e => e.OwnerId == _ownerId)
                        .Select(
                            e =>
                                new HouseholdListItem
                                {
                                    HouseholdId = e.HouseholdId,
                                    Street = e.Street,
                                    City = e.City,
                                    State = e.State,
                                    Zip = e.Zip,
                                    Owner = e.Owner,
                                    Persons = (ICollection<Models.Person>)e.Persons
                                }
                        );

                return query.ToArray();
            }
        }

        public HouseholdDetail GetHouseholdById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Households
                        .Single(e => e.HouseholdId == id && e.OwnerId == _ownerId);
                return
                    new HouseholdDetail
                    {
                        HouseholdId = entity.HouseholdId,
                        Street = entity.Street,
                        City = entity.City,
                        State = entity.State,
                        Zip = entity.Zip,
                        Owner = entity.Owner,
                        Persons = (ICollection<Models.Person>)entity.Persons
                    };
            }
        }

        public bool UpdateHousehold(HouseholdEdit model)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var entity =
                    dbContext
                        .Households
                        .Single(household =>
                        household.HouseholdId == model.HouseholdId &&
                        household.OwnerId == _ownerId);
                entity.Street = model.Street;
                entity.City = model.City;
                entity.State = model.State;
                entity.Zip = model.Zip;
                //entity.OwnerId = model.OwnerId;

                return dbContext.SaveChanges() == 1;
            }
        }

        public bool DeleteHousehold(int householdId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Households
                        .Single(e => e.HouseholdId == householdId && e.OwnerId == _ownerId);

                ctx.Households.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
