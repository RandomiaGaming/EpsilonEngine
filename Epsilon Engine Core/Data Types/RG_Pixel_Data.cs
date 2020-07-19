namespace RG_Engine
{
    public sealed class RG_Pixel_Data
    {
        public RG_Point Position = RG_Point.Create(0, 0);
        public RG_Color Color = RG_Color.Create(255, 255, 255);

        private RG_Pixel_Data() { }
        public static RG_Pixel_Data Create()
        {
            RG_Pixel_Data Output = new RG_Pixel_Data();
            Output.Position = RG_Point.Create(0, 0);
            Output.Color = RG_Color.Create(255, 255, 255);
            return Output;
        }
        public static RG_Pixel_Data Create(RG_Point Position, RG_Color Color)
        {
            RG_Pixel_Data Output = new RG_Pixel_Data();
            Output.Position = Position.Clone();
            Output.Color = Color.Clone();
            return Output;
        }

        public override string ToString()
        {
            return $"Color:{Color}, Position:{Position}";
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(RG_Pixel_Data))
            {
                return this == (RG_Pixel_Data)obj;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(RG_Pixel_Data A, RG_Pixel_Data B)
        {
            return A.Position == B.Position && A.Color == B.Color;
        }
        public static bool operator !=(RG_Pixel_Data A, RG_Pixel_Data B)
        {
            return !(A == B);
        }
    }
}