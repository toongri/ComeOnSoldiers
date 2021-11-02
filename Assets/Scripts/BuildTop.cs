using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTop : MonoBehaviour
{
    //탑 이미지가 바꼈으므로 재작성 하셔야 합니다. 참고하셔서 재작성 부탁드리겠습니다

    public GameObject top;
    
    private int topCount = 5;

    private void AdjustCameraBounds()
    {
        topCount = GameObject.Find("All_Game_View/01.Stage").transform.childCount;

        var bounds = GameObject.Find("CameraBound");

        bounds.transform.position = new Vector2(0, -8.95f + 1.79f * topCount);
        bounds.GetComponent<BoxCollider2D>().size = new Vector2(9, (topCount * 3.58f) + 2);
        Camera.main.GetComponent<CameraManager>().AdjustBounds();
    }

    public void CreateTop()
    {
        var newTop = GameObject.Instantiate(top, new Vector2(0, -7.16f + 3.58f * topCount), Quaternion.identity);
        newTop.transform.SetParent(GameObject.Find("All_Game_View/01.Stage").transform);
        AdjustCameraBounds();
    }
}
