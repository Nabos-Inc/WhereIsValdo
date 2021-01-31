using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Valdo/LevelData")]
public class LevelData : ScriptableObject {
    public bool isMale;
    [Header("Body")]
    public bool isBodyTargeted;
    public BodyPartData targetBody;
    public Color targetSkinColor;

    [Header("Hair")]
    public bool isHairTargeted;
    public BodyPartData targetHair;
    public Color targetHairColor;

    [Header("Shirt")]
    public bool isShirtTargeted;
    public BodyPartData targetShirt;
    public Color targetShirtColor;

    [Header("Pants")]
    public bool isPantsTargeted;
    public BodyPartData targetPants;
    public Color targetPantsColor;

    [Header("Waldorf")]
    public string waldorfText;

    [Header("Audio")]
    public AudioClip bgm;

    public bool IsTarget(CharacterAppearanceData data) {
        if (isBodyTargeted && targetBody.isMale != data.isMale) return false;
        if (isHairTargeted && !IsTargetPart(data.hair, targetHair, targetHairColor)) return false;
        if (isShirtTargeted && !IsTargetPart(data.shirt, targetShirt, targetShirtColor)) return false;
        if (isPantsTargeted && !IsTargetPart(data.pants, targetPants, targetPantsColor)) return false;

        return true;
    }

    private bool IsTargetPart(BodyPartAppearanceData data, BodyPartData bodyPart, Color color) {
        var partTarget = (bodyPart == null) || (data.bodyPartData.animatorController == bodyPart.animatorController);
        return partTarget && (data.color == color);
    }
}
