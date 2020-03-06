using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class PlayerController : MonoBehaviour
{
    public int hp;
    public float speed;
    float angle;
    Vector3 aimingDir;

    public Weapon weaponSelected;

    public Text ammosLeft;

    [ReadOnly]
    public int ammos;

    bool canShoot = true;

    Rigidbody2D rb;
    BoxCollider2D bc;

    public SpriteRenderer weaponVisual;

    public GameObject gameOverScreen;
    public GameObject childVisual;
    public GameObject shootingStartPos;

    public static PlayerController instance;

    public Animator weaponShaker;

    // Start is called before the first frame update
    void Start()
    {
        bc = this.GetComponent<BoxCollider2D>();
        rb = this.GetComponent<Rigidbody2D>();
        if (weaponSelected.ammunitions % weaponSelected.howManyProjectiles != 0)
        {
            Debug.LogWarning("Some ammos will remain in : " + weaponSelected.name);
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            Debug.Log("Velocity To 0");
            rb.velocity = Vector2.zero;
        }

        if(hp <= 0)
        {
            gameOverScreen.SetActive(true);
        }
        
        if(weaponVisual.sprite != weaponSelected.topViewSprite)
        {
            weaponVisual.sprite = weaponSelected.topViewSprite;
        }

        Vector2 lookChara = this.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(lookChara.x, lookChara.y);
        angle = angle*Mathf.Rad2Deg;
        aimingDir = new Vector3(this.transform.localEulerAngles.x, this.transform.localEulerAngles.y, -angle);
        childVisual.transform.localEulerAngles = aimingDir;

        if (GameManager.instance.gameIsLaunched)
        {
            Moving();
            Shooting();
        }

        if(int.Parse(ammosLeft.text) != ammos)
        {
            ammosLeft.text = ammos.ToString();
        }
    }

    private void Moving()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            this.transform.Translate(new Vector2(0, 1f * Time.deltaTime * speed));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector2(0, -1f * Time.deltaTime * speed));

        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector2(1f * Time.deltaTime * speed, 0));
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Translate(new Vector2(-1f * Time.deltaTime * speed, 0));
        }

        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.D))
        {
            GameManager.instance.timeMoving += Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {        
        Gizmos.DrawLine(shootingStartPos.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    private void Shooting()
    {
        if(canShoot == true && ammos >= (0 + weaponSelected.howManyProjectiles))
        {
            switch(weaponSelected.typeOfWeapon)
            {
                case TypeOfWeapon.Auto:
                    if (Input.GetMouseButton(0))
                    {
                        weaponShaker.SetTrigger("AK");
                        CreateProjectile();
                    }
                    break;
                case TypeOfWeapon.Semi:
                    if (Input.GetMouseButtonDown(0))
                    {
                        switch(weaponSelected.name)
                        {
                            case "Famas":
                            weaponShaker.SetTrigger("Famas");
                                break;
                            case "SPAS 12":
                            weaponShaker.SetTrigger("Shotgun");
                                break;
                        }

                        if(weaponSelected.burst == true)
                        {
                            StartCoroutine(BurstWait(weaponSelected.burstInterval));
                        }
                        else
                        {
                            CreateProjectile();
                        }

                    }
                    break;
            }
        }          
    }
    public void CreateProjectile()
    {
        for (int i = 0; i < weaponSelected.howManyProjectiles; i++)
        {
            GameObject go = Instantiate(weaponSelected.projectile, this.transform.position, Quaternion.identity) as GameObject;
            go.GetComponent<ProjectileBehaviour>().dmg = weaponSelected.dmg;
            Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;

            if(weaponSelected.howManyProjectiles > 1)
            {
                dir = RotateVector(dir, (weaponSelected.angleBetweenProjectiles * i) - (weaponSelected.howManyProjectiles*weaponSelected.angleBetweenProjectiles)/2f); //Chargeurs pairs à revoir
            }

            go.transform.localEulerAngles = aimingDir;

            go.GetComponent<Rigidbody2D>().velocity = dir.normalized * weaponSelected.projectileSpeed;

            StartCoroutine(ProjectileLifetime(weaponSelected.bulletLifeTime, go));
        }

        StopCoroutine(Cooldown());
        StartCoroutine(Cooldown());
        ammos -= weaponSelected.howManyProjectiles;
    }

    public IEnumerator ProjectileLifetime(float lifeTime, GameObject _go)
    {
        yield return new WaitForSeconds(lifeTime);
        if(_go != null)
        {
            _go.GetComponent<BoxCollider2D>().enabled = false;
            _go.GetComponent<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(_go.GetComponent<ParticleSystem>().startLifetime);
            Destroy(_go);
        }
    }

    IEnumerator Cooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponSelected.timeBetweenShots);
        canShoot = true;
    }
    
    public IEnumerator SetImmunity(float delay)
    {
        bc.isTrigger = true;
        yield return new WaitForSeconds(delay);
        bc.isTrigger = false;
    }

    public Vector2 RotateVector(Vector2 v, float degrees)
    {
        return Quaternion.Euler(0, 0, degrees) * v;
    }

    IEnumerator BurstWait(float delay)
    {
        for (int i = 0; i < weaponSelected.burstQuantity; i++)
        {
            yield return new WaitForSeconds(delay);
            CreateProjectile();
        }
    }


}
