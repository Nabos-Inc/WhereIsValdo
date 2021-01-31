using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    [Header("Level Data")]
    public LevelData levelData;
    public Transform spawnPointParent;
    public Transform characterParent;

    [Header("UI")]
    public Image faderOverlay;
    public float faderSpeed = 2f;
    public GameObject waldorfGameObject;
    public Text waldorfText;

    private bool fading = false;

    public PolygonCollider2D cameraCollider;

    private IEnumerator Start()
    {
    GameManager.Instance.SetLevel(this);
    GameManager.Instance.Init();

    waldorfText.text = levelData.waldorfText;
    yield return new WaitForSeconds(3f);
    waldorfGameObject.SetActive(false);
    }

    public void FadeOutToNextLevel(AudioClip winClip) {
        if (!fading){
            GameManager.Instance.ChangeBGM(null);
            StartCoroutine(FadeOutCo(winClip));
        }
    }

    private IEnumerator FadeOutCo(AudioClip winClip) {
        fading = true;
        float t = 0f;
        var initialColor = faderOverlay.color;
        var targetColor = new Color(faderOverlay.color.r, faderOverlay.color.g, faderOverlay.color.b, 1f);
        var playedSound = false;

        while (faderOverlay.color.a < 1f) {
            t = Mathf.Clamp(t + Time.deltaTime, 0f, faderSpeed);
            if (t > 0.25f && !playedSound) {
                playedSound = true;
                GameManager.Instance.PlaySFX(winClip);
            }
            faderOverlay.color = Color.Lerp(initialColor, targetColor, t / faderSpeed);
            yield return null;
        }
        fading = false;
        GameManager.Instance.NextLevel();
    }
}
