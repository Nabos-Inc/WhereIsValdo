using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

    public void SpawnCharacters(int numOfCharacters) {
        var nSpawnCenters = spawnPointParent.childCount;
        var targetIndex = UnityEngine.Random.Range(0, nSpawnCenters);

        for (var i = 0; i < numOfCharacters; i++) {
            var center = spawnPointParent.GetChild(i % nSpawnCenters).position;
            var spawn = GenerateRandomSpawn(center);
            SpawnAt(spawn, i == targetIndex, i);
        }
    }

    private void SpawnAt(Vector3 spawnPoint, bool isTarget, int index) {
        GameObject go = Instantiate<GameObject>(characterPrefab, spawnPoint, Quaternion.identity);
        go.transform.SetParent(characterParent);
        go.name = "Character " + index;
        CharacterBehaviour behaviour = go.GetComponent<CharacterBehaviour>();
        ApplyFilter(behaviour, isTarget);

        behaviour.appearanceConfig.randomizeGender = !isTarget;
        behaviour.isMale = targetIsMale;
        behaviour.RandomizeAppearance();
    }

    private Vector3 GenerateRandomSpawn(Vector3 center) {
        var radius = 3f;

        var offset = Vector3.ProjectOnPlane(
            UnityEngine.Random.insideUnitSphere * radius,
            Vector3.forward
        );

        var desired = center + offset;

        NavMeshHit hit;
        NavMesh.SamplePosition(desired, out hit, 1.0f, 1 << NavMesh.GetAreaFromName("Walkable"));

        return hit.position;
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
