using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionTargetHelper
{
    private float _acceptableAngle = 0.4f;
    private float _offsetRatio = 3f;

    public bool TrySeeTarget(Vector2 startPosition,Vector2 direction,float distance)
    {
        var hit = Physics2D.Raycast(startPosition, direction, distance);
        Debug.DrawRay(startPosition, direction * distance, Color.blue);

        if (hit && hit.collider.GetComponent<Player>())
            return true;

        return false;
    }

    public bool IsTargetSee(Transform startPosition, Vector3 target,float distance)
    {
        bool isTargetSee = false;
        float distanceTarget = Vector2.Distance(startPosition.position, target);
        float visibilityAngle = Vector2.Dot(startPosition.right, (target - startPosition.position).normalized);

        if (distanceTarget < distance + _offsetRatio && visibilityAngle >= _acceptableAngle)
            isTargetSee = true;
        return isTargetSee;
    }
}
