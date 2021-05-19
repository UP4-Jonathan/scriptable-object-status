using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="New Move Builder", menuName="Tools/Move Check Builder")]
public class MoveCheckBuilder : ScriptableObject
{
        public MoveCheck[] checks;
}

[System.Serializable]
public class MoveCheck
{
    public NameVariable nameVariable;
    public bool value;
}
