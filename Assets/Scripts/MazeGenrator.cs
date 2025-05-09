using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenrator : MonoBehaviour
{
    public GameObject Floor;
    public GameObject HedgePrefab;
    public int width = 10;
    public int height = 10;
    private void Start()
    {
        GenrateMaze();
    }
    void GenrateMaze()
    {
        for(int x=0;x<width;x++)
        {
            for (int y=0;y<height;y++)
            {
                Instantiate(Floor,new Vector3(x,0,y),Quaternion.identity,transform);
                if(x==0||y==0|| x==width-1||y==height-1)
                {
                    Instantiate(HedgePrefab, new Vector3(x, 0.5f, y ), Quaternion.identity, transform);
                }
            }
            
        }
    }
}
