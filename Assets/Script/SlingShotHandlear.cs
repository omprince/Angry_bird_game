using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotHandlear : MonoBehaviour
{
    [Header("Line Renderers")]
    [SerializeField] private LineRenderer _leftLineRenderer;
    [SerializeField] private LineRenderer _rightLineRenderer;

    [Header("Sling Start")]
    [SerializeField] private Transform _SlingStartLEFT; 
    [SerializeField] private Transform _SlingStartRIGHT;
    [SerializeField] private Transform _CenterPosition;
    [SerializeField] private float _maxDistance = 3.5f;

    [Header("Sling Shot Area")]
    [SerializeField] private CreateSlingShotArea _slingShotArea;


    private Vector2 _SlingShotLinePosition;
    private bool _clickWithInArea;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && _slingShotArea.IsWithInSlingShotArea()) { 
            _clickWithInArea = true;
        }
        if (Mouse.current.leftButton.isPressed && _clickWithInArea) { 
            DrawSlingshot();
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame) { 
            _clickWithInArea = false;
        }
    }

    private void DrawSlingshot() {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _SlingShotLinePosition = _CenterPosition.position + Vector3.ClampMagnitude(touchPosition - _CenterPosition.position, _maxDistance);
        SetLine(_SlingShotLinePosition);
    }

    private void SetLine(Vector2 position) {
        _leftLineRenderer.SetPosition(0, position);
        _leftLineRenderer.SetPosition(1, _SlingStartLEFT.position);
        _rightLineRenderer.SetPosition(0, position);
        _rightLineRenderer.SetPosition(1, _SlingStartRIGHT.position);
    }

}
