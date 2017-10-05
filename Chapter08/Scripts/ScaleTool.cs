using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class ScaleTool : MonoBehaviour {
    private PictureController picture;
    private Vector3 originaButtonScale;

    private GestureRecognizer scaleRecognizer;
    private bool isEditing;

    private Vector3 startGazeDirection;
    private Vector3 startScale;

    void Start() {
        picture = GetComponentInParent<PictureController>();
        originaButtonScale = transform.localScale;

        scaleRecognizer = new GestureRecognizer();
        scaleRecognizer.SetRecognizableGestures(GestureSettings.ManipulationTranslate);

        scaleRecognizer.ManipulationStartedEvent += OnStartedEvent;
        scaleRecognizer.ManipulationUpdatedEvent += OnUpdatedEvent;
        scaleRecognizer.ManipulationCompletedEvent += OnCompletedEvent;
        scaleRecognizer.ManipulationCanceledEvent += OnCanceledEvent;
        scaleRecognizer.StartCapturingGestures();
        isEditing = false;
    }

    private void BeginEdit() {
        startGazeDirection = Camera.main.transform.forward;
        startScale = picture.framedImage.transform.localScale;

        transform.localScale = originaButtonScale * 2.5f;
        isEditing = true;
    }

    private void DoneEdit() {
        transform.localScale = originaButtonScale;
        isEditing = false;
    }

    private void OnDestroy() {
        scaleRecognizer.StopCapturingGestures();
        scaleRecognizer.ManipulationStartedEvent -= OnStartedEvent;
        scaleRecognizer.ManipulationUpdatedEvent -= OnUpdatedEvent;
        scaleRecognizer.ManipulationCompletedEvent -= OnCompletedEvent;
        scaleRecognizer.ManipulationCanceledEvent -= OnCanceledEvent;
    }

    private void OnStartedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("** OnScalingStarted");
        print("ray origin: " + ray.origin + " direction: " + ray.direction);
        print("cam origin: " + Camera.main.transform.position + " direction: " + Camera.main.transform.forward);
        if (!isEditing) {
            Debug.Log("calling raycast");
            RaycastHit hitInfo;
            //if (Physics.Raycast(ray, out hitInfo)) {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo)) { 
                print("hit something");
                if (hitInfo.collider.gameObject == gameObject) {
                    Debug.Log("*** OnScalingStarted HIT");

                    BeginEdit();
                }
            }
        }
    }

    private void OnUpdatedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        if (isEditing) {
            float angle = AngleSigned(startGazeDirection, Camera.main.transform.forward, Vector3.up);
            float scale = 1.0f + angle * 0.1f;
            if (scale > 0.1f) {
                picture.framedImage.transform.localScale = startScale * scale;
            }
        }
    }

    private void OnCompletedEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("** OnScalingCompleted");

        if (isEditing) {
            DoneEdit();
        }
    }

    private void OnCanceledEvent(InteractionSourceKind source, Vector3 position, Ray ray) {
        Debug.Log("** OnScalingCanceled");

        if (isEditing) {
            DoneEdit();
        }
    }

    // Determine the signed angle between two vectors, with normal 'n' as the rotation axis
    private float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n) {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }
}
