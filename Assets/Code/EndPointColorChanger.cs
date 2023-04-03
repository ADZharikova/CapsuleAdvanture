using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointColorChanger : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _reachColor;

    public void Change()
    {
        _renderer.color = _reachColor;
    }
}
