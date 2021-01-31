using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour {
    public GameObject creditsCanvas;
    public AudioClip clickClip;

    public void OpenCredits() {
        PlayClickSound();
        creditsCanvas.SetActive(true);
    }

    public void CloseCredits() {
        PlayClickSound();
        creditsCanvas.SetActive(false);
    }

    public void PlayClickSound() {
        GameManager.Instance.PlaySFX(clickClip);
    }
}
