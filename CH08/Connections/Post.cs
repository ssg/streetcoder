using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connections; 
public class MismatchedPostCount {
public Guid UserId { get; set; }
public int Count { get; set; }
public int ActualCount { get; set; }
}

class Post {
private IDatabase db;
private Guid userId;

public Guid UserId { get; set; }

public void AddPost(PostContent content) {
  using (var transaction = db.BeginTransaction()) {
    db.InsertPost(content);
    int postCount = db.GetPostCount(userId);
    postCount++;
    db.UpdatePostCount(userId, postCount);
  }
}

public void UpdateAllPostCounts() {
var inconsistentCounts = db.GetMismatchedPostCounts();
foreach (var entry in inconsistentCounts) {
db.UpdatePostCount(entry.UserId, entry.ActualCount);
}
}
}

internal interface IDatabase {
IDisposable BeginTransaction();
int GetPostCount(Guid userId);
void InsertPost(PostContent content);
IQueryable<T> Query<T>();
IQueryable<MismatchedPostCount> GetMismatchedPostCounts();
void UpdatePostCount(Guid userId, int postCount);
}

public class PostContent {
}
