using System.Collections.Generic;

namespace Epsilon_Engine
{
    public static class Epsilon_Engine_Kernal_Old
    {
        private static List<RG_Game_Object> Game_Objects = new List<RG_Game_Object>();
        private static List<RG_Game_Manager> Game_Managers = new List<RG_Game_Manager>();
        public static void Initialize()
        {
            foreach (RG_Game_Object GO in Game_Objects)
            {
                GO.Initialize();
            }
            foreach (RG_Game_Manager GM in Game_Managers)
            {
                GM.Initialize();
            }
        }
        public static void Update(double Delta_Time)
        {
            foreach (RG_Game_Object GO in Game_Objects)
            {
                GO.Update(Delta_Time);
            }
            foreach (RG_Game_Manager GM in Game_Managers)
            {
                GM.Update(Delta_Time);
            }
        }
        public static void Instantiate_Game_Object(RG_Game_Object New_Game_Object)
        {
            Game_Objects.Add(New_Game_Object);
        }
        public static void Instantiate_Game_Object()
        {
            Game_Objects.Add(RG_Game_Object.Create());
        }
        public static void Instantiate_Game_Manager(RG_Game_Manager New_Game_Manager)
        {
            Game_Managers.Add(New_Game_Manager);
        }
        public static void Instantiate_Game_Manager()
        {
            Game_Managers.Add(RG_Game_Manager.Create());
        }
        public static List<RG_Game_Object> Get_Instantiated_Game_Objects()
        {
            return new List<RG_Game_Object>(Game_Objects);
        }
    }
}