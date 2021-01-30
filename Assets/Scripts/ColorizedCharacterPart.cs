using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorizedCharacterPart: MonoBehaviour {
    public List<RuntimeAnimatorController> possibleMaleParts;
    public List<RuntimeAnimatorController> possibleFemaleParts;
    public List<Color> possibleColors;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    public void RandomizeColor() {
        spriteRenderer.color = possibleColors[Random.Range(0, possibleColors.Count)];
    }

    public void RandomizePart(bool isMale) {
        if (isMale) {
            animator.runtimeAnimatorController = possibleMaleParts[Random.Range(0, possibleMaleParts.Count)];
        } else {
            animator.runtimeAnimatorController = possibleFemaleParts[Random.Range(0, possibleMaleParts.Count)];
        }
    }

    public void SetColor(Color color) {
        spriteRenderer.color = color;
    }
}
