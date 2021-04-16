﻿using Blabber.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Blabber.DB
{
    public class BlabDb : IBlabDb
    {
        private readonly BlabberContext _db;

        public BlabDb(BlabberContext db)
        {
            _db = db;
        }

        public void AddBlab(Blab blab)
        {
            _db.Blabs.Add(new BlabEntity()
            {
                // SQLite provider for .NET Framework doesn't
                // support auto generated GUID identifiers.
                Id = Guid.NewGuid(),
                Content = blab.Content,
                CreatedOn = blab.CreatedOn.UtcDateTime,
            });
            _db.SaveChanges();
        }

        public IEnumerable<Blab> GetAllBlabs()
        {
            return _db.Blabs
                .OrderByDescending(b => b.CreatedOn)
                .ToList()
                .Select(b => new Blab(b.Content,
                new DateTimeOffset(b.CreatedOn, TimeSpan.Zero)))
                .ToList();
        }
    }
}