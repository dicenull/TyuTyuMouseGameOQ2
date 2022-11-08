using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public int Point;

    [SerializeField] Vector3 direction;

    Vector3 initPos;
    bool start = false;
    float diff = 10f;

    public void Stop()
    {
        StopAllCoroutines();

        start = false;
        transform.position = initPos;
    }
    
    public void Start()
    {
        initPos = transform.position;
    }

    private void Update()
    {
        if(Random.Range(0, 1000) == 0)
        {
            if(!start)
            {
                start = true;
                StartCoroutine(spawnSeq());
            }

        }
        
    }

    IEnumerator spawnSeq()
    {
        yield return move(isPush: true);

        yield return new WaitForSeconds(3f);

        yield return move(isPush: false);

        start = false;

        yield break;
    }

    /// <summary>
    /// ネズミの移動
    /// </summary>
    /// <param name="isPush">前(direction方向)に進むかどうか</param>
    IEnumerator move(bool isPush = true)
    {
        var count = 0f;

        var sin = 0f;
        while (Mathf.Abs(sin) < 0.99f)
        {
            sin = Mathf.Sin(count);

            if(isPush)
            {
                transform.position
                = initPos + sin * direction / diff;
            }
            else
            {
                transform.position
                = initPos + (1 - sin) * direction / diff;
            }

            count += 0.01f;

            yield return null;
        }

        transform.position = initPos + (isPush ? 1 : 0) * direction / diff;
    }
}

