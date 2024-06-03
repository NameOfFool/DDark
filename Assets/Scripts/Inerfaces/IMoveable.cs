using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public interface IMoveable
{
    Rigidbody2D RB {get;set;}
    bool isFacingRight {get;set;}
    void Move(Vector2 velocity);
    void CheckFacingSide(Vector2 velocity);
}