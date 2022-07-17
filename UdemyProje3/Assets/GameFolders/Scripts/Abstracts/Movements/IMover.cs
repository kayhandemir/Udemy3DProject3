using UnityEngine;

namespace UdemyProje3.Abstracts.Movements
{
    public interface IMover
    {
        void MoveAction(Vector3 direction,float moveSpeed);
    }
}

