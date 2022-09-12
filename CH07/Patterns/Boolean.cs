using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Patterns; 
class Boolean {
public bool CheckIfThingsFail(int x) {
  if (verySlowCheck() && x > 5) {
    return true;
  }
  return false;
}

private bool verySlowCheck() {
  Thread.Sleep(1000);
  return true;
}
}
