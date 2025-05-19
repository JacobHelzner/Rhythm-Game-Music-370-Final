using UnityEngine;

public class FrameStackBlur : MonoBehaviour
{
    public Shader blurShader;  // Assign the shader in the inspector
    private Material blurMaterial;
    public RenderTexture accumTexture; // Assign the Render Texture
    private Camera cam;

    [Range(0, 1)]
    public float blendOpacity = 0.9f; // Controls the blur intensity

    void Start()
    {
        cam = GetComponent<Camera>();

        // Ensure the material is created
        if (blurShader != null)
        {
            blurMaterial = new Material(blurShader);
        }

        // Create Render Texture dynamically if not assigned
        if (accumTexture == null)
        {
            accumTexture = new RenderTexture(Screen.width, Screen.height, 0);
            accumTexture.Create();
        }
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (blurMaterial == null)
        {
            Graphics.Blit(src, dest);
            return;
        }

        // Set shader properties
        blurMaterial.SetTexture("_AccumTex", accumTexture);
        blurMaterial.SetFloat("_Opacity", blendOpacity);

        // Apply accumulation effect
        Graphics.Blit(src, accumTexture, blurMaterial);
        Graphics.Blit(accumTexture, dest); // Output the blurred texture
    }
}
