using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AI Data", menuName = "ScriptableObjects/AIScriptableObject")]
public class AIScriptableObject : ScriptableObject
{
    public string Name;
    public float AttackRange;
}
