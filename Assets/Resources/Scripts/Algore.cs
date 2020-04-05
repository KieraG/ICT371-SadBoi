using UnityEngine;

public class Algore : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer vp;

    void Start()
    {
        vp = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
        vp.url = ".//Assets//Resources//test.mp4";

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