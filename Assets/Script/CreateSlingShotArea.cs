using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CreateSlingShotArea : MonoBehaviour
{
    [SerializeField] private LayerMask _SlingShotAreaMAsk;



    public bool IsWithInSlingShotArea() {
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (Physics2D.OverlapPoint(worldPosition, _SlingShotAreaMAsk)) {
            return true;
        }
        else { 
            return false;
        }
    }
}
