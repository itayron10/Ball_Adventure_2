using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "LockableItems/LockableItem")]
public class LockableItemSO : ScriptableObject
{
    [SerializeField] string Name;
    [SerializeField] int Cost;
    public bool isUnlocked; 
    public int GetCost => Cost;
    public string GetName => Name;
}
