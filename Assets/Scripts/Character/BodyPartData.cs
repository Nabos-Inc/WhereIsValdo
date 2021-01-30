using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BodyPartData", menuName = "Valdo/Characters/BodyPartData")]
public class BodyPartData : ScriptableObject {
    public bool isMale = true;
    public RuntimeAnimatorController animatorController;
}
