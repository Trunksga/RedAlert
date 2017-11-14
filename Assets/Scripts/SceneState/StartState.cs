using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StartState : ISceneState
{
    public StartState(string sceneName, SceneStateController controller) 
        : base(sceneName, controller)
    {
    }
}
 
