using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterAppearanceConfig {
    public bool randomizeGender = false;
    public BodyPartData maleBody;
    public BodyPartData femaleBody;
    public List<Color> possibleSkinColors;
    public BodyPartConfig pants;
    public BodyPartConfig shirt;
    public BodyPartConfig hair;
}
