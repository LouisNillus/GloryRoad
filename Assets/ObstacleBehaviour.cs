﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ObstacleBehaviour : MonoBehaviour
{
    [Range(0,1000), HideIf("isBoss", true)]
    public int hp;
    int initialhp;
    [Range(0, 1000), ShowIf("isBoss", true), ReadOnly]
    public int bossHp;

    [Range(0,10), HideIf("isPB", true)]
    public float speed;

    [HideIf("isPB", true)]
    public Direction direction;
    Rigidbody2D rb;

    [HideIf("isPB", true)]
    public Image hpBar;

    [HideIf("isPB", true)]
    public bool isBoss;

    [HideIf("isBoss", true)]
    public bool isPB;

    [ShowIf("isBoss", true), DrawScriptable]
    public MiniBoss miniBoss;
    [ShowIf("isBoss", true)]
    public SpriteRenderer zone;

    [ShowIf("isPB", true)]
    public int reward;

    bool canFinishHim = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {        
            if(isBoss == true)
            {
                bossHp -= collision.gameObject.GetComponent<ProjectileBehaviour>().dmg;
                if (bossHp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }
            else
            {
                hp -= collision.gameObject.GetComponent<ProjectileBehaviour>().dmg;
                if (hp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

        }
        else if(collision.gameObject.tag == "Player" && isPB == false)
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;
            StartCoroutine(collision.gameObject.GetComponent<PlayerController>().SetImmunity(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag + isPB);

        if(isPB == false && collision.tag == "Player" && (miniBoss.fatalRange/100f * initialhp) < bossHp)
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;
            StartCoroutine(collision.gameObject.GetComponent<PlayerController>().SetImmunity(1f));
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isPB == true && Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.money += reward;
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        if (this.tag == "MiniBoss")
        {
            initialhp = miniBoss.hp;
            bossHp = initialhp;
        }
        else
        {
            initialhp = hp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if(isPB == false)
        {
            rb = this.GetComponent<Rigidbody2D>();

            switch(direction)
            {

                case Direction.GoDown:
                    rb.velocity = new Vector2(0, -1) * speed;
                    break;
                case Direction.GoUp:
                    rb.velocity = new Vector2(0, 1) * speed;
                    break;
                case Direction.GoLeft:
                    rb.velocity = new Vector2(-1, 0) * speed;
                    break;
                case Direction.GoRight:
                    rb.velocity = new Vector2(1, 0) * speed;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(hpBar != null)
        {
            if(hpBar.fillAmount != 1f / initialhp * hp && this.tag == "Obstacle")
            {
                hpBar.fillAmount = 1f / initialhp * hp;
            }
            else if(this.tag == "MiniBoss" && hpBar.fillAmount != 1f / initialhp * bossHp)
            {
                hpBar.fillAmount = 1f / initialhp * bossHp;
            }
        }

        if (this.tag == "MiniBoss" && miniBoss.fatalRange / 100f * initialhp > bossHp && canFinishHim == false && zone.color != new Color32(0, 255, 0, 100))
        {
            zone.color = new Color32(0,255,0,100);
            canFinishHim = true;
        }

        if(canFinishHim && Input.GetKeyDown(KeyCode.Space))
        {
            Inventory.money += miniBoss.moneyReward;
            GameManager.instance.currentScore++;
            Destroy(this.gameObject);
        }
    }
}
public enum Direction{GoDown, GoUp, GoLeft, GoRight }
