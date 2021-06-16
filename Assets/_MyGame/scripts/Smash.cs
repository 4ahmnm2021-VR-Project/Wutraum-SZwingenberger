
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour
{
    private ObjectCollection objects;
    private GameObject smashOBJ;
    void Start()
    {
        objects = GameObject.Find("ObjectCollection").GetComponent<ObjectCollection>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        if(collision.relativeVelocity.magnitude > 4f) {
            foreach(GameObject prefap in objects.SmahedObjects) {
                if(prefap.name == this.gameObject.name + "Destruct") {
                    smashOBJ = prefap;
                }
            }
            var spawn =  Instantiate(smashOBJ, transform.position, Quaternion.identity);
            spawn.transform.position = this.gameObject.transform.position;
            spawn.transform.rotation = this.gameObject.transform.rotation;

            
            foreach(Transform split in spawn.transform) {
                var directionX = Random.Range(-8f, 8f);
                var directionY = Random.Range(-4f, 4f);
                Debug.Log("add velocity");
                // split.GetComponent<Rigidbody>().AddForce(spawn.transform.up * -1 * 2000f);
                split.GetComponent<Rigidbody>().AddForce(new Vector3(directionX, directionY) * 50f);
            }
            
            Destroy(this.gameObject);

        }

    }

    void Update() {

    }
}
