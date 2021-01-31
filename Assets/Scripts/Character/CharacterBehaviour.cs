using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBehaviour : MonoBehaviour {
    [Header("Animation")]
    public float speed = 0f;
    public float dirX = 0f;
    public float dirY = 0f;

    [Header("Speech")]
    public GameObject speechBubbleObject;
    public TextMeshPro speechBubbleText;

    [Header("Randomization")]
    public bool isMale = true;
    public CharacterAppearanceConfig appearanceConfig;

    private CharacterAppearanceData appearanceData;
    public CharacterAppearanceData AppearanceData
    {
        get { return appearanceData; }
    }

    private LayeredCharacterAnimator layeredCharacterAnimator;

    private void Awake() {
        layeredCharacterAnimator = GetComponent<LayeredCharacterAnimator>();
    }

    public void RandomizeAppearance() {
        appearanceData = layeredCharacterAnimator.Randomize(isMale, appearanceConfig);
    }

    private void Update() {
        layeredCharacterAnimator.SetFloat("Speed", speed);
        layeredCharacterAnimator.SetFloat("DirX", dirX);
        layeredCharacterAnimator.SetFloat("DirY", dirY);
    }

    private void OnMouseDown() {
        GameManager.Instance.OnCharacterClicked(this);
    }
}
