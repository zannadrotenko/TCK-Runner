using UnityEngine;
using System.Collections;

public class PanelDisappeares : MonoBehaviour
{
    public float speed = 2000f;
    private bool shouldDrop = false;
    [SerializeField] private RectTransform shopPanel;
    [SerializeField] private float targetTop = -1826.5f;
    [SerializeField] private float targetBottom = 2493.5f;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject menuButton;


    public void DropUp()
    {
        StartCoroutine(Move());
    }
    private IEnumerator Move()
    {
        yield return new WaitForSeconds(0f);
        shouldDrop = true;
    }


    void Update()
    {
        if (shouldDrop)
        {
            float currentLeft = shopPanel.offsetMin.x;
            float currentBottom = shopPanel.offsetMin.y;

            float currentRight = -shopPanel.offsetMax.x;
            float currentTop = -shopPanel.offsetMax.y;

            float newBottom = Mathf.MoveTowards(currentBottom, targetBottom, speed * Time.deltaTime);
            float newTop = Mathf.MoveTowards(currentTop, targetTop, speed * Time.deltaTime);

            shopPanel.offsetMin = new Vector2(currentLeft, newBottom);
            shopPanel.offsetMax = new Vector2(-currentRight, -newTop);


            if (Mathf.Approximately(newBottom, targetBottom) && Mathf.Approximately(newTop, targetTop))
            {
                shouldDrop = false;
                shopButton.SetActive(true);
                menuButton.SetActive(false);
            }
        }
    }
}

