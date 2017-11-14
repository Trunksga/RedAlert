using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

    private SceneStateController mController = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject); 
    }
    // Use this for initialization
    void Start () {
        mController = new SceneStateController() ;
	}
	
	// Update is called once per frame
	void Update () {
        mController.StateUpdate();
	}
}
