using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService
{
    public class ProfileAccessService : IDataAccessService<Profile>
    {
        LearnWordsEntities db;
        public void Delete(Profile Entity)
        {
            using (db = new LearnWordsEntities())
            {
                Profile profile = db.Profiles.FirstOrDefault(p => p.ProfileID == Entity.ProfileID);
                db.Profiles.Remove(profile);
                db.SaveChanges();
            }
        }

        public Profile FindByID(object EntityID)
        {
            using (db = new LearnWordsEntities())
            {
                return db.Profiles.Find(EntityID);
            }
        }

        public Profile FindByLambda(Expression<Func<Profile, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Profiles.FirstOrDefault(Filter);
                }
            }
            return null;
        }

        public void Insert(Profile Entity)
        {
            using (db = new LearnWordsEntities())
            {
                db.Profiles.Add(Entity);
                db.SaveChanges();
            }
        }

        public List<Profile> Select(Expression<Func<Profile, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Profiles.Where(Filter).ToList();
                }
            }
            else
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Profiles.ToList();
                }
            }
        }

        public void Update(Profile Entity)
        {
            using (db = new LearnWordsEntities())
            {
                Profile profileToUpdate = db.Profiles.FirstOrDefault(p => p.ProfileID == Entity.ProfileID);
                profileToUpdate.ProfileName = Entity.ProfileName;
                profileToUpdate.ProfileUserName = Entity.ProfileUserName;
                profileToUpdate.ProfileUserLastName = Entity.ProfileUserLastName;
                profileToUpdate.ProfileTimeInterval = Entity.ProfileTimeInterval;
                profileToUpdate.ProfileFirstLang = Entity.ProfileFirstLang;
                profileToUpdate.ProfileSecondLang = Entity.ProfileSecondLang;
                db.SaveChanges();
            }
        }
    }
}
