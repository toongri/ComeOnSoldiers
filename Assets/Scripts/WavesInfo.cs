using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesInfo : MonoBehaviour
{
    public List<GameObject> warriors = new List<GameObject>();
    public List<Sprite> warriorsSprites = new List<Sprite>();
    public List<Wave> wave = new List<Wave>();

    [System.Serializable]
    public class Wave
    {
        public List<int> info = new List<int>();
    }
}
