using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] public GameObject shipPrefab;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnShip()
    {
        animator.SetBool("Invincible", true);
        yield
        return new WaitForSeconds(.75f);
        
        GameObject newShip = Instantiate(shipPrefab, transform);
        Vector3 spawnPos = new Vector3(-7, 0, 10);
        newShip.transform.localPosition = spawnPos;
        newShip.GetComponent<PlayerMoveAndShoot>().enabled = false;
        newShip.GetComponent<Collider2D>().enabled = false;
        yield return null;
        newShip.GetComponent<PlayerDamage>().enabled = false;
        while (newShip.transform.localPosition.x < -4.5)
        {
            spawnPos.x += Time.deltaTime * 4;
            yield return null;
            newShip.transform.localPosition = spawnPos;
        }
        yield
        return
        newShip.GetComponent<Collider2D>().enabled = true;
        newShip.GetComponent<PlayerMoveAndShoot>().enabled = true;
        yield
        return new WaitForSeconds(1);
        animator.SetBool("Invincible", false);
        newShip.GetComponent<PlayerDamage>().enabled = true;
    }

}
