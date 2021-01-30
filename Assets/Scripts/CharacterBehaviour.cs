using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
    public float speed = 0f;
    public float dirX = 0f;
    public float dirY = 0f;

    private LayeredCharacterAnimator layeredCharacterAnimator;

    private void Awake() {
        layeredCharacterAnimator = GetComponent<LayeredCharacterAnimator>();
    }

    private void Start() {
        layeredCharacterAnimator.Randomize();
    }

    private void Update() {
        layeredCharacterAnimator.SetFloat("Speed", speed);
        layeredCharacterAnimator.SetFloat("DirX", dirX);
        layeredCharacterAnimator.SetFloat("DirY", dirY);
    }
}
