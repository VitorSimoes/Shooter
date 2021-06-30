using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -6){
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Laser"){
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
