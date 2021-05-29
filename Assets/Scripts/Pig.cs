﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour {

    public float maxSpeed = 10;
    public float minSpeed = 5;

    private SpriteRenderer render;
    public Sprite hurt;

    public GameObject boom;
    public GameObject score;

    public bool isPig = false;
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)//直接死亡
        {
            Dead();
        }
        else if (collision.relativeVelocity.magnitude > minSpeed && collision.relativeVelocity.magnitude < maxSpeed)
        {
            render.sprite = hurt;
        }
    }

    public void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pig.Remove(this);
        }
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
}