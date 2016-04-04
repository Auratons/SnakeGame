

namespace hw3
{
    interface IPlayerController
    {
        void Update();
        Direction GetInput();
        bool IsEndGame();
        void Reverse(long miliseconds);
    }
}
