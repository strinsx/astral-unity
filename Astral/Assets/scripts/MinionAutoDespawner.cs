using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionAutoDespawner : MonoBehaviour
{

    public float delay = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
