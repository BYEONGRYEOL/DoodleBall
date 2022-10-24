using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player_Objective : MonoBehaviour
{

    [SerializeField] private string mytag_Player = "Player";

    private bool isComplete = false;
    public bool IsComplete { get { return isComplete; } }



    public void CompleteObjective()
    {
        isComplete = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Ãæµ¹!");
        if (collider.gameObject.CompareTag(mytag_Player))
        {
            CompleteObjective();

        }
    } 
}



