using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System;

public class TapToPlaceInstructions : MonoBehaviour, IInputClickHandler {
    public SpatialMappingManager spatialMapping;
    public bool placing;

    public void OnInputClicked(InputClickedEventData eventData) {
        placing = !placing;

        spatialMapping.DrawVisualMeshes = placing;
    }

    void Start() {
        spatialMapping.DrawVisualMeshes = placing;
    }

	void Update () {
		if (placing) {
            Vector3 headPosition = Camera.main.transform.position;
            Vector3 gazeDirection = Camera.main.transform.forward;
            int layerMask = 1 << spatialMapping.PhysicsLayer;
            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, layerMask)) {
                this.transform.parent.position = hitInfo.point;
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.parent.rotation = toQuat;
            }
        }
	}
}
