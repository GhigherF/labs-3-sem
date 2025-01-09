#include <iostream>
 #include <vector>
#include <windows.h>
#include <algorithm>
using namespace std;


struct Edge {
    int src, dest, weight;
};


int find(int parent[], int i) {
    if (parent[i] == i)
        return i;
    return find(parent, parent[i]);
}


void unionSets(int parent[], int rank[], int x, int y) {
    int xroot = find(parent, x);
    int yroot = find(parent, y);

    if (rank[xroot] < rank[yroot]) {
        parent[xroot] = yroot;
    }
    else if (rank[xroot] > rank[yroot]) {
        parent[yroot] = xroot;
    }
    else {
        parent[yroot] = xroot;
        rank[xroot]++;
    }
}


bool compare(Edge a, Edge b) {
    return a.weight < b.weight;
}


void kruskalMST(int graph[8][8]) {
    vector<Edge> edges; 


    for (int i = 0; i < 8; i++) {
        for (int j = i + 1; j < 8; j++) { 
            if (graph[i][j] != 0) { 
                Edge edge = { i, j, graph[i][j] };
                edges.push_back(edge);
            }
        }
    }


    sort(edges.begin(), edges.end(), compare);

    int parent[8];
    int rank[8];

    for (int i = 0; i < 8; i++) {
        parent[i] = i;
        rank[i] = 0;
    }

    vector<Edge> result;
    int e = 0;  


    for (auto& edge : edges) {
        if (e == 7)
            break;

        int x = find(parent, edge.src);
        int y = find(parent, edge.dest);


        if (x != y) {
            result.push_back(edge);
            unionSets(parent, rank, x, y);
            e++;
        }
    }

    int minimumCost = 0;
    for (auto& edge : result) {
        cout <<edge.src + 1 <<" -- "<<edge.dest + 1 << ":  " << edge.weight << endl;
        minimumCost += edge.weight;
    }
    cout <<'\n'<<'\n'<<"weight:" << minimumCost << endl;
}
 
//////////////////////////////////////////////////////////////////////////////////
/// /////////////////////////////////////////////////////////////////////////////
/// ////////////////////////////////////////////////////////////////////////////
/// ///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////// 
/// /////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////
/// //////////////////////////////////////////////////////////////////////////////////////
/// ////////////////////////////////////////////////////////////////////////////////
void main() {
    cout << "Cyclomatic number:" << 16 - 8 + 1 << '\n';
    cout << "El Primmo min graph:\n";
           int min = INT_MAX;
    bool selected[8];
    memset(selected, false, sizeof(selected));
    int matrix[8][8] = { 0,2,0,8,2,0,0,0,
                         2,0,3,10,5,0,0,0,
                         0,3,0,0,12,0,0,7,
                         8,10,0,0,14,3,1,0,
                         2,5,12,14,0,11,4,8,
                         0,0,0,3,11,0,6,0,
                         0,0,0,1,4,6,0,9,
                         0,0,7,0,8,0,9,0 };
        selected[0] = true;
    int row, col;
    int k = 0;
    while (k < 7)
    {
        min = 9999;
        row = 0;
        col = 0;

        for (int i = 0; i < 8; i++)
        {
            if (selected[i])
            {
                for (int j = 0; j < 8; j++)
                {
                    if (!selected[j] && matrix[i][j])
                    {
                        if (min > matrix[i][j])
                        {
                            min = matrix[i][j];
                            row = i;
                            col = j;
                        }
                    }
                }
            }
        }
        cout << row + 1 << " - " << col + 1 << " :  " << matrix[row][col];
        cout << endl;
        selected[col] = true;
        k++;
        
 }
    cout << '\n' << "kruskal min graph : " << '\n';
    kruskalMST(matrix);
}
 

