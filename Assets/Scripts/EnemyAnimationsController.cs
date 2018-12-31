﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationsController{

    public readonly HoldGunStateBehaviour HoldGunIK;
    public readonly LookAtStateBehaviour LookAtIK;
    public readonly ClimbTopLadderStateBehaviour ClimbTopLadderAnimationBehaviour;
    public readonly TopLadderStateBehaviour TopLadderIK;

    private Transform _enemyTransform;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private MeleeEnemyBehaviour _enemyBehaviour;

    private int _zMovementAnimationParameter = Animator.StringToHash("ZMovement");
    private int _xMovementAnimationParameter = Animator.StringToHash("XMovement");

    private int _isGroundedAnimationParameter = Animator.StringToHash("IsGrounded");

    private int _horizontalRotationAnimationParameter = Animator.StringToHash("HorizontalRotation");
    private int _verticalVelocityAnimationParameter = Animator.StringToHash("VerticalVelocity");

    private int _punchParameter = Animator.StringToHash("Punch");
    private int _isAimingGunParameter = Animator.StringToHash("IsAiming");
    private int _isTwoHandedGunParameter = Animator.StringToHash("IsTwoHandedGun");
    private int _distanceFromGroundParameter = Animator.StringToHash("DistanceFromGround");
    private int _climbingAnimationParameter = Animator.StringToHash("Climbing");
    private int _climbTopAnimationParameter = Animator.StringToHash("ClimbTopLadder");

    private int _takePunchAnimationParameter = Animator.StringToHash("TakePunch");
    private int _enemyHealthParameter = Animator.StringToHash("Health");


    private int _resetParameter = Animator.StringToHash("Reset");

    public EnemyAnimationsController(Transform enemyTransform, MeleeEnemyBehaviour enemyBehaviour, Animator animator, NavMeshAgent navMeshAgent)
    {
        _animator = animator;
        _navMeshAgent= navMeshAgent;
        _enemyBehaviour = enemyBehaviour;

        HoldGunIK = _animator.GetBehaviour<HoldGunStateBehaviour>();
        LookAtIK = _animator.GetBehaviour<LookAtStateBehaviour>();
        ClimbTopLadderAnimationBehaviour = _animator.GetBehaviour<ClimbTopLadderStateBehaviour>();
        TopLadderIK = _animator.GetBehaviour<TopLadderStateBehaviour>();
    }

    public void Update()
    {
        _animator.SetFloat(_zMovementAnimationParameter, _enemyBehaviour.RelativeVelocity.z);
        _animator.SetFloat(_xMovementAnimationParameter, _enemyBehaviour.RelativeVelocity.x);
        //_animator.SetBool(_isGroundedAnimationParameter, _physicsController.IsGrounded());
        ////_animator.SetBool(_jumpingAnimationParameter, _physicsController.Jumping);

        _animator.SetFloat(_horizontalRotationAnimationParameter, _enemyBehaviour.RotationSpeed);
        //_animator.SetFloat(_verticalVelocityAnimationParameter, _physicsController.GetVelocity().y);

        ////_animator.SetFloat(_timeInAirAnimationParameter, _physicsController.GetTimeInAir());
        //_animator.SetFloat(_distanceFromGroundParameter, _physicsController.GetDistanceFromGround());
    }

    public void AimGun(bool aimGun)
    {
        HoldGunIK.SetIsAiming(aimGun);
        _animator.SetBool(_isAimingGunParameter, aimGun);
    }

    public void IsTwoHandedGun(bool isTwoHandedGun)
    {
        _animator.SetBool(_isTwoHandedGunParameter, isTwoHandedGun);
    }

    public void Punch()
    {
        _animator.SetTrigger(_punchParameter);
    }

    public void TakePunch()
    {
        _animator.SetTrigger(_takePunchAnimationParameter);
    }

    public void Climb(bool climb)
    {
        _animator.SetBool(_climbingAnimationParameter, climb);
    }
    public void ClimbTopLadder()
    {
        _animator.SetTrigger(_climbTopAnimationParameter);
    }

    public void SetHealth(int health)
    {
        _animator.SetInteger(_enemyHealthParameter, health);
    }

    public void SetLayerWeight(int layerIndex, float weight)
    {
        _animator.SetLayerWeight(layerIndex, weight);
    }

    public void ResetAnimations()
    {
        _animator.SetBool(_punchParameter, false);
        _animator.SetBool(_isAimingGunParameter, false);
        _animator.SetTrigger(_resetParameter);
    }

    public void ApplyRootMotion(bool apply)
    {
        _animator.applyRootMotion = apply;
    }
}
