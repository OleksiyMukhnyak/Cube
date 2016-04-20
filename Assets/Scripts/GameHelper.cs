using UnityEngine;
using System.Collections.Generic;

public class GameHelper : MonoBehaviour
{
    public GameObject Cube;

    public int Height
    {
        get { return _height; }
        set
        {
            if (value <= 0)
                _height = 1;
            else _height = value;
        }
    }

    public int Width
    {
        get { return _width; }
        set
        {
            if (value <= 0)
                _width = 1;
            else _width = value;
        }
    }

    int _height = 20;
    int _width = 36;

    public List<Material> CubeMaterials = new List<Material>();

    List<WaveHelper> Cubes;

    void Start()
    {
        Cubes = new List<WaveHelper>();
        InctantiateCube();
    }
    void Update()
    {
        if (!Input.GetMouseButtonUp(0))
            return;

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            AddCurrentCenter(new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.z));
        }
    }

    void InctantiateCube()
    {
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                WaveHelper go = (Instantiate(Cube, new Vector3(i, 0, j), new Quaternion()) as GameObject).GetComponent<WaveHelper>();
                go.gameObject.GetComponent<MeshRenderer>().material = CubeMaterials[Random.Range(0, CubeMaterials.Count)];
                Cubes.Add(go);
            }
        }
    }

     void AddCurrentCenter(Vector2 currentCenter)
    {
        for (int i = 0; i < Cubes.Count; i++)
        {
            Cubes[i].AddCenter(currentCenter);
        }
    }
}
