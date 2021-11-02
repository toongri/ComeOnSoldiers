using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour {

    private Vector2 prevPos;
    private Vector2 nowPos;
    private Vector3 movePos;
    private Vector2 minBound;
    private Vector2 maxBound;

    private float moveSpeed = 9f;
    private float orthographicSpeed = 1f;
    private float timer;
    private float halfWidth;
    private float halfHeight;

    public BoxCollider2D box2d;

    public float minOrthographicSize;
    public float maxOrthographicSize;

    private Camera cam;

    private bool canTouch = true;

#if UNITY_EDITOR
    //에디터용 변수
    Vector3 mouse_pos;
    Vector3 offset;
#endif

    private void Start()
    {
        cam = GetComponent<Camera>();

        AdjustBounds();
    }

    public void AdjustBounds()
    {
        minBound = box2d.bounds.min;
        maxBound = box2d.bounds.max;

        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            offset = this.transform.position - mouse_pos;
        }

        if (Input.GetMouseButton(0))
        {
            mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var pos = mouse_pos + offset;
            this.transform.position = new Vector3(pos.x, pos.y, -10);
        }

        //cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * orthographicSpeed;
        //cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minOrthographicSize, maxOrthographicSize);
#elif UNITY_ANDROID
        if (!canTouch) {
            timer += Time.deltaTime;
            if(timer >= 0.2f) {
                canTouch = true;
            }
        }

        if (canTouch) {
            if (Input.touchCount == 1) {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began) {
                    prevPos = touch.position;
                } else if (touch.phase == TouchPhase.Moved) {
                    nowPos = touch.position - touch.deltaPosition;
                    movePos = (Vector3)(prevPos - nowPos) * moveSpeed * Time.deltaTime * 0.01f;

                    transform.Translate(new Vector2(movePos.x, movePos.y));
                    prevPos = touch.position - touch.deltaPosition;
                } else if (touch.phase == TouchPhase.Ended) {
                    timer = 0;
                    canTouch = false;
                }
            } else if (Input.touchCount == 2) {
                //Touch touchZero = Input.GetTouch(0);
                //Touch touchOne = Input.GetTouch(1);

                //Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                //Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                //float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                //float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

                //float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

                //cam.orthographicSize += deltaMagnitudeDiff * orthographicSpeed * 0.01f;

                //cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minOrthographicSize, maxOrthographicSize);

                //if (touchZero.phase == TouchPhase.Ended || touchOne.phase == TouchPhase.Ended) {
                //    timer = 0;
                //    canTouch = false;
                //}
            }
        }
#endif

        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;

        float clampX = Mathf.Clamp(transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
        float clampY = Mathf.Clamp(transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);

        this.transform.position = new Vector3(clampX, clampY, this.transform.position.z);
    }
}
