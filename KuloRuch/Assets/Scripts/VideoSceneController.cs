using UnityEngine;

public class VideoSceneController : MonoBehaviour
{
    [SerializeField]string NormalScene;
    [SerializeField]string VideoScene;
    NextLevelPortal[] nextLevelPortals;
    // Start is called before the first frame update
    void Start()
    {
        nextLevelPortals = FindObjectsOfType<NextLevelPortal>();
        Change(NormalScene);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsVideo(bool isTrue)
    {
        switch (isTrue)
        {
            case true:
                Change(VideoScene);
                break;
            case false:
                Change(NormalScene);
                break;
        }
    }
    void Change(string scene)
    {
        foreach (NextLevelPortal item in nextLevelPortals)
        {
            item.gameName = scene;
        }
    }
}
