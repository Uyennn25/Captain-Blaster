using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
   public GameManager gameManager;
   public GameObject bulletPrefab;
   public float speed = 10f;
   public float xLimit = 7f;
   public float reloatTime = 0.5f;
   private float elapsedTime = 0f;
   private float boundRight = 2.79f;
   private float boundLeft = -2.79f;
      
   private void Update()
   {
      elapsedTime += Time.deltaTime;
      float xInput = Input.GetAxis("Horizontal");
      transform.Translate(xInput*speed*Time.deltaTime, 0f, 0f);
      Vector3 position = transform.position;
      position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
      transform.position = position;

      if (Input.GetButtonDown("Jump") && elapsedTime > reloatTime)
      {
         Vector3 spawnPos = transform.position;
         spawnPos += new Vector3(0, 1.2f, 0);
         Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
         elapsedTime = 0f;
      }
      if (transform.position.x >= boundRight)
      {
         transform.position = new Vector3(boundRight, transform.position.y, transform.position.z);
      }
        
      if (transform.position.x <= boundLeft)
      {
         transform.position = new Vector3(boundLeft, transform.position.y, transform.position.z);
      }
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
      gameManager.playerDied();
     
   }
}
