using UnityEngine;
using UnityEngine.Video;

public class VideoLoader : MonoBehaviour
{
    [SerializeField] private string url;
    private VideoPlayer _titl;
    private void Start()
    {
        _titl = GetComponent<VideoPlayer>();
        _titl.url = System.IO.Path.Combine(Application.streamingAssetsPath, url);
    }
}
