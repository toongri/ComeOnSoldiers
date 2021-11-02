using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWave : MonoBehaviour
{
    public int chapter = -1;

    private WavesInfo wavesInfo;

    public List<GameObject> waveInfoList;

    public GameObject wavePanel;

    public GameObject waveObject;

    public GameObject startPosition;

	void Start ()
    {
        wavesInfo = GameObject.FindGameObjectWithTag("WavesInfo").GetComponent<WavesInfo>();

        if(wavesInfo == null || GameManager.Instance.Stage == -1)
        {
            Debug.LogError("Wave 정보가 없습니다. WaveInfo를 만들어주세요. 또는 Chapter 변수가 현재 -1 입니다.");
            return;
        }

        foreach(var idx in wavesInfo.wave[GameManager.Instance.Stage].info) // chapter
        {
            var go = Instantiate(waveObject);
            var img = go.GetComponent<Image>();
            img.sprite = wavesInfo.warriorsSprites[idx];
            go.transform.SetParent(wavePanel.transform, false);         
            waveInfoList.Add(wavesInfo.warriors[idx]);
        }
	}

    public IEnumerator WaveStart(float _delay)
    { 
        foreach(var m in waveInfoList)
        {
            yield return new WaitForSeconds(_delay);

            var go = Instantiate(m, startPosition.transform.position, Quaternion.identity);
            GameManager.Instance._MonsterList.Add(go.GetComponent<Monster>());
        }
    }
}

