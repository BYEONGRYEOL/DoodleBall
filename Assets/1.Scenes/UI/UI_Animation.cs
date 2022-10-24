using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

public class UI_Animation : SingletonMonoBehaviour<UI_Animation>
{
    [SerializeField] GameObject ball;
    private void Start()
    {
        Time.timeScale = 2;
        /*Debug.Log("Script :: UI_Animation / Function :: Start");
        Debug.Log("Script :: UI_Animation / Function :: BallInstantiate // TimeScale is" + Time.timeScale);*/


    }
    public void BallInstantiate()
    {
        /*Debug.Log("Script :: UI_Animation / Function :: BallInstantiate");
        Debug.Log("Script :: UI_Animation / Function :: BallInstantiate // TimeScale is"+ Time.timeScale);*/

        GameObject newball = Instantiate(ball);
        newball.transform.position = new Vector3(-11.6f, 15, 1);
    }
    
    
}
