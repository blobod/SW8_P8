using UnityEngine;
using UnityEngine.InputSystem.OnScreen; 
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToInstantiate; // The sphere prefab

    [SerializeField]
    private Button removeButton; // The button to remove the sphere

    // Ensure this is the correct type for your on-screen stick
    [SerializeField]
    private OnScreenStick onScreenStick; // The on-screen stick to control the sphere.

    [SerializeField]
    private GameObject onScreenStickBackground; // The black background behind the stick

    private GameObject currentInstance; // The current sphere instance

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
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && currentInstance == null)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    // Instantiate the object and store the reference
                    currentInstance = Instantiate(objectToInstantiate, hit.point + new Vector3(0, 0.1f, 0), Quaternion.identity);
                    // Enable the remove button and the stick
                    removeButton.gameObject.SetActive(true);
                    onScreenStick.gameObject.SetActive(true);
                    onScreenStickBackground.SetActive(true);
                }
            }
        }
    }

    public void RemoveCurrentInstance()
    {
        // Check if there is an instance and destroy it
        if (currentInstance != null)
        {
            Destroy(currentInstance);

            // Disable the remove button and the stick
            removeButton.gameObject.SetActive(false);
            onScreenStick.gameObject.SetActive(false);
            onScreenStickBackground.SetActive(false);
        }
    }
}
