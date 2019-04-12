using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMeshManager : MonoBehaviour
{
    private void Awake()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var renderer in renderers)
        {
            switch (renderer.name.ToLower())
            {
                case "body": _bodyMesh = renderer; break;
                case "head": _headMesh = renderer; break;
                case "face": _faceMesh = renderer; break;
                case "helmet": _helmetMesh = renderer; break;
                case "highlight": _highlightMesh = renderer; break;
            }
        }
    }

    public void ChangeJerseyColor(Color color)
    {
        SetColor(_bodyMesh, color);
        SetColor(_helmetMesh, color);
        ResetTexture(_bodyMesh);
        ResetTexture(_helmetMesh);
    }

    public void SetHighlightColor(Color color)
    {
        _highlightMesh.gameObject.SetActive(true);
        SetColor(_highlightMesh, color);
    }

    public void HideHighlight()
    {
        _highlightMesh.gameObject.SetActive(false);
    }

    private void SetColor(MeshRenderer mesh, Color color)
    {
        mesh.material.color = color;
    }
    private void SetTexture(MeshRenderer mesh, Texture texture)
    {
        mesh.material.mainTexture = texture;
    }
    private void ResetColor(MeshRenderer mesh)
    {
        mesh.material.color = Color.white;
    }
    private void ResetTexture(MeshRenderer mesh)
    {
        mesh.material.mainTexture = null;
    }


    private MeshRenderer _bodyMesh;
    private MeshRenderer _headMesh;
    private MeshRenderer _faceMesh;
    private MeshRenderer _helmetMesh;
    private MeshRenderer _highlightMesh;
}
