using ICities;

namespace RemoveDead
{
    public class Identity : IUserMod
    {
        public string Name
        {
            get { return "RemoveDead"; }
        }

        public string Description
        {
            get { return "Removes all dead from all buildings, eliminating the need for deathcare."; }
        }

    }
}
