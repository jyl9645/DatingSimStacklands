using UnityEngine;

public class ProgressBarScript : MonoBehaviour
{

    float timer = 0f;

    GameObject fillBlock;

    void Start()
    {
        fillBlock = transform.GetChild(0).gameObject;
    }

    void Update()
    {

        if (transform.parent.childCount == 1)
        {
            transform.parent.GetComponent<Card>().merging = false;
            Destroy(gameObject);
        }

        if (timer < 1)
        {
            timer += Time.deltaTime;
            fillBlock.transform.localScale = new Vector3(timer,1,1);
        }
        else
        {
            transform.parent.GetComponent<Card>().FinishMerge();
            Destroy(gameObject);
        }
    }
}
