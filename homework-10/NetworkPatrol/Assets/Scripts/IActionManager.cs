using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mygame
{
    public interface IActionManager
    {
        void PlayDisk(GameObject disk, Vector3 initPosition);
    }
}