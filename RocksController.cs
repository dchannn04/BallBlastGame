using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RocksController : MonoBehaviour {

  int RockScore;
  int RndColor;

  Text RockValue;

  public GameObject BlowingEff;
  private GameObject BlowingEffParent;

  void Start () {

    BlowingEffParent = GameObject.Find("Canvas");

    RockScore = Random.Range(5,10);
    RndColor = Random.Range(0,2);

    if(RndColor == 0){
      GetComponent<Image>().color = new Color (255f,0f,0f,255f);
    }
    if(RndColor == 1){
      GetComponent<Image>().color = new Color (0f,255f,0f,255f);
    }
    if(RndColor == 2){
      GetComponent<Image>().color = new Color (0f,0f,255f,255f);
    }

    RockValue = GetComponentInChildren<Text>();
  }

  void Update () {
    if(RockScore <= 0){
      GameObject blowingEff = Instantiate(BlowingEff, transform.position,
      transform.rotation);
      blowingEff.transform.SetParent(BlowingEffParent.transform, true);
      Destroy(blowingEff.gameObject, 0.25f);
      Destroy(gameObject);
    }

    RockValue.text = RockScore.ToString();
    transform.Rotate (0,0,1f);
  }

  void OnTriggerEnter2D(Collider2D col){
    if(col.gameObject.tag == "Bullet"){
      RockScore -= 3;
      GameManager.GameScore += 3;
    }
  }
}
