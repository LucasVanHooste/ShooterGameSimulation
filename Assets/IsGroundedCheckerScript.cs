﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGroundedCheckerScript : MonoBehaviour {

    private List<Collider> _colliders = new List<Collider>();

    public bool IsGrounded
    {
        get
        {
            if (_colliders.Count > 0)
                return true;
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger && !_colliders.Contains(other))
            _colliders.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (_colliders.Contains(other))
            _colliders.Remove(other);
    }
}
