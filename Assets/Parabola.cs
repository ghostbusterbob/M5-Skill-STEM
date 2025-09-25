using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] Point point;
    private int numberOfPoints = 11;
    Vector2 minScreen, maxScreen;   
    
    void Start()
    {
        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);   
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));   
        
        float dx = (maxScreen.x - minScreen.x) / numberOfPoints;
        
        for (int i = 0; i < numberOfPoints; i++)
        { 
            float x_pos = minScreen.x + i * dx; 
           Point copyOfPoint = Instantiate(point);
           copyOfPoint.transform.position = new Vector3(x_pos, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
