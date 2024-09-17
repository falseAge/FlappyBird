using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Rigidbody2D _rigidBody;
    
    private quaternion _maxRotation;
    private quaternion _minRotation;

    private void Start()
    {
        transform.position = _startPosition;

        _rigidBody = GetComponent<Rigidbody2D>();
        _rigidBody.velocity = Vector2.zero;

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;
            _rigidBody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
