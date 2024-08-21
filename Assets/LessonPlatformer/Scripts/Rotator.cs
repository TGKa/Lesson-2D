using UnityEngine;

public class Rotator
{
    private Vector2 _movementRight = new Vector2(0f, 0f);
    private Vector2 _movementLeft = new Vector2(0f, 180f);

    public Vector2 LookAt(bool isMovementRight)
    {
        return isMovementRight ? _movementRight : _movementLeft;
    }
}
