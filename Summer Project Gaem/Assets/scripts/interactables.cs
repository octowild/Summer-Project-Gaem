using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface interactables
{
    public string prompt { get; }
    public bool interact(Logicmain interactor);
}