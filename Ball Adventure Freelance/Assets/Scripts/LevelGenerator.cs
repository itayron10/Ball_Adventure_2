using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] List<LevelPart> levelParts;
    private LevelPart currentLevelPart, toDestroyLevelPart;


    private void Start()
    {
        int randomIndex = Random.Range(0, levelParts.Count - 1);
        LevelPart instance = Instantiate(levelParts[randomIndex], transform.position, Quaternion.identity);
        currentLevelPart = instance;
    }


    void LateUpdate()
    {
        Application.targetFrameRate = 40;
        float playerSquaredDistanceFromLevelPart = (player.position - currentLevelPart.transform.position).sqrMagnitude;
        float partLengthSquared = currentLevelPart.GetPartLengthSquaredDistnace;
        if (playerSquaredDistanceFromLevelPart >= partLengthSquared)
        {
            SpawnNewLevelPart();
        }
    }

    private void SpawnNewLevelPart()
    {
        int randomIndex = Random.Range(0, levelParts.Count);
        LevelPart instance =  Instantiate(levelParts[randomIndex], currentLevelPart.GetEndPoint.position, Quaternion.identity);
        toDestroyLevelPart = currentLevelPart;
        Destroy(toDestroyLevelPart.gameObject, toDestroyLevelPart.GetDestroyDuration);
        currentLevelPart = instance;
    }
}
