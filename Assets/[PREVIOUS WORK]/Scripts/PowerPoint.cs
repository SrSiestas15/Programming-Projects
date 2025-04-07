using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPoint : MonoBehaviour
{

    private PlayerPowerBar powerupData;
    private Transform player;
    private Vector3 toPlayer;
    public float collectionRadius;

    private bool moveToPlayer;
    private float lerpTimer;
    public AnimationCurve lerpCurve;

    void Start()
    {
        powerupData = FindObjectOfType<PlayerPowerBar>();
        player = powerupData.gameObject.transform;
    }

    private void Update()
    {
        toPlayer = player.position - transform.position;

        if (toPlayer.magnitude <= collectionRadius)
        {
            moveToPlayer = true;
        }

        if (moveToPlayer)
        {
            lerpTimer += Time.deltaTime;
            float t = lerpCurve.Evaluate(lerpTimer);
            transform.position = Vector3.Lerp(transform.position, player.position, t);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        PlayerPowerBar.power = Mathf.Clamp(PlayerPowerBar.power + 1, 0f, PlayerPowerBar.powerPerBar * 3);
    }

}
