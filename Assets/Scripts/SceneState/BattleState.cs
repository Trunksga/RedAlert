﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleState :ISceneState
{
    public BattleState(string sceneName, SceneStateController controller) 
        : base(sceneName, controller)
    {

    }
}