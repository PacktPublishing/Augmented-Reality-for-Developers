using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject defaultPictureObject;
    public float spawnDistance = 2.0f;
    private int delay = 0;
    public static GameController instance;
    private AudioSource clickSound;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        clickSound = GetComponent<AudioSource>();
    }

    void Update() {
        if (delay == 0 && GameObject.FindGameObjectsWithTag("Picture").Length == 0) {
            
            CreateNewPicture();
        }
        if (++delay > 30) delay = 0;
    }


    public void CreateNewPicture() {
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;
        Vector3 position = headPosition + gazeDirection * spawnDistance;

        Quaternion orientation = Camera.main.transform.localRotation;
        orientation.x = 0;
        orientation.z = 0;
        GameObject newPicture = Instantiate(defaultPictureObject, position, orientation);
    }

    public void PlayClickFeedback() {
        if (clickSound != null) {
            clickSound.Play();
        }
    }

}
