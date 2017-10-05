using UnityEngine;
using UnityEngine.Events;
using HoloToolkit.Unity.InputModule;

public class ClickableObjectEvent : UnityEvent<GameObject> { }

public class ClickableObject : MonoBehaviour, IInputClickHandler {

    public ClickableObjectEvent OnClickableObjectClicked = new ClickableObjectEvent();
    //public UnityEvent OnObjectClicked = new UnityEvent();
    //protected Animator animator;

    //void Start() {
    //    animator = GetComponent<Animator>();
    //}

    public void OnInputClicked(InputClickedEventData eventData) {
        //if (animator != null) {
        //    animator.SetTrigger("Click");
        //}
        GameController.instance.PlayClickFeedback();
        OnClickableObjectClicked.Invoke(gameObject);
    }
}
