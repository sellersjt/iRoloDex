using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models.HouseholdModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            // test code for CreatedAtRoute
            //using (var ctx = new ApplicationDbContext())
            //{
            //    Household newHousehold = ctx.Households.Add(entity);
            //    ctx.SaveChanges();
            //    return newHousehold;
            //}
        }

        public IEnumerable<HouseholdListItem> GetHouseholds()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                        //ctx.Households.Where(e => e.OwnerId == _ownerId)
                        ctx.Households.Include(e => e.Persons.Select(r => r.Relationships)).Where(e => e.OwnerId == _ownerId)
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
                            //Persons = e.Persons
                        }
                        
                );

                return query.ToArray();
            }
        }

        public HouseholdDetail GetHouseholdById(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            //.Households
                            .Households.Include(e => e.Persons)
                            .Single(e => e.HouseholdId == id && e.OwnerId == _ownerId);
                            //.Where(e => e.HouseholdId == id && e.OwnerId == _ownerId)
                            //.FirstOrDefault();
                    return
                        new HouseholdDetail
                        {
                            HouseholdId = entity.HouseholdId,
                            Street = entity.Street,
                            City = entity.City,
                            State = entity.State,
                            Zip = entity.Zip,
                            Owner = entity.Owner,
                            //Persons = entity.Persons
                        };
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool UpdateHousehold(HouseholdEdit model)
        {
            try
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
            catch (Exception)
            {

                return false;
            }
        }

        public int DeleteHousehold(int householdId)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Households
                            .Single(e => e.HouseholdId == householdId && e.OwnerId == _ownerId);

                    ctx.Households.Remove(entity);

                    if (ctx.SaveChanges() == 1)
                    {
                        return 1;
                    }
                }
            }
            catch (Exception)
            {

                return 2;
            }
            return 3;
        }
    }
}
