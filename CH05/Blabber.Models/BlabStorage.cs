using System.Collections.Generic;

namespace Blabber.Models
{
    public interface IBlabDb
    {
        IEnumerable<Blab> GetAllBlabs();

        void AddBlab(Blab blab);
    }

    public class BlabStorage
    {
        private readonly IBlabDb db;

        public BlabStorage(IBlabDb db)
        {
            this.db = db;
        }

        public IEnumerable<Blab> GetAllBlabs()
        {
            return db.GetAllBlabs();
        }

        public void Add(Blab blab)
        {
            db.AddBlab(blab);
        }
    }
}