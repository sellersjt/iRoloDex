using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models.Owner;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iRoloDex.Services
{
    public class OwnerService
    {
        private readonly Guid _userId;

        public OwnerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateOwner(OwnerCreate model)
        {
            var entity =
                new Owner()
                {
                    Name = model.Name,
                    Email = model.Email
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Owners.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateOwner(OwnerUpdate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Owners
                        .Single(e => e.OwnerId == model.OwnerId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<OwnerList> GetOwners()
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var query =
                        ctx
                            .Owners
                            .Where(e => e.UserId == _userId)
                            .Select(
                                e =>
                                    new OwnerList
                                    {
                                        UserId = e.UserId,
                                        OwnerId = e.OwnerId,
                                        Name = e.Name,
                                        Email = e.Email
                                    }
                            );

                    return query.ToArray();
                }
            }

        public OwnerDetail GetOwnerById(int ownerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Owners
                        .Single(e => e.UserId == _userId && e.OwnerId == ownerId);
                return
                    new OwnerDetail
                    {
                        OwnerId = entity.OwnerId,
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }

        public bool DeleteOwner(int ownerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Owners
                        .Single(e => e.OwnerId == ownerId);

                ctx.Owners.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public OwnerDetail GetOwnerId()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Owners
                        .Single(e => e.UserId == _userId);
                return
                    new OwnerDetail
                    {
                        OwnerId = entity.OwnerId,
                        Name = entity.Name,
                        Email = entity.Email
                    };
            }
        }
    }
}