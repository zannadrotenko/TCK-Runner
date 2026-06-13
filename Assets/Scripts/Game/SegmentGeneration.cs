using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SegmentGeneration : MonoBehaviour 
{
    public GameObject [] segment;

    [SerializeField] float zPos = 112.5f;
    [SerializeField] bool creatingSegment = false;
    [SerializeField] int segmentNum;

    private void Update()
    {
        if (creatingSegment == false)
        {
            creatingSegment = true;
            StartCoroutine(SegmentGen());
        }
    }

    IEnumerator SegmentGen()
    {
        segmentNum = Random.Range(0, segment.Length);
        GameObject spawnSegment = Instantiate(segment[segmentNum], new Vector3(0, 0, zPos), Quaternion.identity);
        spawnSegment.SetActive(true);
        zPos += 112.5f;
        yield return new WaitForSeconds(3);
        creatingSegment = false;
    }
}
