using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnitMove
{
    public class Unit
    {
        public Func< object[], object> ChangeStatus;
        public Func<Unit, Unit> BuffUnit;

        private Game _parentGame;
        public Game Game { get { return _parentGame; } }

        IMove moveType;
        IAttack attackType;

        public Unit OriginUnit;

        public Unit(Game game, IMove move,IAttack attack)
        {
            _parentGame = game;
            moveType = move;
            attackType = attack;
        }
        public void Move(Unit u)
        {
            moveType.Move(u);
        }
        public void Attack(Unit u)
        {
            attackType.Attack(u);
        }
        void Update()
        {
            //Бафаем копию юнита и используем её для Апдейта;
            Unit BuffedUnit = OriginUnit;
            BuffedUnit = BuffUnit(BuffedUnit);

            Move(BuffedUnit);
            Attack(BuffedUnit);
        }
    }
}
