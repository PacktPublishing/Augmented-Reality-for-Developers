using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PictureAction : MonoBehaviour, IInputClickHandler {
    public PictureCommand command;
    protected PictureController picture;
    protected Animator animator;

    void Start() {
        picture = GetComponentInParent<PictureController>();
        animator = GetComponent<Animator>();
    }

    public void OnInputClicked(InputClickedEventData eventData) {
        if (animator != null) {
            animator.SetTrigger("Click");
        }
        GameController.instance.PlayClickFeedback();
        Invoke("DoExecute", 1);
    }

    void DoExecute() {
        picture.Execute(command);
    }
}