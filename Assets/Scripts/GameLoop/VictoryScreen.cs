using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreen : MonoBehaviour {
    public AudioClip bgm;

    private void Start() {
        GameManager.Instance.ChangeBGM(bgm);
    }
}
