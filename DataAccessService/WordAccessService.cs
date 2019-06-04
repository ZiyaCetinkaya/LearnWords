using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessService
{
    public class WordAccessService : IDataAccessService<Word>
    {
        LearnWordsEntities db;
        public void Delete(Word Entity)
        {
            using (db = new LearnWordsEntities())
            {
                Word word = db.Words.FirstOrDefault(w => w.wordID == Entity.wordID);
                db.Words.Remove(word);
                db.SaveChanges();
            }
        }

        public Word FindByID(object EntityID)
        {
            using (db = new LearnWordsEntities())
            {
                return db.Words.Find(EntityID);
            }
        }

        public Word FindByLambda(Expression<Func<Word, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Words.FirstOrDefault(Filter);
                }
            }
            return null;
        }

        public void Insert(Word Entity)
        {
            using (db = new LearnWordsEntities())
            {
                db.Words.Add(Entity);
                db.SaveChanges();
            }
        }

        public List<Word> Select(Expression<Func<Word, bool>> Filter = null)
        {
            if (Filter != null)
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Words.Where(Filter).ToList();
                }
            }
            else
            {
                using (db = new LearnWordsEntities())
                {
                    return db.Words.ToList();
                }
            }
        }

        public void Update(Word Entity)
        {
            using (db = new LearnWordsEntities())
            {
                Word wordToUpdate = db.Words.FirstOrDefault(w => w.wordID == Entity.wordID);
                wordToUpdate.wordFirstLang = Entity.wordFirstLang;
                wordToUpdate.wordSecondLang = Entity.wordSecondLang;
                wordToUpdate.typeID = Entity.typeID;
                wordToUpdate.profileID = Entity.profileID;
                db.SaveChanges();
            }
        }
    }
}
