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
        bodyMesh = body.GetComponent<MeshRenderer>();

        if (tno.isMine)
        {
            var camera = FindObjectOfType<TvCamera>();
            camera.target = transform;

            var tester = FindObjectOfType<Tester>();
            tester.player = this;
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

    public void RandomizeColor()
    {
        if (tno.isMine)
        {
            var color = new Color(Random.value, Random.value, Random.value);
            tno.Send("OnColorChange", Target.AllSaved, color);
        }
    }

    [RFC]
    protected void OnColorChange(Color color)
    {
        bodyMesh.material.color = color;
    }

    private MeshRenderer bodyMesh;
    private static readonly string inHorizontal = "Horizontal";
    private static readonly string inVertical = "Vertical";
}
