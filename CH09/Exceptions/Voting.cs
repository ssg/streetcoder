using Microsoft.AspNetCore.Mvc;
using System;

namespace Exceptions; 
public enum VotingResult {
Success,
ContentTooOld,
ContentDeleted,
}

public class Voting : Controller {
private readonly IDatabase db;

[HttpPost]
public IActionResult Upvote(Guid contentId) {
  var result = db.Upvote(contentId);
  return result switch {
    VotingResult.Success
      => success(),
    VotingResult.ContentTooOld
      => warning("Content is too old. It can't be voted"),
    VotingResult.ContentDeleted
      => warning("Content is deleted. It can't be voted"),
  };
}

private IActionResult success() {
  throw new NotImplementedException();
}

private IActionResult warning(string v) {
  throw new NotImplementedException();
}
}
