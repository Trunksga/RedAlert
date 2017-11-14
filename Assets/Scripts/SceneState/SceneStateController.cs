using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class  SceneStateController
{
    private ISceneState mState;

    public void StateUpdate()
    {
        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}

