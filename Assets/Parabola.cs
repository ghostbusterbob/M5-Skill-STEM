using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] Point point;
    private int numberOfPoints = 10;
    
    void Start()
    {
        for (int i = 0; i < numberOfPoints; i++)
        {
           Point copyOfPoint = Instantiate(point);
           copyOfPoint.transform.position = new Vector3(i, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
