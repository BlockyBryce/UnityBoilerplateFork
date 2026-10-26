using UnityEngine;

public class TabletController : MonoBehaviour
{
    public float closeSpeed = 10f;
    public CanvasGroup tablet;
    //public GameObject tabletObject;
    //Vector2 tabletUpPoint;
    //Vector2 tabletDownPoint;

    public bool tabletUp = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tablet.alpha = 0f;
        tablet.interactable = false;
        tablet.blocksRaycasts = false;
        //tabletUpPoint = new Vector2 (0f, 0f);
        //tabletDownPoint = new Vector2(100f, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float step = closeSpeed * Time.deltaTime;
            if (tabletUp)
            {
                //tabletObject.transform.position = Vector2.MoveTowards(tabletObject.transform.position, tabletDownPoint, step);
                tablet.alpha = 0f;
                tablet.interactable = false;
                tablet.blocksRaycasts = false;
                tabletUp = false;
            }
            else
            {
                //tabletObject.transform.position = Vector2.MoveTowards(tabletObject.transform.position, tabletUpPoint, step);
                tablet.alpha = 1f;
                tablet.interactable = true;
                tablet.blocksRaycasts = true;
                tabletUp = true;
            }
        }
    }
}
