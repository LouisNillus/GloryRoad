using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class ObstacleBehaviour : MonoBehaviour
{
    [Range(0,1000), HideIf("isBoss", true)]
    public int hp;
    int initialhp;
    [Range(0, 1000), ShowIf("isBoss", true)]
    public int bossHp;

    [Range(0,10)]
    public float speed;

    public Direction direction;
    Rigidbody2D rb;

    public Image hpBar;

    public bool isBoss;

    [ShowIf("isBoss", true)]
    public MiniBoss miniBoss;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            if(this.tag == "Obstacle")
            {
                hp -= collision.gameObject.GetComponent<ProjectileBehaviour>().dmg;
                if(hp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

            if(this.tag == "MiniBoss")
            {
                bossHp -= collision.gameObject.GetComponent<ProjectileBehaviour>().dmg;
                if (miniBoss.hp <= 0)
                {
                    Destroy(this.gameObject);
                }
            }

        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;
            StartCoroutine(collision.gameObject.GetComponent<PlayerController>().SetImmunity(1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && (miniBoss.fatalRange/100f * miniBoss.hp) > initialhp)
        {
            Debug.Log("Boss is not enough damaged");
            collision.gameObject.GetComponent<PlayerController>().hp--;
            StartCoroutine(collision.gameObject.GetComponent<PlayerController>().SetImmunity(1f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialhp = hp;

        if(this.tag == "MiniBoss")
        {
            initialhp = miniBoss.hp;
        }

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

    // Update is called once per frame
    void Update()
    {
        if(hpBar.fillAmount != 1f / initialhp * hp && this.tag == "Obstacle")
        {
            hpBar.fillAmount = 1f / initialhp * hp;
        }
        else if(this.tag == "MiniBoss" && hpBar.fillAmount != 1f / initialhp * miniBoss.hp)
        {
            hpBar.fillAmount = 1f / initialhp * miniBoss.hp;
        }
    }
}
public enum Direction{GoDown, GoUp, GoLeft, GoRight }
