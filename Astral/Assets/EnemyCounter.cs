using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
public TMP_Text countText; 

public string enemyTag = "EnemySpawn";

  void Update()
  {
    GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

    countText.text = "No. Of Enemies: " + enemies.Length;
  }
}
