using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform shotPoint;
    public bool isRight;
    public SpriteRenderer render;

    public float timeBtwShots;
    public float startTimeBtwShots;
    
    public PlayerMovement pM;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if ((Input.GetKeyDown(KeyCode.Z) && timeBtwShots <= 0))
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots = Mathf.Max(0, timeBtwShots - Time.deltaTime);
        }

        if (!pM.facingRight){
            offset = 180;
            render.flipX = false;
        } else {
            offset = 0;
            render.flipX = true;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, (rotZ + offset));


    }


}
