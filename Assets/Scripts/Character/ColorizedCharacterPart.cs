using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorizedCharacterPart: MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public Color RandomizeColor(List<Color> possibleColors) {
        spriteRenderer.color = possibleColors[Random.Range(0, possibleColors.Count)];
        return spriteRenderer.color;
    }

    public BodyPartData RandomizePart(List<BodyPartData> possibleParts, bool isMale) {
        List<BodyPartData> legalParts = possibleParts.Where(x => x.isMale == isMale).ToList();
        var data = legalParts[Random.Range(0, legalParts.Count)];
        animator.runtimeAnimatorController = data.animatorController;
        return data;
    }

    public void SetPart(BodyPartData config) {
        animator.runtimeAnimatorController = config.animatorController;
    }

    public void SetColor(Color color) {
        spriteRenderer.color = color;
    }
}
