using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;
using System;
namespace LineGame
{
    public class Player : SingletonMonoBehaviour<Player>
{
        [SerializeField] private float myUpSpeed = 1f;
        public Rigidbody2D rigid;
        protected override void Awake()
        {
            base.Awake();
        }
        public void UpTrigger()
        {
            rigid.AddForce(Vector2.up * myUpSpeed, ForceMode2D.Impulse);
            
        }
        public bool IsGoingRight()
        {
            if(rigid.velocity.x >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFastAlready()
        {
            if(Math.Abs(rigid.velocity.magnitude) > 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }

}