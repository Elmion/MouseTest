using CommonElement;
namespace Core
{
    internal class Slot
    {

        internal int CurrentRechargeTime;
        internal int CurrentReloadTime;
        internal bool ReloadRequest;
        internal int Cristall { get; set; }
        public Card card { get; set; }
        public Slot()
        {
            Cristall = 0;
        }
        public bool CristallRemove()
        {
            if (Cristall == 0) return false;
            Cristall--;
            return true;
        }
    }
}