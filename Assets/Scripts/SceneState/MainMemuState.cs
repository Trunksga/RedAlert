using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class MainMemuState : ISceneState
{
    public MainMemuState(SceneStateController controller)
        : base("02MainMenuScene", controller)
    {

    }

    public override void StateStart()
    {
        GameObject.Find("StartButton").GetComponent<Button>().onClick.AddListener(
            () => 
            {
                mController.SetState(new BattleState(mController));
            }
            );
    }
}

