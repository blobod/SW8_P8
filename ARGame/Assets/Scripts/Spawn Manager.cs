using UnityEngine;
using UnityEngine.InputSystem.OnScreen; 
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spherePrefab; // The sphere prefab

    [SerializeField]
    private GameObject rectanglePrefab; // The rectangle prefab

    [SerializeField]
    private Button removeButton; // The button to remove the sphere

    // Ensure this is the correct type for your on-screen stick
    [SerializeField]
    private OnScreenStick onScreenStick; // The on-screen stick to control the sphere.

    [SerializeField]
    private GameObject onScreenStickBackground; // The black background behind the stick

    private GameObject currentInstance; // The current sphere instance

    private GameObject[] rectangles; // Array to store the spawned rectangles

    private int currentRectIndex = 0; // Index of the current rectangle

    private float distanceBetweenRectangles = 0.3f; // Distance between rectangles

    void Start()
    {
        // Initially disable the remove button and the stick+background
        removeButton.gameObject.SetActive(false);
        onScreenStick.gameObject.SetActive(false);
        onScreenStickBackground.SetActive(false);
        removeButton.onClick.AddListener(RemoveCurrentInstance);
    }

    void Update()
    {
        // Check if the ball falls below the height of the rectangle
        if (currentInstance != null && currentInstance.transform.position.y < rectangles[0].transform.position.y - 0.05f)
        {
            ResetBall();
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && currentInstance == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Instantiate the first rectangle at the touch position
                    GameObject initialRectangle = Instantiate(rectanglePrefab, hit.point + new Vector3(0, 0.1f, 0), Quaternion.identity);
                    rectangles = new GameObject[5]; // 5 Rectangles
                    rectangles[currentRectIndex] = initialRectangle;
                    currentRectIndex++;

                    // Instantiate the sphere on the first spawned rectangle
                    currentInstance = Instantiate(spherePrefab, initialRectangle.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                    // Enable the remove button and the stick
                    removeButton.gameObject.SetActive(true);
                    onScreenStick.gameObject.SetActive(true);
                    onScreenStickBackground.SetActive(true);

                    // Calculate positions for subsequent rectangles based on the position of the initial rectangle
                    for (int i = 1; i < rectangles.Length; i++)
                    {
                        GameObject newRectangle = Instantiate(rectanglePrefab, initialRectangle.transform.position + new Vector3(0, 0, i * distanceBetweenRectangles), Quaternion.identity);
                        rectangles[currentRectIndex] = newRectangle;
                        currentRectIndex++;
                    }
                }
            }
        }
    }

    void ResetBall()
    {
            Debug.Log("Ball Position: " + currentInstance.transform.position);
            Debug.Log("First Rectangle Position: " + rectangles[0].transform.position);
        // Reset the ball to its initial position on the first rectangle
        currentInstance.transform.position = rectangles[0].transform.position + new Vector3(0, 0.1f, 0);
    }

    public void RemoveCurrentInstance()
    {
        // Check if there is an instance and destroy it
        if (currentInstance != null)
        {
            Destroy(currentInstance);

            // Destroy all spawned rectangles
            foreach (GameObject rectangle in rectangles)
            {
                if (rectangle != null)
                {
                    Destroy(rectangle);
                }
            }

            // Disable the remove button and the stick
            removeButton.gameObject.SetActive(false);
            onScreenStick.gameObject.SetActive(false);
            onScreenStickBackground.SetActive(false);
        }
    }
}
