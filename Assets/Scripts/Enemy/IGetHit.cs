using System;

public interface IGetHit
{
    event Action onGetHitEvents;
    event Action onDeathEvents;
    void GetHit(int amount);
}
