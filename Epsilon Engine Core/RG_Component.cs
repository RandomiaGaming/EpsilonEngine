using System;

namespace Epsilon_Engine
{
    public class RG_Component
    {
        public RG_Component() { }
        public virtual void Update(RG_Game_Object Parent_Game_Object, double Delta_Time)
        {
            throw new NotImplementedException();
        }
        public virtual void Initialize(RG_Game_Object Parent_Game_Object)
        {
            throw new NotImplementedException();
        }
    }
}