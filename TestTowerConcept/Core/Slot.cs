using CommonElement;
namespace Core
{
    internal class Slot
    {

        internal int CurrentRechargeTime;
        internal int CurrentReloadTime;
        internal bool ReloadRequest;
        public Card card { get; set; }
           
    }
}