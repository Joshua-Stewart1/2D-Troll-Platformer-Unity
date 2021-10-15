using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingObj : MonoBehaviour
{
    public float dissolveTime;
    private SummonOnDeath sm;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(dissolveTime);
        if(TryGetComponent<SummonOnDeath>(out sm))
        {
            sm.Summon();
        }
        Destroy(gameObject);
    }

    public void SetDissolve(float dissolveTime)
    {
        this.dissolveTime = dissolveTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
