using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class InstructionEvent : UnityEvent<InstructionStep> { }

public class InstructionsController : MonoBehaviour {
    public InstructionEvent OnInstructionUpdate = new InstructionEvent();

    private int currentStep;
    private InstructionModel currentInstructionModel = new InstructionModel();

    void Awake() {
        currentInstructionModel.LoadData();
    }

    void Start() {
        currentStep = 0;
        CurrentInstructionUpdate();
    }

    public void NextStep() {
        if (currentStep < currentInstructionModel.GetCount() - 1) {
            currentStep++;
            CurrentInstructionUpdate();
        }
    }

    public void PreviousStep() {
        if (currentStep > 0) {
            currentStep--;
            CurrentInstructionUpdate();
        }
    }

    private void CurrentInstructionUpdate() {
        InstructionStep step = currentInstructionModel.GetInstructionStep(currentStep);
        OnInstructionUpdate.Invoke(step);
    }

}
