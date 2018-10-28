using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour {

    public Material material;
    public RenderTexture renderTexture;

    private void Start()
    {
        material.mainTexture = renderTexture;
    }
}
