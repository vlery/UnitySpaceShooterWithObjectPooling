using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cube;
public class ProblemHandler
{

    public struct Vec4i
    {
        //FP,FN,TP,TN
        public int i, j, k, l;

        public Vec4i(int i,int j,int k, int l)
        {
            this.i = i;
            this.j = j;
            this.k = k;
            this.l = l;
        }

    }

    static Problem problem;
    public static bool loadProblem(string path)
    {
        problem = Problem.Load(path);
        if (problem == null) return false;
        return true;
    }

    public static void saveProblem(string path)
    {
        problem.Save(path);
    }

   public static void setGrid(Grid grid)
    {
        for (int i = 0; i < problem.xTiles.Length; i++)
        {
            for (int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                for (int k = 0; k < problem.xTiles[i].yTiles[j].zTiles.Length; k++)
                {
                    grid.SetActive(i, j, k,problem.xTiles[i].yTiles[j].zTiles[k].hasCube);
                }
            }
        }
    }

    public static void setProblem(Grid grid)
    {
        for (int i = 0; i < problem.xTiles.Length; i++)
        {
            for (int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                for (int k = 0; k < problem.xTiles[i].yTiles[j].zTiles.Length; k++)
                {
                    problem.xTiles[i].yTiles[j].zTiles[k].hasCube = grid.GetActive(i, j, k);
                }
            }
        }

    }

   public static bool checkSolution(Grid grid, out Vec4i score)
    {
        bool vote1 = true;
        bool vote2 = true;
        bool vote3 = true;
        bool vote4 = true;

        bool vote5 = true;
        bool vote6 = true;
        bool vote7 = true;
        bool vote8 = true;
        //FP,FN,TP,TN
        Vec4i score1 = new Vec4i(0, 0, 0, 0);
        Vec4i score2 = new Vec4i(0, 0, 0, 0);
        Vec4i score3 = new Vec4i(0, 0, 0, 0);
        Vec4i score4 = new Vec4i(0, 0, 0, 0);
        Vec4i score5 = new Vec4i(0, 0, 0, 0);
        Vec4i score6 = new Vec4i(0, 0, 0, 0);
        Vec4i score7 = new Vec4i(0, 0, 0, 0);
        Vec4i score8 = new Vec4i(0, 0, 0, 0);
        for (int i = 0; i < problem.xTiles.Length; i++)
        {
            for (int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                for (int k = 0; k < problem.xTiles[i].yTiles[j].zTiles.Length; k++)
                {
                    int ii = (problem.xTiles.Length - 1) - i;
                    int kk = (problem.xTiles[i].yTiles[j].zTiles.Length - 1) - k;
                    //check symmetric solutions
                    if (grid.GetTile(i, j, k).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote1 = false;
                        if (grid.GetTile(i, j, k).GetIsOccupied())
                        {
                            score1.i++;
                        }
                        else
                        {
                            score1.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(i, j, k).GetIsOccupied())
                        {
                            score1.k++;
                        }
                        else
                        {
                            score1.l++;
                        }
                    }
                    //2
                    if (grid.GetTile(ii, j, k).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote2 = false;
                        if (grid.GetTile(ii, j, k).GetIsOccupied())
                        {
                            score2.i++;
                        }
                        else
                        {
                            score2.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(ii, j, k).GetIsOccupied())
                        {
                            score2.k++;
                        }
                        else
                        {
                            score2.l++;
                        }                 
                    }
                    //3
                    if (grid.GetTile(i, j, kk).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote3 = false;
                        if (grid.GetTile(i, j, kk).GetIsOccupied())
                        {
                            score3.i++;
                        }
                        else
                        {
                            score3.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(i, j, kk).GetIsOccupied())
                        {
                            score3.k++;
                        }
                        else
                        {
                            score3.l++;
                        }
                    }
                    //4
                    if (grid.GetTile(ii, j, kk).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote4 = false;
                        if (grid.GetTile(ii, j, kk).GetIsOccupied())
                        {
                            score4.i++;
                        }
                        else
                        {
                            score4.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(ii, j, kk).GetIsOccupied())
                        {
                            score4.k++;
                        }
                        else
                        {
                            score4.l++;
                        }
                    }
                    //check inverse solutions
                    //5
                    if (grid.GetTile(k, j, i).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote5 = false;
                        if (grid.GetTile(k, j, i).GetIsOccupied())
                        {
                            score5.i++;
                        }
                        else
                        {
                            score5.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(k, j, i).GetIsOccupied())
                        {
                            score5.k++;
                        }
                        else
                        {
                            score5.l++;
                        }
                    }
                    //6
                    if (grid.GetTile(k, j, ii).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote6 = false;
                        if (grid.GetTile(k, j, ii).GetIsOccupied())
                        {
                            score6.i++;
                        }
                        else
                        {
                            score6.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(k, j, ii).GetIsOccupied())
                        {
                            score6.k++;
                        }
                        else
                        {
                            score6.l++;
                        }
                    }
                    //7
                    if (grid.GetTile(kk, j, i).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote7 = false;
                        if (grid.GetTile(kk, j, i).GetIsOccupied())
                        {
                            score7.i++;
                        }
                        else
                        {
                            score7.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(kk, j, i).GetIsOccupied())
                        {
                            score7.k++;
                        }
                        else
                        {
                            score7.l++;
                        }
                    }
                    //8
                    if (grid.GetTile(kk, j, ii).GetIsOccupied() == problem.xTiles[i].yTiles[j].zTiles[k].hasCube)
                    {
                        vote8 = false;
                        if (grid.GetTile(kk, j, ii).GetIsOccupied())
                        {
                            score8.i++;
                        }
                        else
                        {
                            score8.j++;
                        }
                    }
                    else
                    {
                        if (grid.GetTile(kk, j, ii).GetIsOccupied())
                        {
                            score8.k++;
                        }
                        else
                        {
                            score8.l++;
                        }
                    }
                }
            }
        }
        score = score1;
        if (score2.k + score2.l > score.k + score.l)
        {
            score = score2;
        }
        if (score3.k + score3.l > score.k + score.l)
        {
            score = score3;
        }
        if (score4.k + score4.l > score.k + score.l)
        {
            score = score4;
        }
        if (score5.k + score5.l > score.k + score.l)
        {
            score = score5;
        }
        if (score6.k + score6.l > score.k + score.l)
        {
            score = score6;
        }
        if (score7.k + score7.l > score.k + score.l)
        {
            score = score7;
        }
        if (score8.k + score8.l > score.k + score.l)
        {
            score = score8;
        }
        return (vote1 || vote2 || vote3 || vote4||vote5||vote6||vote7||vote8);
    }

    public static void GenerateRandomProblemJSON(int dimension,string path)
    {
        Problem problem = new Problem();
        problem.xTiles = new Problem.tileDataArray2D[dimension];
        for(int i = 0; i < problem.xTiles.Length; i++)
        {
            problem.xTiles[i].yTiles = new Problem.tileDataArray[dimension];
            for(int j = 0; j < problem.xTiles[i].yTiles.Length; j++)
            {
                problem.xTiles[i].yTiles[j].zTiles = new Problem.tileData[dimension];
            }
        }
        problem.dimension = dimension;
        for(int i = 0; i < dimension; i++)
        {
            for(int j = 0; j < dimension; j++)
            {
                for(int k = 0; k < dimension; k++)
                {
                    problem.xTiles[i].yTiles[j].zTiles[k].hasCube = (Random.Range(-1.0f, 1.0f) > 0.0f);
                }
            }
        }
        problem.Save(path);
    } 

    public static int GetProblemSize()
    {
        return problem.dimension;
    }
}
