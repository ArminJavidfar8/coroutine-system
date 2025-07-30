using System;
using System.Collections;
using UnityEngine;

namespace YekGames.CoroutineSystem.Abstractio
{
    public interface ICoroutineService
    {
        Coroutine StartCoroutine(IEnumerator routine);
        void StopCoroutine(Coroutine routine);
        Coroutine StartDelayedTask(float delay, Action task);
        void DoTaskAtNextFrame(Action task);
    }
}