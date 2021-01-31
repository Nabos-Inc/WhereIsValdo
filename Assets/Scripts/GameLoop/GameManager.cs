using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour {
    private static GameManager _instance;
    public static GameManager Instance
    {
        get { return _instance; }
    }
    public CharacterSpawner characterSpawner;
    public List<string> levelNames;
    public CinemachineConfiner confiner;

    private LevelData levelData;
    private Level currentLevel;
    private CharacterBehaviour lastClickedCharacter;
    private AudioSource audioSource;

    private void Awake() {
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        } else {
            Destroy(gameObject);
        }
    }

    public void Init() {
        lastClickedCharacter = null;
        ChangeBGM(levelData.bgm);

        var filter = new CharacterBodyFilter();
        if(levelData.isBodyTargeted) {
            // Body case
        }

        if(levelData.isHairTargeted) {
            if(levelData.targetHair) filter.hairFilter.partBlacklist.Add(levelData.targetHair);
            filter.hairFilter.colorBlackList.Add(levelData.targetHairColor);
        }

        if (levelData.isShirtTargeted) {
            if (levelData.targetShirt) filter.shirtFilter.partBlacklist.Add(levelData.targetShirt);
            filter.shirtFilter.colorBlackList.Add(levelData.targetShirtColor);
        }

        if (levelData.isPantsTargeted) {
            if (levelData.targetPants) filter.pantsFilter.partBlacklist.Add(levelData.targetPants);
            filter.pantsFilter.colorBlackList.Add(levelData.targetPantsColor);
        }
        characterSpawner.filter = filter;
        characterSpawner.SpawnCharacters();
    }

    public void SetCameraCollider(PolygonCollider2D collider) {
        confiner.m_BoundingShape2D = collider;
    }

    public void SetLevel(Level level) {
        currentLevel = level;
        levelData = level.levelData;
        characterSpawner.characterParent = level.characterParent;
        characterSpawner.spawnPointParent = level.spawnPointParent;
        characterSpawner.targetIsMale = level.levelData.isMale;
        
        SetCameraCollider(level.cameraCollider);
    }

    public void OnCharacterClicked(CharacterBehaviour character) {
        if (lastClickedCharacter != null) lastClickedCharacter.speechBubbleObject.SetActive(false);
        lastClickedCharacter = character;

        var correct = levelData.IsTarget(character.AppearanceData);
        string result = correct ? "You found me!" : "I'm not the one...";
        character.speechBubbleObject.SetActive(true);
        character.speechBubbleText.text = result;

        if (correct) currentLevel.FadeOutToNextLevel();
    }

    public void NextLevel() {
        if (levelNames.Count < 1) return;
        string nextLevelName = levelNames[0];
        levelNames.RemoveAt(0);

        SceneManager.LoadScene(nextLevelName);
    }

    public void ChangeBGM(AudioClip bgm) {
        audioSource.Stop();
        if (bgm != null) {
            audioSource.clip = bgm;
            audioSource.Play();
        }
    }

    public void ExitGame() {
        Application.Quit();
    }
}
