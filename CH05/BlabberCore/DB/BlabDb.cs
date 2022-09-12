using Blabber.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blabber.DB;

public class BlabDb : IBlabDb
{
    private readonly BlabberContext db;

    public BlabDb(BlabberContext db)
    {
        this.db = db;
    }

    public void AddBlab(Blab blab)
    {
        db.Blabs.Add(new BlabEntity()
        {
            Content = blab.Content,
            CreatedOn = blab.CreatedOn.UtcDateTime,
        });
        db.SaveChanges();
    }

    public IEnumerable<Blab> GetAllBlabs()
    {
        return db.Blabs
          .OrderByDescending(b => b.CreatedOn)
          .Select(b => new Blab(b.Content,
            new DateTimeOffset(b.CreatedOn, TimeSpan.Zero)))
          .ToList();
    }
}