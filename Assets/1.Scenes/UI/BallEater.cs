using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LevelManagement;

public class BallEater : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        UI_Animation.Instance.BallInstantiate();
    }
    
}
