using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TrapScale : MonoBehaviour
{
    public enum Type
    {
        Top,
        Mid,
        Bot
    }

    public Type type;

    //함정 가로, 세로 사이즈
    public int width;
    public int height;
}
