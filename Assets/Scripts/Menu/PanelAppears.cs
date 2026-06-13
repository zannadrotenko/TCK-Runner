using UnityEngine;
using System.Collections;

public class PanelAppears : MonoBehaviour
{
    public float speed = 2000f;
    private bool shouldDrop = false;
    [SerializeField] private RectTransform shopPanel;
    [SerializeField] AudioSource dropSound;
    [SerializeField] private float targetTop = 231.5f;
    [SerializeField] private float targetBottom = 425.5f;
    [SerializeField] GameObject shopButton;
    [SerializeField] GameObject menuButton;


    public void DropDown()
    {
        StartCoroutine(WaitAndMove());
    }
    private IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(1f);
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
                dropSound.Play();
                shouldDrop = false;
                shopButton.SetActive(false);
                menuButton.SetActive(true);
            }
        }
    }
}