using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlerAnimator : MonoBehaviour
{
   [SerializeField] private PlayerBowler _playerBowler;
   
   public void ThrowBall()
   {
      _playerBowler.ThrowBall();
   }
}
