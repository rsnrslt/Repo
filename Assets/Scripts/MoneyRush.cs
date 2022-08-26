using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyRush : MonoBehaviour
{
    
    public static MoneyRush instance;
    public List<GameObject> cubes = new List<GameObject>();
    public float delay = 0.2f;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            ListElementsToMove();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            BackToLine();
        }
    }
    public void StackCube(GameObject other, int index)
    {
        other.transform.parent = transform;
        Vector3 newPos = cubes[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cubes.Add(other);
        StartCoroutine(ObjectSmallToBig());
    }
    public IEnumerator ObjectSmallToBig()
    {
        for (int i = cubes.Count -1; i > 0; i--)
        {
            int x = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;
            cubes[x].transform.DOScale(scale,0.2f).OnComplete(() =>
                cubes[x].transform.DOScale(new Vector3(1, 1, 1), 0.2f));
            yield return new WaitForSeconds(0.08f);
        }
    }
    private void ListElementsToMove()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, delay);
        }
    }

    private void BackToLine()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, delay);
        }
    }
}
