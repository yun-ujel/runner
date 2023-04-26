using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerController", menuName = "InputController/PlayerController")]
// This script can be used to fill the custom-made space for Controllers.

// It provides 'Overridden' definitions for the methods required for the Controller scripts.
public class PlayerController : inputController
{
    // This will be used to see if the player has pressed the jump button or not
    public override bool RetrieveJumpInput()
    {
        return Input.GetButtonDown("Jump")
            || Input.GetKeyDown(KeyCode.X)
            || Input.GetKeyDown(KeyCode.V)
            || Input.GetKeyDown(KeyCode.B)
            || Input.GetKeyDown(KeyCode.E)
            || Input.GetKeyDown(KeyCode.H)
            || Input.GetKeyDown(KeyCode.M)
            || Input.GetKeyDown(KeyCode.Z)
            || Input.GetKeyDown(KeyCode.C);
    }

    // This will be used to return a float value based on the current movement keys the player is holding
    // For example, holding right will be +1, holding left will be -1, and holding both will be 0
    public override float RetrieveMoveInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    // This will be used to see if the player is currently holding the jump button or not,
    // I'll use this for variable jump heights
    public override bool RetrieveJumpStatus()
    {
        return Input.GetButton("Jump")
            || Input.GetKey(KeyCode.X)
            || Input.GetKey(KeyCode.V)
            || Input.GetKey(KeyCode.B)
            || Input.GetKey(KeyCode.E)
            || Input.GetKey(KeyCode.H)
            || Input.GetKey(KeyCode.M)
            || Input.GetKey(KeyCode.Z)
            || Input.GetKey(KeyCode.C);
    }
}
