using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// This is intended as a simple "targeting" system. The player themselves add enemy tokens, and when the GM tells them one is dead they manually remove it.
// Later this can be extended with HP that the GM sets.

[CreateAssetMenu (fileName = "Token", menuName = "Create Combat Token")]
public class CombatToken : ScriptableObject
{
    GameObject _tokenPrefab;
}
