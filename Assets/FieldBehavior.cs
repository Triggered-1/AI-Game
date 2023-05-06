using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldBehavior : MonoBehaviour
{
    [SerializeField] private Sprite fullField;
    [SerializeField] private Sprite emptyField;
    private SpriteRenderer renderer;
    private BaseResource baseResource;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        baseResource = GetComponent<BaseResource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (baseResource.HasResources())
        {
            renderer.sprite = fullField;
        }
        if (!baseResource.HasResources())
        {
            renderer.sprite = emptyField;
        }

    }
}
