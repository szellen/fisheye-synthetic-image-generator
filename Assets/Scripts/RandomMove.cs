using System.Collections;
using UnityEngine;



public class RandomMove : MonoBehaviour
{
    Screenshot camera = new Screenshot();
    private float movementDuration = 1.0f;
    private float waitBeforeMoving = 1.0f;
    private bool hasArrived = false;
    private void Update()
    {
        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(279f, 280.2f);
            float randZ = Random.Range(220.85f, 223.85f);
            float randY = Random.Range(-1f, 1.5f);
            StartCoroutine(MoveToPoint(new Vector3(randX, randY, randZ)));
        }
    }

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;
        while (timer < movementDuration)
        {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
        }
        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }
}
