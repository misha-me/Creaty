using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyCountText;

    [SerializeField] Transform doorTransform;
    [SerializeField] int keyAmountNeeded;

    public bool isOpen;

    private void Start()
    {
        Close();
    }

    private void FixedUpdate()
    {
        int keyCount = FindObjectOfType<Player>().keyCount;

        if(keyCountText  != null )
            keyCountText.text = keyCount.ToString() + " / " + keyAmountNeeded.ToString();

        if (keyCount >= keyAmountNeeded)
            Open();
        else
            Close();
        
    }
    public void Open()
    {
        if(!isOpen)
        {
            isOpen = true;
            Debug.Log("door open");
            StartCoroutine(DoorCoroutine(Vector3.down, 1.1f, .1f));
        }
    }

    IEnumerator DoorCoroutine(Vector3 direction, float distance, float step)
    {
        Vector3 startingPosition = transform.localPosition;

        float passedDistance = 0;

        while (passedDistance < distance)
        {
            doorTransform.localPosition += direction.normalized * step;
            passedDistance += step;
            yield return new WaitForSeconds(Time.deltaTime);
        }

        doorTransform.position = startingPosition + direction * distance;
    }

    public void Close()
    {
        if (isOpen)
        {
            Debug.Log("door closed");

            StartCoroutine(DoorCoroutine(Vector3.up, .9f, .1f));

            isOpen = false;
        }
    }
}
