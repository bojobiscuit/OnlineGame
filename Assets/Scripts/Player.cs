using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TNet;

public class Player : Moveable
{
    protected override void Awake()
    {
        base.Awake();
        _rotater = GetComponent<Rotater>();
        _meshManager = GetComponent<PersonMeshManager>();
    }

    private void Start()
    {
        if (tno.isMine)
        {
            var camera = FindObjectOfType<TvCamera>();
            camera.target = transform;

            var tester = FindObjectOfType<Tester>();
            tester.player = this;

            _meshManager.SetHighlightColor(Color.red);
        }
        else
        {
            _meshManager.HideHighlight();
        }
    }

    protected override void UpdateInput()
    {
        _input = Vector3.zero;
        _input.x = Input.GetAxis(inHorizontal);
        _input.z = Input.GetAxis(inVertical);

        if(_input.sqrMagnitude > 0)
        {
            _input = _input.normalized;
            _rotater.UpdateRotationByDirection(_input);
        }
    }

    public void ChangeJerseyColorRandom()
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
        _meshManager.ChangeJerseyColor(color);
    }

    private Rotater _rotater;
    private PersonMeshManager _meshManager;

    private static readonly string inHorizontal = "Horizontal";
    private static readonly string inVertical = "Vertical";
}
