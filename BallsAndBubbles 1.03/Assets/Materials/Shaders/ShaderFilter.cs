using UnityEngine;

public class ShaderFilter : MonoBehaviour
{
    [SerializeField] Shader _shader;
    private Material _material;

    private void Awake()
    {
        _material = new Material(_shader);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _material);
    }
}
