using UnityEngine;

public class GreyscaleShaderScript : MonoBehaviour {
    public Shader GreyscaleShader;
    public Shader FullColorShader;

    private Material material;

    protected void Awake() {
        material = new Material(GreyscaleShader);
    }

    protected void OnRenderImage(RenderTexture source, RenderTexture destination) {
        Graphics.Blit(source, destination, material);
    }

    public void SetToFullColor() {
        material = new Material(FullColorShader);
    }

}
