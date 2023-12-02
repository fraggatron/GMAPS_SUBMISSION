using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();

        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2;
        maxY = GameHeight / 2;
        minX = -maxX;
        minY = -maxY;
    }

    void Question2a()
    {
            startPt = new Vector2(0, 0);  // starting position of line
            endPt = new Vector2(2, 3);    // ending position of line

            drawnLine = lineFactory.GetLine(startPt, endPt,
                                               0.02f, Color.black);  // declaring start of vector and end of vector, setting line float width to 0.02 and line color to black
            drawnLine.EnableDrawing(true);

            Vector2 vec2 = endPt - startPt;
            Debug.Log("Magnitude = " + vec2.magnitude);
                }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++) // set i as "maxLines" , if i < n , i will continue to add until value is greater than n
        {
            startPt = new Vector2(
              Random.Range(-5, 5),
              Random.Range(-5, 5)); // randomize start point of the line

            endPt = new Vector2(
                Random.Range(-5, 5),
                Random.Range(-5, 5));  // randomize end point of the line

        
            drawnLine = lineFactory.GetLine(
                startPt, endPt, 0.02f, Color.black); // set width and color of line

            drawnLine.EnableDrawing(true); // enable drawing
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(
            new Vector3(0, 0, 0),
            new Vector3(5, 5, 0),
            Color.red,
            60f);
    }

    void Question2e(int n)
    {
        for (int i = 0; i < n; i++)
        {
            Vector2 randomStart = new Vector2(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f)); // Randomize the start point of the line

            Vector2 randomEnd = new Vector2(
                Random.Range(-5f, 5f),
                Random.Range(-5f, 5f));  // Randomize the end point of the line

            DebugExtension.DebugArrow(
                new Vector3(randomStart.x, randomStart.y, 0),
                new Vector3(randomEnd.x, randomEnd.y, 0),
                Color.white,
                60f);
        }
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;
        //HVector2D c = // Your code here;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
        // ...

        // Your code here

        //Debug.Log("Magnitude of a = " + // Your code here.ToString("F2"));
        // Your code here
        // ...
    }

    public void Question3b()
    {
        // Your code here
        // ...

        //DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        // Your code here
    }

    public void Question3c()
    {

    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        //HVector2D v1 = b - a;
        // Your code here

        //HVector2D proj = // Your code here

        //DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        //DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
