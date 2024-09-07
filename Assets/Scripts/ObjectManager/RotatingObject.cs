using UnityEngine;

public class RotatingObject : GameLevelObject
{

    [SerializeField]
    Vector3 angularVelocity;

    //void FixedUpdate () {
    public override void GameUpdate()
    {
        transform.Rotate(angularVelocity * Time.deltaTime);
    }
}