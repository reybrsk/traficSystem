using System;
using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using Dreamteck.Splines.Primitives;
using UnityEngine;
using Random = UnityEngine.Random;


public class Car : MonoBehaviour
{
  [SerializeField]public float serializeSpeed = 5f;
  private float _targetSpeed;
  private float _t = 0f;
  private SplineFollower _splineFollower;

  public bool canMove;

  public Car isPlayWithThisCar;

  private void Start()
  {
    canMove = true;
    _splineFollower = GetComponent<SplineFollower>();
    _targetSpeed = serializeSpeed;
    _splineFollower.followSpeed = _targetSpeed;
  }


  private void Update()
  {
    _splineFollower.followSpeed = _targetSpeed;

    if (!canMove)
    {
      Stop();
    }
    else
    {
      Move();
    }
  }

  private void Move()
  {
    if (_t < 1f)
    {
      Debug.Log("SpeedUp" + gameObject.name);
      _targetSpeed = Mathf.Lerp(0f, serializeSpeed, _t);
      _t += Time.deltaTime;
      _t += Time.deltaTime;
    }
    else _t = 1f;

  }

  private void Stop()
  {
    if (_t >= 0f)
    {
      Debug.Log("SpeedDown" + gameObject.name);
      _targetSpeed = Mathf.Lerp(0f, serializeSpeed, _t);
      _t -= Time.deltaTime;
      _t -= Time.deltaTime;
    }
    else _t = 0f;

  }


  public void YouLose(Car targetCar)
  {
    Debug.Log("YOULOSE in " + gameObject.name);
    canMove = false;
    isPlayWithThisCar = targetCar;
  }

  public void YouCanMove()
  {
    Debug.Log("YoyCanMove in " + gameObject.name);
    canMove = true;
    isPlayWithThisCar = null;
  }

  public int CuEFa()
  {
    return Random.Range(0, 2);
  }

  public void Kill()
  {
    Destroy(gameObject);
  }
  
}
