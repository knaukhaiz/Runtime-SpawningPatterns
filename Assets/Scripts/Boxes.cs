using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Boxes : MonoBehaviour
{
    public GameObject CubePrefab;
    public GameObject CubesParent;
    public TMP_InputField NumberOfCubes;
    int cubesPerSet = 9;

    public void RunArrangementMethod()
    {
        GenerateCubes(int.Parse(NumberOfCubes.text));
    }

    void GenerateCubes(int totalBoxes)
    {
        int setCount = (totalBoxes + 8) / cubesPerSet; // Calculate the number of sets needed
        int remainingCubes = totalBoxes;
        float zPosition_Set;
        for (int i = 0; i < setCount; i++)
        {
            Debug.Log($"Set {i + 1}:");
            int cubesInThisSet = Math.Min(cubesPerSet, remainingCubes);
            zPosition_Set = 10 * i;
            int setNumber = i + 1;
            int tempCubeCounter = 0;

            for (int j = 0; j < cubesInThisSet; j++)
            {
                int cubeNumber = i * 9 + j + 1; // Calculate cube number
                GameObject cube = Instantiate(CubePrefab);
                cube.transform.SetParent(CubesParent.transform);
                tempCubeCounter++;

                float xPosition;
                float zPosition = zPosition_Set;

                xPosition = FindXPosition(j + 1);

                if (cubeNumber == 1)
                    zPosition = zPosition_Set;
                else if (cubeNumber > 1 && tempCubeCounter >= 2)
                {
                    zPosition = zPosition_Set + 2;
                    if (tempCubeCounter > 2)
                        tempCubeCounter = -1;
                }

                cube.transform.position = new Vector3(xPosition, 0f, zPosition);
                cube.GetComponent<CubeNumber>().cubeNum.text = cubeNumber.ToString();
            }

            remainingCubes -= cubesInThisSet;
        }
    }

    bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    int FindXPosition(int num)
    {
        int XValue = 0;
        if(IsEven(num))
        {
            int t = num / 2;
            XValue = t * 2;
        }
        else
        {
            int t = num / 2;
            XValue = -t * 2;
        }
        return XValue;
    }
}
