using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Name Variable", menuName="Tools/New Name Variable")]
public class NameVariable : ScriptableObject
{
   public string Value {get{return this.name;}}
}
