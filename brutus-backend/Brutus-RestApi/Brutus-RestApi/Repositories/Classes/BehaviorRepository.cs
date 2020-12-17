using Brutus_RestApi.Models;
using Brutus_RestApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brutus_RestApi.Repositories.Classes
{
    public class BehaviorRepository : IBehaviorRepository
    {
        private mydbContext context;
        public BehaviorRepository(mydbContext context)
        {
            this.context = context;
        }
        public void Add(Behavior Contract)
        {
            context.Add<Behavior>(Contract);
            context.SaveChanges();
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(Behavior Contract)
        {
            throw new NotImplementedException();
        }

        public Behavior Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Behavior> GetAll()
        {
            return this.context.Behavior;
        }

        public void Update(Behavior Contract)
        {
            throw new NotImplementedException();
        }
    }
}
