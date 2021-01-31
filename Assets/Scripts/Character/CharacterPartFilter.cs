using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterPartFilter {
    public List<BodyPartData> partBlacklist;
    public List<Color> colorBlackList;

    public CharacterPartFilter() {
        partBlacklist = new List<BodyPartData>();
        colorBlackList = new List<Color>();
    }
}
