using UnityEngine;

public class ScreenVideo : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer vp;
    public string assetPath = "";

    void Start()
    {
        //Instantiate a video based on the asset path.
        vp = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        vp.url = System.IO.Path.Combine(Application.streamingAssetsPath, assetPath);

        vp.isLooping = true;
        vp.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        vp.targetMaterialRenderer = GetComponent<Renderer>();
        vp.targetMaterialProperty = "_MainTex";

        vp.Play();
        var track = this.GetComponent<AudioSource>();
        vp.SetTargetAudioSource(vp.audioTrackCount, track);
        //vp.SetDirectAudioMute(vp.audioTrackCount, true);
    }
}