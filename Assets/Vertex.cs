using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vertex : MonoBehaviour
{
    public int congestion;          //미리 설정된 값
    public Dictionary<Vertex, int> distance;
    public List<Vertex> adj;        //미리 지정됨
    public Vertex preVertex;        //이전 Vertex
    public int minCongestion;       //가장 작은 혼잡도

    private void Start()
    {
        minCongestion = 1000;
        distance = new Dictionary<Vertex, int>();        //미리 설정된 값

        foreach (var a in adj)
        {
            Vector3 vec = a.transform.position - transform.position;
            distance.Add(a, (int)vec.magnitude);
        }
    }

    public int CalculateCongestion(Vertex src)
    {
        //Debug.Log("Cal: " + (distance[src] + congestion));
        return distance[src] + congestion;
    }

    private void Update()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = congestion.ToString();
    }
    /*

    public int congestion;
    public Dictionary<Vertex, float> pathDistance;
    public Vertex preVertex;
    public float minDistance = 100f;


    */

}
