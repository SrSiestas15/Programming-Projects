using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShipController : MonoBehaviour
{
    private PlayerMoveAndShoot playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GetComponentInParent<PlayerMoveAndShoot>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.isShooting && playerScript.canShoot)
        {
            StartCoroutine(MiniShoot());
        }
    }

    public IEnumerator MiniShoot()
    {
        Instantiate(playerScript.bulletPrefab, transform.position, transform.rotation); //shoots one bullet
        yield return new WaitForSeconds(PlayerMoveAndShoot.bulletFrequency); //wait just a bit to offset the bullets
    }
}
