using UnityEngine;

public class CombinableScript : MonoBehaviour
{

    private float timer = 2;
    private GameObject result;

    public GameObject orange;
    public GameObject purple;
    public GameObject green;

    public enum Colors
    {
        red,
        blue,
        yellow
    }

    public Colors card_color;

    void Update()
    {

        if (transform.childCount != 0)
        {
            Colors childcolor = transform.GetChild(0).GetComponent<CombinableScript>().card_color;

            switch (card_color)
            {
                case Colors.red:
                    if (childcolor == Colors.blue)
                    {
                        result = purple;
                    }
                    else if (childcolor == Colors.yellow)
                    {
                        result = orange;
                    }
                    break;

                case Colors.blue:
                    if (childcolor == Colors.red)
                    {
                        result = purple;
                    }
                    else if (childcolor == Colors.yellow)
                    {
                        result = green;
                    }
                    break;

                case Colors.yellow:
                    if (childcolor == Colors.blue)
                    {
                        result = green;
                    }
                    else if (childcolor == Colors.red)
                    {
                        result = orange;
                    }
                    break;    
            }

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                Instantiate(result);
                Destroy(gameObject);
            }  

        }

        else
        {
            timer = 2;
        }

    }
    
}
