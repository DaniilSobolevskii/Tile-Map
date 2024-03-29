using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private List<Material> _materials = new();

    // Start is called before the first frame update
    void Awake()
    {
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var meshRenderer in renderers)
        {
            _materials.Add(meshRenderer.material);
        }
    }
    
    public void SetColor(bool available)
    {
        if (available)
        {
            foreach (var material in _materials)
            {
                material.color = Color.green;
            }
        }
        else
        {
            foreach (var material in _materials)
            {
                material.color = Color.red;
            }
        }
    }
    
    public void ResetColor()
    {
        foreach (var material in _materials)
        {
            material.color = Color.white;
        }
    }
    
}
