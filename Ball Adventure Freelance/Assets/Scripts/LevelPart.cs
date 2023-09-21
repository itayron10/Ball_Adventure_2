using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPart : MonoBehaviour
{
    [SerializeField] Transform endPoint;
    // a small offset so we will spawn the new level part before the player reach the end of the current level part so he won't look at nothing at the end
    [SerializeField] float bufferDistanceBeforeEndPoint = 20f;
    // how long to wait before destroy the part after we pass it's end
    [SerializeField] float destroyDuration;
    [SerializeField] float partLengthSquaredDistnace;
    public Transform GetEndPoint => endPoint;
    public float GetPartLengthSquaredDistnace => partLengthSquaredDistnace;
    public float GetDestroyDuration => destroyDuration;

    private void Awake()
    {
        ///Mybe calculate in editor?
        partLengthSquaredDistnace = (endPoint.position - transform.position).sqrMagnitude - (bufferDistanceBeforeEndPoint * bufferDistanceBeforeEndPoint);
    }

}
