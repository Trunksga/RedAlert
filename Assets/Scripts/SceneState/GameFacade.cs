using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameFacade
{
    
    private bool mIsGameOver = false;
    private ArchievementSystem mArchievementSystem ;
    private CampSystem mCampSystem ;
    private CharacterSystem mCharacterSystem;
    private EnergySystem mEnergySystem;
    private GameEventSystem mGameEventSystem;
    private StageSystem mStageSystem;
    private GamePauseUI mGamePauseUI;
    private CampInfoUI mCampInfoUI;
    private GameStateInfoUI mGameStateInfoUI;
    private SoldierInfoUI mSoldierInfoUI;

    private List<IGameSystem> mGameSystemList = new List<IGameSystem>();
    private List<IBaseUI> mUISystemList = new List<IBaseUI>();

    private GameFacade() { }
    private static GameFacade _instance = new GameFacade();
    public static GameFacade Instance { get { return _instance; } }
    
    public bool IsGameOver
    {
        get { return mIsGameOver; }
      
    }

    void SubGameSystemInit<T>(T point) where T :  new()
    {
        if (point != null) 
            return;
    
        point = new T();

        if (point.GetType().IsSubclassOf(typeof(IGameSystem)))
        {
            IGameSystem tmp = point as IGameSystem;
            tmp.Init();
            mGameSystemList.Add(tmp);
        }
        else if (point.GetType().IsSubclassOf(typeof(IBaseUI)))
        {
            IBaseUI tmp = point as IBaseUI;
            tmp.Init();
            mUISystemList.Add(tmp);
        }
    }

    public void Init()
    {
        SubGameSystemInit( mArchievementSystem);
        SubGameSystemInit( mCampSystem);
        SubGameSystemInit( mCharacterSystem);
        SubGameSystemInit( mEnergySystem);
        SubGameSystemInit( mGameEventSystem);
        SubGameSystemInit( mStageSystem);
        SubGameSystemInit( mGamePauseUI);
        SubGameSystemInit( mCampInfoUI);
        SubGameSystemInit( mGameStateInfoUI);
        SubGameSystemInit( mSoldierInfoUI);
    }

    public void Update()
    {
        foreach (var item in mGameSystemList)
        {
            item.Update();
        }

        foreach (var item in mUISystemList)
        {
            item.Update();
        }
    }

    public void Release()
    {
        foreach (var item in mGameSystemList)
        {
            item.Release();
        }
        mGameSystemList.Clear();

        foreach (var item in mUISystemList)
        {
            item.Release();
        }
        mUISystemList.Clear();
    }
}

