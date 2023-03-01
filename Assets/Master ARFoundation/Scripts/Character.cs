using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _distance;

    private Transform _player;

    private void Start() {
        _player = Camera.main.transform;// Para usar el tag de Camera Main, la cámara debe llevar ese mismo tag desde unity
        
        ChangePosition();

    }

    public void ChangePosition()
    {
        transform.position = new Vector3(
            Random.insideUnitSphere.x * _distance,
            transform.position.y,
            Random.insideUnitSphere.z * _distance);

        transform.LookAt(_player);
    }
}
