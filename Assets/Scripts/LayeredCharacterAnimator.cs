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

    public void Randomize(bool isMale, CharacterAppearanceConfig config) {
        var gender = config.randomizeGender ? isMale : Random.value > 0.5f;
        var bodyPart = body.GetComponent<ColorizedCharacterPart>();
        bodyPart.SetPart(gender ? config.maleBody : config.femaleBody);
        bodyPart.RandomizeColor(config.possibleSkinColors);

        RandomizePart(config.shirt, shirt, gender);
        RandomizePart(config.pants, pants, gender);
        RandomizePart(config.hair, hair, gender);
    }

    private void RandomizePart(BodyPartConfig config, Animator anim, bool isMale) {
        var characterPart = anim.GetComponent<ColorizedCharacterPart>();
        characterPart.RandomizePart(config.possibleParts, isMale);
        characterPart.RandomizeColor(config.possibleColors);
    }
}
