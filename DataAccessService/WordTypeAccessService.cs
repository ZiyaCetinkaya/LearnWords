using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService
{
    public class WordTypeAccessService : IDataAccessService<WordType>
    {
        LearnWordsEntities db;
        public void Delete(WordType Entity)
        {
            using (db = new LearnWordsEntities())
            {
                WordType wordType = db.WordTypes.FirstOrDefault(wt => wt.typeID == Entity.typeID);
                db.WordTypes.Remove(wordType);
                db.SaveChanges();
            }
        }

        public WordType FindByID(object EntityID)
        {
            using (db = new LearnWordsEntities())
            {
                return db.WordTypes.Find(EntityID);
            }
        }

        public WordType FindByLambda(Expression<Func<WordType, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.WordTypes.FirstOrDefault(Filter);
                }
            }
            return null;
        }

        public void Insert(WordType Entity)
        {
            using (db = new LearnWordsEntities())
            {
                db.WordTypes.Add(Entity);
                db.SaveChanges();
            }
        }

        public List<WordType> Select(Expression<Func<WordType, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.WordTypes.Where(Filter).ToList();
                }
            }
            else
            {
                using (db = new LearnWordsEntities())
                {
                    return db.WordTypes.ToList();
                }
            }
        }

        public void Update(WordType Entity)
        {
            using (db = new LearnWordsEntities())
            {
                WordType wordType = db.WordTypes.FirstOrDefault(wt => wt.typeID == Entity.typeID);
                wordType.typeName = Entity.typeName;
                wordType.profileID = Entity.profileID;
                db.SaveChanges();
            }
        }
    }
}
