using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This is a base that we can use for other controllers. There are 3 methods with no definition,
// which will later be 'overridden' with an actual definition on other controller scripts.

// This script is mostly used so that other controller scripts are more easily recognised as the same class.
// It'd be easy enough to just define these methods on their own in the other controllers, 
// but for the sake of them being interchangeable, this base controller script is necessary.
public abstract class inputController : ScriptableObject
{
    public abstract float RetrieveMoveInput();
    public abstract bool RetrieveJumpInput();
    public abstract bool RetrieveJumpStatus();
}
