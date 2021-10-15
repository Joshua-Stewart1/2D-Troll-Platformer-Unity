using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public int totalHP = 100;
    private int currentHP = 100;
    private GameObject hpBar;

    public float attackDelayShort = 0.5f;
    public float attackDelayLong = 0.5f;
    public float spikeSpeed = 8f;

    public int bulletDamage;
    public GameObject reward;
    public GameObject trap;

    private GameObject[] spikes;
    private int spikeLoc;
    private GameObject spike;
    private TriggerMovement trigger;
    private OneWayKill spikeCode;
    private bool midFall = true;

    private int lastSummon;
    private int curSummon;

    // Start is called before the first frame update
    void Start()
    {
        hpBar = GameObject.Find("BarHealth");
        spikes = GameObject.FindGameObjectsWithTag("SpikePlat");
        StartCoroutine(BossBattle());
    }

    IEnumerator BossBattle()
    {
        yield return new WaitForSeconds(2);

        while (currentHP > 0)
        {
            for (int i = 0; i < 3 && currentHP > 0; i++)
            {
                SummonTrap();
                yield return new WaitForSeconds(attackDelayShort);
            }
            if(currentHP > 0)
                yield return new WaitForSeconds(attackDelayShort);

            for (int i = 0; i < 3 && currentHP > 0; i++)
            {
                DropSpike();
                yield return new WaitForSeconds(attackDelayShort);
            }
            if (currentHP > 0)
                yield return new WaitForSeconds(attackDelayLong);
        }

        Instantiate(reward, new Vector3(1f,-1f,0f), transform.rotation);
        Destroy(gameObject);
    }

    void DropSpike()
    {
        while(midFall)
        {
            spikeLoc = Random.Range(0, spikes.Length);
            spike = spikes[spikeLoc];
            trigger = spike.GetComponent<TriggerMovement>();
            spikeCode = spike.GetComponent<OneWayKill>();
            midFall = spikeCode.IsFalling();
        }

        trigger.Activate(spikeSpeed, true, spike.transform.position.x, -2.5f);
        spikeCode.SetFalling(true);
        midFall = true;
    }

    void SummonTrap()
    {
        while(Mathf.Abs(curSummon - lastSummon) < 3)
        {
            curSummon = Random.Range(0, 14);
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(trap, new Vector3(-6.5f + i + curSummon, -2.5f, 0f), transform.rotation);
        }
        lastSummon = curSummon;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Projectile")
        {
            currentHP -= bulletDamage;
            if (currentHP < 0)
            {
                currentHP = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.transform.localScale = new Vector3(13.5f * currentHP / totalHP, 
            hpBar.transform.localScale.y, hpBar.transform.localScale.z);

        hpBar.transform.localPosition = new Vector3((hpBar.transform.localScale.x - 13.5f)/2,
            hpBar.transform.localPosition.y, hpBar.transform.localPosition.z);

        if(currentHP <= totalHP / 2)
        {
            if(currentHP <= totalHP / 4)
            {
                hpBar.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                hpBar.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
