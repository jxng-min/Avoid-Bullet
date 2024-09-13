using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _State
{
    public interface IPlayerState
    {
        void Handle(PlayerCtrl ctrl);
    }
}