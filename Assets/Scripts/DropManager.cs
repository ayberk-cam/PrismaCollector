using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] private float distance = 0.25f;
    [SerializeField] private GameObject cube;
    [SerializeField] private GameObject stackArea;
    [SerializeField] private Transform dropArea;
    [SerializeField] private Transform pickArea;
    private Vector3 spawnPos;

    private void Start()
    {
        spawnPos = dropArea.transform.position;
    }

    private void Drop(string newTag)
    {
        if (dropArea != null)
        {
            var count = FindObjectOfType<StackManager>().stacked;
            Debug.Log(count);
            for (var i = 0; i < count; i++)
            {
                var newDropped = Instantiate(cube, spawnPos, Quaternion.identity);
                newDropped.transform.parent = dropArea.transform;
                newDropped.transform.tag = newTag;
                newDropped.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                spawnPos.y += distance;
                FindObjectOfType<Counter>().Incrementer();
                FindObjectOfType<StackManager>().stacked -= 1;
            }
            Debug.Log(FindObjectOfType<StackManager>().stacked);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (FindObjectOfType<StackManager>().stacked > 0)
        {
            if (collision.gameObject.CompareTag("Drop Area"))
            {
                Drop("Dropped");
                DestroyStack();
            }
        }
    }

    private void DestroyStack()
    {
        var stackNum = stackArea.transform.childCount;
        while (stackNum > 1)
        {
            Destroy(stackArea.transform.GetChild(stackNum - 1).gameObject);
            stackNum -= 1;
        }
        FindObjectOfType<StackManager>().prevPickable = pickArea;
    }
}
