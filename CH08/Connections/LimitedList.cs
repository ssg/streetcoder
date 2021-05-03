using System.Collections.Generic;

namespace Connections {
class LimitedList<T> {
  private List<T> items = new();

  public LimitedList(int limit) {
    Limit = limit;
  }

  public bool Add(T item) {
    if (items.Count >= Limit) {
      return false;
    }
    lock (items) {
      if (items.Count >= Limit) {
        return false;
      }
      items.Add(item);
      return true;
    }
  }

  public bool Remove(T item) {
    lock (items) {
      return items.Remove(item);
    }
  }

  public int Count => items.Count;
  public int Limit { get; }
}
}
