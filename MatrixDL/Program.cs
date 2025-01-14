int[,] matrix;
int[,] visited;

Read("../../../input.txt");
AfisareMatrice(matrix);
InitializeVisitMatrix();
AfisareMatrice(visited);

void Solve(int istart, int jstart, int iend, int jend)
{
    visited[istart,jstart] = matrix[istart,jstart];

    Queue<Tridata> queue = new Queue<Tridata>();

    //queue.Enqueue(new Tridata(istart, jstart, visited[istart, jstart]));

    
}

void Read(string txt)
{
    StreamReader sr = new StreamReader(txt);

    string buffer;
    string[] line;

    int n = int.Parse(sr.ReadLine());

    matrix = new int[n, n];

    int j = 0;
    while ((buffer = sr.ReadLine()) != null)
    {
        line = buffer.Split(' ');
        for (int i = 0; i < line.Length; i++)
        {
            matrix[j, i] = Convert.ToInt32(line[i]);
        }
        j++;
    }
    sr.Close();
}

void AfisareMatrice(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write(matrix[i,j] + " ");
        }
        Console.WriteLine();
    }
}

void InitializeVisitMatrix()
{
    int inf = int.MaxValue;
    visited = new int[matrix.GetLength(0), matrix.GetLength(1)];
    for (int i = 0; i < visited.GetLength(0); i++)
    {
        for (int j = 0; j < visited.GetLength(1); j++)
        {
            visited[i, j] = inf;
        }
    }
}

internal class Tridata
{

}
