using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleManager : MonoBehaviour
{
    public Mole[] moles; // シーンにいる全モグラを登録
    public float minDelay = 0.5f;
    public float maxDelay = 2f;

    void Start()
    {
        StartCoroutine(MoleSpawner());
    }

    IEnumerator MoleSpawner()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            int index = Random.Range(0, moles.Length);
            moles[index].PopUp();
        }
    }
}
