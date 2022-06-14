using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyscaleShaderScript : MonoBehaviour
{
    private Material material;
    public Shader GreyscaleShader;

    // Start is called before the first frame update
    void Start()
    {
        material = new Material(GreyscaleShader);
    }


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }


}
