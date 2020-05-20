using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

  void Update() {
    transform.position += new Vector3(0f, PLayerController.BulletSpeed) *
    Time.deltaTime;
    Destroy(gameObject, 1f);
  }

  void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.tag == "Rocks"){
      Destroy(gameObject);
    }
  }
}
