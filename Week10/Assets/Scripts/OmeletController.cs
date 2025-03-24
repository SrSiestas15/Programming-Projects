using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmeletController : MonoBehaviour
{
    [SerializeField] Material normalMaterial;
    [SerializeField] Material burntMaterial;
    [SerializeField] public float timeToBurn;

    private MeshRenderer meshRenderer;

    public float burntAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(burntAmount < timeToBurn)
        {
            burntAmount += Time.deltaTime;
        }
        else
        {
            meshRenderer.material = burntMaterial;
        }
    }

    public void ResetOmelet()
    {
        burntAmount = 0;
        meshRenderer.material = normalMaterial;
    }
}
