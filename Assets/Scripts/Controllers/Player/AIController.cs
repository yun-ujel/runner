using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIController", menuName = "InputController/AIController")]
// This script can be used to fill the custom-made space for Controllers.

// It provides 'Overridden' definitions for the methods required for the Controller scripts,
// This time with values that will always be the same, mostly for testing purposes

// Some code from here could be reused if the player shouldn't have control over their jumps or horizontal movement
public class AIController : inputController
{
    public override bool RetrieveJumpInput()
    {
        return true;
    }

    public override float RetrieveMoveInput()
    {
        return 1f;
    }

    public override bool RetrieveJumpStatus()
    {
        return true;
    }
}
