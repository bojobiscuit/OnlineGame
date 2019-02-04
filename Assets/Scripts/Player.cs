using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;

public class Player : Moveable
{
    public GameObject indicator;
    public GameObject body;

    private void Start()
    {
        if (tno.isMine)
        {
            var meshRenderer = body.GetComponent<MeshRenderer>();
            meshRenderer.material.color = Color.cyan;

            var camera = FindObjectOfType<TvCamera>();
            camera.target = transform;
        }
        else
        {
            indicator.SetActive(false);
        }
    }

    protected override void UpdateInput()
    {
        _input = Vector3.zero;
        _input.x = Input.GetAxis(inHorizontal);
        _input.z = Input.GetAxis(inVertical);
        _input = _input.normalized;
    }

    private static readonly string inHorizontal = "Horizontal";
    private static readonly string inVertical = "Vertical";
}
