using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [Range(0,50)]
    public int destructionParticlesCount;

    [HideInInspector]
    public int dmg;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "MiniBoss")
        {
            StartCoroutine(ProgrammedDeath(this.gameObject));
        }
    }

    public IEnumerator ProgrammedDeath(GameObject _gameObject)
    {
        _gameObject.GetComponent<ParticleSystem>().Emit(destructionParticlesCount);
        _gameObject.GetComponent<SpriteRenderer>().enabled = false;
        _gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(_gameObject.GetComponent<ParticleSystem>().startLifetime);
        Destroy(_gameObject);
    }

    IEnumerator TimeBeforeDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
