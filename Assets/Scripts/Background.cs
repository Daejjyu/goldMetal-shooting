using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }

    void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    void Scrolling()
    {
        if (sprites[endIndex].position.y < -1 * viewHeight)
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[endIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * viewHeight;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = startIndexSave == 0 ? sprites.Length - 1 : startIndexSave - 1;
        }

    }

    void Update()
    {
        Move();
        Scrolling();
    }
}
