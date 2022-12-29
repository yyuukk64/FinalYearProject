using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    string InteractionPrompt { get; }

    bool Interact(Interactor interactor);
}
