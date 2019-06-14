using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField i1;
    public InputField i2;


    public void ButtonClicked()
    {
        Graph.Instance.BSF_Start(Graph.Instance.vertices[int.Parse(i1.text)], Graph.Instance.vertices[int.Parse(i2.text)]);
    }
}
