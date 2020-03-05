using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrdering : MonoBehaviour
{
    [Range(-3f, 3f)]
    public float offset;

    // Update
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.y + offset);
    }
}
