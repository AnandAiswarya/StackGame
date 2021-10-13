using System;
using System.Collections;
using System.Collections.Generic;
using JMRSDK.InputModule;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour,ISelectHandler, ISelectClickHandler
{
    private CubeSpawner[] spawners;
    private int spawnerIndex;
    private CubeSpawner currentSpawner;
    // public Text phaseDisplayText;
    private Touch theTouch;
    // private float timeTouchEnded;
    // private float displayTime = .5f;
    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
    }


    public static event Action OnCubeSpawned = delegate {};
    // Update is called once per frame
    private void Update()
<<<<<<< HEAD
    {
        if (OnSelectClicked())
=======
    {  if (Input.GetButtonDown("Fire1"))
>>>>>>> 22ecd211d08d3c2ed7853998c070e0154d5964f4
        {
        //     theTouch = Input.GetTouch(0);
        // //     phaseDisplayText.text = theTouch.phase.ToString();

	    // //     if (theTouch.phase == TouchPhase.Ended)
	    // //     {
		// //         timeTouchEnded = Time.time;
	    // //     }
        // // }   

        // // else if (Time.time - timeTouchEnded > displayTime)
        // // {
	    // //     phaseDisplayText.text = “”;
        // // }
            if(MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();

                spawnerIndex = spawnerIndex == 0 ? 1 : 0;
                currentSpawner = spawners[spawnerIndex];
                currentSpawner.SpawnCube();
                //FindObjectOfType<CubeSpawner>().SpawnCube();
                OnCubeSpawned();
            }
        }
        
    }

<<<<<<< HEAD
    private bool OnSelectClicked()
    {
        throw new NotImplementedException();
    }

    public void OnSelectDown(SelectEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnSelectUp(SelectEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnSelectClicked(SelectClickEventData eventData)
    {
        throw new NotImplementedException();
    }
}
=======
>>>>>>> 22ecd211d08d3c2ed7853998c070e0154d5964f4
