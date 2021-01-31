using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredCharacterAnimator : MonoBehaviour {
    public Animator body;
    public Animator shirt;
    public Animator pants;
    public Animator hair;

    public void SetFloat(string name, float value) {
        body.SetFloat(name, value);
        shirt.SetFloat(name, value);
        pants.SetFloat(name, value);
        hair.SetFloat(name, value);
    }

    public CharacterAppearanceData Randomize(bool isMale, CharacterAppearanceConfig config) {
        CharacterAppearanceData res = new CharacterAppearanceData();

        var gender = config.randomizeGender ? Random.value > 0.5f : isMale;
        res.isMale = gender;

        var bodyPart = body.GetComponent<ColorizedCharacterPart>();
        bodyPart.SetPart(gender ? config.maleBody : config.femaleBody);
        bodyPart.RandomizeColor(config.possibleSkinColors);

        res.shirt = RandomizePart(config.shirt, shirt, gender);
        res.pants = RandomizePart(config.pants, pants, gender);
        res.hair = RandomizePart(config.hair, hair, gender);

        return res;
    }

    private BodyPartAppearanceData RandomizePart(BodyPartConfig config, Animator anim, bool isMale) {
        BodyPartAppearanceData data = new BodyPartAppearanceData();

        var characterPart = anim.GetComponent<ColorizedCharacterPart>();
        data.bodyPartData = characterPart.RandomizePart(config.possibleParts, isMale);
        data.color = characterPart.RandomizeColor(config.possibleColors);

        return data;
    }
}
