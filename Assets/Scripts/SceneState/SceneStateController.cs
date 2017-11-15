using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class  SceneStateController
{
    private ISceneState mState;
    

    public void SetState(ISceneState state)
    {
        if (mState != null)
        {
            mState.StateEnd();
            mState = null;
        }

        if (state.SceneName == SceneManager.GetActiveScene().name)
        {
            mState = state;
            mState.StateStart();
        }
        else
        {
            AsyncOperation ao = SceneManager.LoadSceneAsync(state.SceneName);
            ao.completed += (AsyncOperation obj) =>
            {
                mState = state;
                mState.StateStart();
            };
        }

       
    }

    public void StateUpdate()
    {
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

