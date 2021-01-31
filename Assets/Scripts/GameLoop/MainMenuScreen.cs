using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScreen : MonoBehaviour {
    public GameObject creditsCanvas;

    public void OpenCredits() {
        creditsCanvas.SetActive(true);
    }

    public void CloseCredits() {
        creditsCanvas.SetActive(false);
    }
}
