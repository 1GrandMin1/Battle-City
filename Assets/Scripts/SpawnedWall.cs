using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedWall : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject[] tilePrefabs;
    public int tileCount = 20; // ���������� ������������ ������
    public float tileSize = 1f; // ������ �����

    private int[,] tileMap;

    private void Start()
    {
        GenerateTileMap();
        InstantiateTiles();
    }

    private void GenerateTileMap()
    {
        tileMap = new int[width, height];

        // ���������� ������� ��������� -1 ��� ����������� ��������� �������
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                tileMap[x, y] = -1;
            }
        }

        // ��������� ������ � ��������� ��������
        int tilesGenerated = 0;
        while (tilesGenerated < tileCount)
        {
            int randomX = Random.Range(0, width);
            int randomY = Random.Range(0, height);

            if (tileMap[randomX, randomY] == -1)
            {
                int randomIndex = Random.Range(0, tilePrefabs.Length);
                tileMap[randomX, randomY] = randomIndex;
                tilesGenerated++;
            }
        }
    }

    private void InstantiateTiles()
    {
        float startX = -width / 2f * tileSize;
        float startY = height / 2f * tileSize;

        // �������� ������ �� ������ ������� ��������
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int tileIndex = tileMap[x, y];

                if (tileIndex != -1)
                {
                    GameObject tilePrefab = tilePrefabs[tileIndex];

                    float posX = startX + x * tileSize;
                    float posY = startY - y * tileSize;

                    Vector2 tilePosition = new Vector3(posX, posY);
                    Instantiate(tilePrefab, tilePosition, Quaternion.identity);
                }
            }
        }
    }
}



