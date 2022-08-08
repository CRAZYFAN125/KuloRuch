using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [Min(.1f)] public float time = 3f;
    [SerializeField] private Text show;
    [SerializeField] private bool DestroyTextAfterCountdown = true;
    private string Text = string.Empty;


    ICounterEnd[] counterEnds;
    private void Start()
    {
        counterEnds = gameObject.GetComponents<ICounterEnd>();
        if (show != null)
        {
            Text = show.text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (counterEnds.Length != 0 && time <= 0)
        {
            foreach (ICounterEnd item in counterEnds)
            {
                item.OnEnd();
                Destroy(item.GetGameObject());
            }
            if (DestroyTextAfterCountdown)
            {
                Destroy(show);
                DestroyTextAfterCountdown = false;
                return;
            }
            Destroy(this);
        }
        time -= Time.deltaTime;
        show.text = Text + time.ToString("00.00");
    }
}


public interface ICounterEnd
{
    public void OnEnd();
    public GameObject GetGameObject();
}
