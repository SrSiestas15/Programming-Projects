using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditBossScript : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootBullet(Vector3 position, Vector3 rotation)
    {
        GameObject bullet = Instantiate(bulletPrefab, position, transform.rotation); //spawn bullet

        //set direction
        MoveDirection bulletMoveScript = bullet.GetComponent<MoveDirection>();
        bulletMoveScript.runDirection = -rotation;
    }
}
