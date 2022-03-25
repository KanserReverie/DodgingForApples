using KinematicCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour, ICharacterController
{
    public KinematicCharacterMotor Motor;
    // Start is called before the first frame update
    void Start()
    {
        Motor.CharacterController = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public void BeforeCharacterUpdate(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public void PostGroundingUpdate(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public void AfterCharacterUpdate(float deltaTime)
    {
        throw new System.NotImplementedException();
    }

    public bool IsColliderValidForCollisions(Collider coll) => throw new System.NotImplementedException();

    public void OnGroundHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        throw new System.NotImplementedException();
    }

    public void OnMovementHit(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, ref HitStabilityReport hitStabilityReport)
    {
        throw new System.NotImplementedException();
    }

    public void ProcessHitStabilityReport(Collider hitCollider, Vector3 hitNormal, Vector3 hitPoint, Vector3 atCharacterPosition, Quaternion atCharacterRotation, ref HitStabilityReport hitStabilityReport)
    {
        throw new System.NotImplementedException();
    }

    public void OnDiscreteCollisionDetected(Collider hitCollider)
    {
        throw new System.NotImplementedException();
    }
}
