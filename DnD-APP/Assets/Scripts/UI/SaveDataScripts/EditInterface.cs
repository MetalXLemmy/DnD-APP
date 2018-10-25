using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class EditInterface : MonoBehaviour {

    public Text IDText;
    public InputField nameInput;
    public InputField descriptionInput;

    protected int identifier;

    public abstract void SetIdentifier(int identifier);

}
