using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterBodyFilter {
    public CharacterPartFilter hairFilter;
    public CharacterPartFilter shirtFilter;
    public CharacterPartFilter pantsFilter;

    public CharacterBodyFilter() {
        hairFilter = new CharacterPartFilter();
        shirtFilter = new CharacterPartFilter();
        pantsFilter = new CharacterPartFilter();
    }
}
