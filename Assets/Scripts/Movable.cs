﻿using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] private bool controlled = true;
    float xMin;
    float xMax;
    float yMin;
    float yMax;

    private Animator _animator;

    // Use this for initialization
    void Start ()
    {
        _animator = GetComponent<Animator>();
        SetUpMoveBoundaries();
    }
    
    public void LostControll()
    {
        controlled = false;
    }

    public void GetControll()
    {
        controlled = true;
    }
    
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
    
    void Update () {
        Move();
    }
	
    private void Move()
    {
        if (!controlled) return;
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        if (deltaX != 0f || deltaY != 0f)
        {
            _animator.SetBool("isWalking", true);
            var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
            var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
            transform.position = new Vector2(newXPos, newYPos);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }
}