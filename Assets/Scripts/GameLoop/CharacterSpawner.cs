using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour {
    public GameObject characterPrefab;

    [HideInInspector]
    public Transform spawnPointParent;
    [HideInInspector]
    public Transform characterParent;
    [HideInInspector]
    public bool targetIsMale = true;
    [HideInInspector]
    public CharacterBodyFilter filter;

    public void SpawnCharacters() {
        int targetIndex = UnityEngine.Random.Range(0, spawnPointParent.childCount);
        int count = 0;
        foreach (Transform child in spawnPointParent) {
            SpawnAt(child, targetIndex == count++, count);
        }
    }

    private void SpawnAt(Transform spawnPoint, bool isTarget, int index) {
        GameObject go = Instantiate<GameObject>(characterPrefab, spawnPoint.position, Quaternion.identity);
        go.transform.SetParent(characterParent);
        go.name = "Character " + index;
        CharacterBehaviour behaviour = go.GetComponent<CharacterBehaviour>();
        ApplyFilter(behaviour, isTarget);

        behaviour.appearanceConfig.randomizeGender = !isTarget;
        behaviour.isMale = targetIsMale;
        behaviour.RandomizeAppearance();
    }

    private void ApplyFilter(CharacterBehaviour behaviour, bool isTarget) {
        ApplyFilterTo(behaviour.appearanceConfig.hair, filter.hairFilter, isTarget);
        ApplyFilterTo(behaviour.appearanceConfig.shirt, filter.shirtFilter, isTarget);
        ApplyFilterTo(behaviour.appearanceConfig.pants, filter.pantsFilter, isTarget);
    }

    private void ApplyFilterTo(BodyPartConfig config, CharacterPartFilter filter, bool isTarget) {
        Func<BodyPartData, BodyPartData, bool> partDelegate = (a, b) => a == b;
        Func<Color, Color, bool> colorDelegate = (a, b) => a == b;
        if (isTarget) {
            partDelegate = (a, b) => a != b;
            colorDelegate = (a, b) => a != b;
        }

        foreach (BodyPartData data in filter.partBlacklist) {
            config.possibleParts.RemoveAll(x => partDelegate(x, data));
        }

        foreach (Color color in filter.colorBlackList) {
            config.possibleColors.RemoveAll(x => colorDelegate(x, color));
        }
    }
}
