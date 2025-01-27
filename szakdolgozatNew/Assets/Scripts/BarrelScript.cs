﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject particles;
    public GameObject[] Coins;
    public GameObject pebble;
    private static System.Random rng;
    void Start()
    {
        rng = new System.Random();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "sword") death();
    }
    public void death(){         
        Instantiate(particles,transform.position,Quaternion.identity);
        for (int i = 0; i <= 1 + PlayerPrefs.GetInt("moreLoot"); i++)
        {   
            if(rng.Next(0,8) ==1 && PlayerPrefs.GetInt("canThrow") == 1)
            {
                GameObject Currentpebble = Instantiate(pebble,new Vector3(transform.position.x,transform.position.y+1,0), Quaternion.identity);
                Currentpebble.GetComponent<Rigidbody2D>().velocity = new Vector2(rng.Next(2, 4),rng.Next(3, 6));
            }
            int rnd = rng.Next(0,2);
            GameObject coin = Instantiate(Coins[rnd],new Vector3(transform.position.x,transform.position.y+1,0), Quaternion.identity);
            coin.GetComponent<Rigidbody2D>().velocity = new Vector2(rng.Next(2, 4),rng.Next(3, 6));
        }    
        Destroy(this.gameObject); 
    }
}
