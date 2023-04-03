using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float _dumping = 1.5f;
    [SerializeField] private bool _isFacingRight;
    [SerializeField] private Vector2 _offset = new Vector2(2f, 1f);
    
    private int _lastDurationX;
    private Transform _transformPlayer;

    private void Start()
    {
       _offset = new Vector2(Mathf.Abs(_offset.x), Mathf.Abs(_offset.y));
        
    }

    public void Isleft()
    {

    }
}
