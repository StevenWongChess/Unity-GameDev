using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 originalPos, targetPos;
    private float timeToMove = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.up));
        if (Input.GetKey(KeyCode.LeftArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.left));
        if (Input.GetKey(KeyCode.RightArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.right));
        if (Input.GetKey(KeyCode.DownArrow) && !isMoving)
            StartCoroutine(MovePlayer(Vector3.down));
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        originalPos = transform.position;
        targetPos = originalPos + direction;

        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }
}
