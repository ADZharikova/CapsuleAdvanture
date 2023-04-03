using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private Color _targetColorBlue;
    [SerializeField] private Color _targetColorGreen;
    [SerializeField] private Color _targetColorYellow;
    [SerializeField] private float _time;

    private SpriteRenderer _nowColor;
    private Color _startColor;
    private float _runningTime;
    private bool _isBlue;
    private bool _isGreen;
    private bool _isYellow;
    private bool _isStartColor = true;


    private void Start()
    {
        _nowColor = GetComponent<SpriteRenderer>();
        _startColor = _nowColor.color;
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        


        //������� �� ���������� � �����

        if ( _runningTime <= _time && _isStartColor)
        {
            var _partTime = _runningTime / _time;
            _nowColor.color = Color.Lerp(_startColor, _targetColorBlue, _partTime);
        }

        //��������� �������� � ������ �������������� � ������

        if (_runningTime > _time && _isStartColor)
        {
            _runningTime -= _time;
            _isBlue = true;
            _isStartColor = false;

            var _partTime = _runningTime / _time;
            _nowColor.color = Color.Lerp(_targetColorBlue, _targetColorGreen, _partTime);
        }

        //������� �� ������ � ������

        if (_runningTime <= _time && _isBlue)
        {
            var _partTime = _runningTime / _time;
            _nowColor.color = Color.Lerp(_targetColorBlue, _targetColorGreen, _partTime);
        }

        //��������� �������� � ������ �������������� � �����

        if (_runningTime > _time && _isBlue)
        {
            _runningTime = 0;
            _isGreen = true;
            _isBlue = false;

            var _partTime = _runningTime - _time / _time;
            _nowColor.color = Color.Lerp(_targetColorGreen, _targetColorYellow, _partTime);
        }

        //������� �� ������� � �����

        if (_runningTime <= _time && _isGreen)
        {
            var _partTime = _runningTime / _time;
            _nowColor.color = Color.Lerp(_targetColorGreen, _targetColorYellow, _partTime);
        }

        //��������� �������� � ������ �������������� � ����������� ����

        if (_runningTime > _time && _isGreen)
        {
            _runningTime = 0;
            _isGreen = false;
            _isYellow = true;

            var _partTime = _runningTime - _time / _time;
            _nowColor.color = Color.Lerp(_targetColorYellow, _startColor, _partTime);
        }

        //������� �� ������ � ����������� ����

        if (_runningTime <= _time && _isYellow)
        {
            var _partTime = _runningTime / _time;
            _nowColor.color = Color.Lerp(_targetColorYellow, _startColor, _partTime);
        }

        //��������� �������� � ������ �������������� � �����

        if (_runningTime > _time && _isYellow)
        {
            _runningTime = 0;
            _isStartColor = true;
            _isYellow = false;

            var _partTime = _runningTime - _time / _time;
            _nowColor.color = Color.Lerp(_startColor, _targetColorBlue, _partTime);
        }

    }
}
