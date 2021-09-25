using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovingCube : MonoBehaviour
{
    public static MovingCube CurrentCube {get; private set;}
    public static MovingCube LastCube {get; private set;}
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    public int XorZ=1;


    private void OnEnable()
    {
        if(LastCube==null)
            LastCube=GameObject.Find("Start").GetComponent<MovingCube>();
        CurrentCube = this;    
        GetComponent<Renderer>().material.color = GetRandomColor();
        transform.localScale = new Vector3(LastCube.transform.localScale.x,transform.localScale.y,LastCube.transform.localScale.z);
    }
     private Color GetRandomColor()
     {
         return new Color(UnityEngine.Random.Range(0,1f),UnityEngine.Random.Range(0,1f),UnityEngine.Random.Range(0,1f));
     }
    //  private void SplitCubeOnX(float hangover, float direction)
    // {
    //     float newXSize = LastCube.transform.localScale.x - Mathf.Abs(hangover);
    //     float fallingBlockSize = transform.localScale.x - newXSize;
    //     float newXPosition = LastCube.transform.position.x + (hangover/2);
    //     transform.localScale = new Vector3(newXSize, transform.localScale.y, transform.localScale.z);
    //     transform.position = new Vector3(newXPosition,transform.position.y, transform.position.z);
    //     float cubeEdge = transform.position.x + (newXSize/2f * direction);
    //     float fallingBlockXPosition = cubeEdge + (fallingBlockSize/2f * direction);
    //     var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //     sphere.transform.localScale=  Vector3.one * 0.1f;
    //     sphere.transform.position= new Vector3(transform.position.x,transform.position.y,cubeEdge);

    //     SpawnDropCube(fallingBlockXPosition,fallingBlockSize);

    // }

    private void SplitCubeOnZ(float hangover, float direction)
    {
        float newZSize = LastCube.transform.localScale.z - Mathf.Abs(hangover);
        float fallingBlockSize = transform.localScale.z - newZSize;
        float newZPosition = LastCube.transform.position.z + (hangover/2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);
        float cubeEdge = transform.position.z + (newZSize/2f * direction);
        float fallingBlockZPosition = cubeEdge + (fallingBlockSize/2f * direction);
        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.localScale=  Vector3.one * 0.1f;
        sphere.transform.position= new Vector3(transform.position.x,transform.position.y,cubeEdge);

        SpawnDropCube(fallingBlockZPosition,fallingBlockSize);

    }
    internal void Stop()
    {
        moveSpeed=0;
        float hangover = transform.position.z - LastCube.transform.position.z;
        // if (XorZ == 1)
        //     hangover = transform.position.z - LastCube.transform.position.z;
        // else if(XorZ == 0)
        //     hangover = transform.position.x - LastCube.transform.position.x;
        if (Mathf.Abs(hangover) >= LastCube.transform.localScale.z){
            LastCube = null;
            CurrentCube = null;
            SceneManager.LoadScene(0);
        }
        float direction = hangover>0 ? 1f : -1f;
        // if (XorZ == 1)
            SplitCubeOnZ(hangover,direction);
        // else if (XorZ == 0)
        //     SplitCubeOnX(hangover,direction);

        LastCube = this;
    }

    // private float GetHangover()
    // {
    //     if (XorZ == 1)
    //         return transform.position.z - LastCube.transform.position.z;
    //     if (XorZ == 0)
    //         return transform.position.x - LastCube.transform.position.x;
    //     else 
    //         return 0;
    // }

    private void SpawnDropCube(float fallingBlockZPosition,float fallingBlockSize)
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //if (XorZ == 1)
        //{
            cube.transform.localScale= new Vector3(transform.localScale.x,transform.localScale.y,fallingBlockSize);
            cube.transform.position= new Vector3(transform.position.x,transform.position.y,fallingBlockZPosition);
        //}
        // else if (XorZ == 0)
        // {
        //     cube.transform.localScale= new Vector3(fallingBlockSize, transform.localScale.y,transform.localScale.z);
        //     cube.transform.position= new Vector3(fallingBlockZPosition, transform.position.y,transform.position.z);
        // }
        cube.AddComponent<Rigidbody>();
        cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
        Destroy(cube.gameObject,1f);
    }
    // private void SpawnDropXCube(float fallingBlockXPosition,float fallingBlockSize)
    // {
    //     var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //     cube.transform.localScale= new Vector3(fallingBlockSize, transform.localScale.y,transform.localScale.z);
    //     cube.transform.position= new Vector3(fallingBlockXPosition, transform.position.y,transform.position.z);
    //     cube.AddComponent<Rigidbody>();
    //     cube.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
    //     Destroy(cube.gameObject,1f);
    // }

    void Update()
    {
        if (XorZ == 1)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        else if(XorZ == 0)
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        
    }
}
