using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    /*
    int[] lowestConveniencePathSearch(int startId)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(startId);

        int[] congestions = new int[vertices.Length];
        for (int i = 0; i < congestions.Length; i++) congestions[i] = -1;
        congestions[startId] = 0;

        while(q.Count != 0)
        {
            int node = q.Dequeue();
            foreach (var adj in vertices[node].adj)
            {
                if (congestions[adj] == -1)
                {
                    congestions[adj] = vertices[node].congestion + congestions[node];
                    q.Enqueue(adj);
                }
            }
        }

        return congestions;
    }
    */
    public static Graph Instance { get; set; } = null;
    private void Awake()
    {
        Instance = this;
    }

    public Vertex[] vertices;       //vertex는 미리 설정되어 있다.

    Queue<Vertex> shortestPath;
    public void BSF_Start(Vertex start, Vertex end)
    {
        Queue<Vertex> q = new Queue<Vertex>();
        q.Enqueue(end);

        BSF_Loop(end, start, q);
    }

    void BSF_Loop(Vertex src, Vertex start, Queue<Vertex> path)
    {
        //Debug.Log("src: "+src.name);

        if (src == start)
        {
            Debug.Log("End");
            shortestPath = path;
            BSF_LoopEnd();
            return;
        }

        foreach(var adj in src.adj)
        {
            //Debug.Log("adj: " + adj.name);
            if (!path.Contains(adj))
            {
                if (adj.minCongestion > adj.CalculateCongestion(src))
                {
                    adj.minCongestion = adj.CalculateCongestion(src);
                    adj.preVertex = src;

                    path.Enqueue(adj);

                    BSF_Loop(adj, start, new Queue<Vertex>(path));
                }
            }
        }
    }

    void BSF_LoopEnd()
    {
        while(shortestPath.Peek() != null)
        {
            Vertex present = shortestPath.Dequeue();
            Vertex next = shortestPath.Peek();

            LineRenderer pR = present.gameObject.GetComponent<LineRenderer>();
            pR.startWidth = 0.5f;
            pR.endWidth = 0.5f;
            pR.SetPosition(0, present.gameObject.transform.position);
            pR.SetPosition(1, next.gameObject.transform.position);
        }
    }
}
