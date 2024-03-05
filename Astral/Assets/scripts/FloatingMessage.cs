/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingMessage : MonoBehaviour, InGameMessage
{
   private Rigidbody2D _rigidbody;
   private TMP_Text _damageValue;

   public float InitialYVelocity = 7f;
   public float InitialXVelocity = 3f;
   public float LifeTime = 0.0f;

   private void Awake(){

    _rigidbody = GetComponent<Rigidbody2D>();
    _damageValue = GetComponentInChildren<TMP_Text>();
   }

    private void Start (){
        _rigidbody.velocity = 
                new Vector2(Random.Range(-InitialXVelocity, InitialXVelocity), InitialYVelocity);
                Destroy(gameObject, LifeTime);
    }

public void SetMessage(string msg)
{
  _damageValue.SetText(msg);
}  

}


*/