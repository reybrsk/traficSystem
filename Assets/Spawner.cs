using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    private IEnumerator _enumerator;
    public int secondWait;
    private float _t;
    public GameObject car1;
    public GameObject car2;

    
    // Update is called once per frame
    void Update()
    {
        _t += Time.deltaTime;
        if (_t > secondWait)
        {
            var kek = Instantiate(car2, Vector3.zero, Quaternion.identity);
            kek.GetComponent<Car>().serializeSpeed = Random.Range(5, 10);
            
            
            var kek1 = Instantiate(car1, Vector3.zero, Quaternion.identity);
            kek1.GetComponent<Car>().serializeSpeed = Random.Range(5, 10);
       
            _t = 0f;
            
        }
    }
    
    
}
