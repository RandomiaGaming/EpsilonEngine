using System.Collections.Generic;
using EpsilonEngine;
using EpsilonEngine.Modules.Pixel2D;

namespace DontMelt
{
    public class StagePlayer : Pixel2DSceneManager
    {
        public StagePlayer(Pixel2DScene scene) : base(scene)
        {

        }

        public StageData CurrentStageData = null;
        private StageData CurrentlyLoadedStageData = null;

        public Vector2Int WorldToGrid(Vector2 WorldPoint)
        {
            return new Vector2Int((int)WorldPoint.x, (int)WorldPoint.y);
        }

        public Vector2 GridToWorld(Vector2Int GridPoint)
        {
            return (Vector3)(Vector3Int)GridPoint;
        }

        private void Update()
        {
            if (CurrentStageData != null)
            {
                if (CurrentlyLoadedStageData == null)
                {
                    Regenerate();
                }
                else if (!CurrentStageData.Equals(CurrentlyLoadedStageData))
                {
                    Regenerate();
                }
            }
        }

        public void Regenerate()
        {
            CurrentStageData.Clean();
            CurrentlyLoadedStageData = CurrentStageData.Clone();
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }

            Instantiate(PlayerPrefab, transform).transform.position =
                (Vector3Int)CurrentStageData.Player_Pos + new Vector3(0.5f, 0.5f, 0f);

            Instantiate(GoalgatePrefab, transform).transform.position =
                (Vector3Int)CurrentStageData.Goal_Pos + new Vector3(0.5f, 0.5f, 0f);

            foreach (Tile_Data dat in CurrentStageData.Tile_Data)
            {
                foreach (GameObject Item in ItemPrefabs)
                {
                    if (dat.Item_Name == Item.name)
                    {
                        Instantiate(Item, transform).transform.position =
                            (Vector3Int)dat.Position + new Vector3(0.5f, 0.5f, 0f);
                        break;
                    }
                }
            }
        }
        private static Stage_Data CurrentStageData = new Stage_Data();
        private StageGenerator SG;

        [HideInInspector] public Vector2 CheckPointPos;
        public bool OnOffIsOn = true;
        public bool Paused = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            if (CurrentStageData == null)
            {
                SceneManager.LoadScene("TitleScreen");
                return;
            }

            CheckPointPos = CurrentStageData.Player_Pos + new Vector2(0.5f, 0.5f);
            Regenerate();
        }

        private void Regenerate()
        {
            SG = GetComponent<StageGenerator>();
            SG.CurrentStageData = CurrentStageData.Clone();
            SG.Regenerate();
        }

        private void Update()
        {
            if (Paused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void Level_Failed()
        {
            Regenerate();
        }

        public void Level_Completed()
        {
            //PlayerUI.Instance.OnStageCompleted();
        }

        public Stage_Data GetStageData()
        {
            return CurrentStageData.Clone();
        }

        public static void PlayStage(Stage_Data Stage)
        {
            Stage.Clean();
            CurrentStageData = Stage.Clone();
            SceneManager.LoadScene("StagePlayer");
        }
    }
}