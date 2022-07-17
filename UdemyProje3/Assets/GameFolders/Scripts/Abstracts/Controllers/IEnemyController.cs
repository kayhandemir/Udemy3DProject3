using UdemyProje3.Abstracts.Movements;
using UdemyProje3.Animations;
using UdemyProje3.Combats;
using UdemyProje3.Controllers;
using UnityEngine;

namespace UdemyProje3.Abstracts.Controllers
{
    public interface IEnemyController:IEntityController
    {
        public IMover Mover { get;}
        InventoryController Inventory { get; }
        CharacterAnimation Animation { get; }
        Transform Target { get; set; }
        float Magnitude { get; }
        Dead Dead { get; }
        void FindNearestTarget();
    }
}
