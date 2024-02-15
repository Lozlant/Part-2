using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionSetter : MonoBehaviour
{
    int width, height;
    public void setWidth(int w)
    {
        width = w;
    }
    public void setHeight(int h)
    {
        height = h;
    }
    public void setResolution()
    {
        Screen.SetResolution(width,height,false);
    }
}
