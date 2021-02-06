using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public GameObject target;  //카메라가 쫓을 대상
    public float moveSpeed;  //카메라가 대상을 쫓는 속도
    private Vector3 targetPosition;

    void Start()
    {

    }

    void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
