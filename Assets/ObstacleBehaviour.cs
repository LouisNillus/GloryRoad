using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObstacleBehaviour : MonoBehaviour
{
    [Range(0,100)]
    public int hp;
    int initialhp;

    [Range(0,10)]
    public float speed;

    public Direction direction;
    Rigidbody2D rb;

    public Image hpBar;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            hp -= collision.gameObject.GetComponent<ProjectileBehaviour>().dmg;
            if(hp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().hp--;
            StartCoroutine(collision.gameObject.GetComponent<PlayerController>().SetImmunity(1f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        initialhp = hp;
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
        if(hpBar.fillAmount != 1f / initialhp * hp)
        {
            hpBar.fillAmount = 1f / initialhp * hp;
        }
    }
}
public enum Direction{GoDown, GoUp, GoLeft, GoRight }
