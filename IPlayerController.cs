using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3
{
    interface IPlayerController
    {
        void Update();
        Direction? GetInput();
        bool IsEndGame();
        void Reverse(long miliseconds);
    }
}
