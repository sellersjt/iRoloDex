using iRoloDex.Data;
using iRoloDex.Data.Entities;
using iRoloDex.Models;
using iRoloDex.Models.RelationshipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iRoloDex.Services
{
    public class RelationshipService
    {
        private readonly Guid _userId;

        public RelationshipService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRelationship(RelationshipCreate model)
        {
            var entity = new Relationship()
            {
                RelationshipType = model.RelationshipType
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Relationships.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RelationshipListItem> GetRelationship()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Relationships
                    //.Where(e => e.OwnerId == _userId)
                    .Select(e => new RelationshipListItem
                    {
                        RelationshipId = e.RelationshipId,
                        RelationshipType = e.RelationshipType,
                        CreatedUtc = e.CreatedUtc
                    });
                return query.ToArray();
            }
        }

        public RelationshipDetail GetRelationshipById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Relationships
                    .Single(e => e.RelationshipId == id );
                return new RelationshipDetail
                {
                    RelationshipId = entity.RelationshipId,
                    RelationshipType = entity.RelationshipType
                };
            }
        }

        public bool UpdateRelationship(RelationshipEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Relationships
                    .Single(e => e.RelationshipId == model.RelationshipId );

                entity.RelationshipId = model.RelationshipId;
                entity.RelationshipType = model.RelationshipType;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRelationship(int relationshipId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Relationships
                    .Single(e => e.RelationshipId == relationshipId );

                ctx.Relationships.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
