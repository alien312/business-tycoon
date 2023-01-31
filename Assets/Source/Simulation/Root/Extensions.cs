namespace Source.Simulation.Root
{
    public static class Extensions
    {
        public static T Settings<T> (this GameEntity entity) where T : class
        {
            return entity.Settings.Value as T;
        } 
    }
}