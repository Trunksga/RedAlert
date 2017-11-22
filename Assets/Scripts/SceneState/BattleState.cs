using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class BattleState :ISceneState
{
    public BattleState(SceneStateController controller) 
        : base("03BattleScene", controller)
    {

    }

    private GameFacade mFacade = GameFacade.Instance;

    public override void StateStart()
    {
        mFacade.Init();
    }

    public override void StateEnd()
    {
        mFacade.Release();
    }

    public override void StateUpdate()
    {
        if (mFacade.IsGameOver)
        {
            mController.SetState(new MainMemuState(mController));
        }

        mFacade.Update();
    }
}
