using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeredCharacterAnimator : MonoBehaviour {
    public List<Animator> animators;

    public void SetFloat(string name, float value) {
        foreach(Animator anim in animators) {
            anim.SetFloat(name, value);
        }
    }
}
