using UnityEngine;
using System.Collections;

public class LavaScript : MonoBehaviour {

    //---------------------
    //Script Edited By
    // Callum Stirrup-Prazak
    //
    //---------------------

    SpawnerScript spawner;
    public GameObject particle;

    private Spring[] springs;
    const int springCount = 25;

    private float spread = 0.2f;

    public Vector3[] vertices;
    public Vector2[] uvs;
    public int[] triangles;

    private Mesh mesh;

	void Start () {

        spawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpawnerScript>();

        springs = new Spring[springCount];
        triangles = new int[springCount * 6];
        uvs = new Vector2[springCount * 4];
        vertices = new Vector3[springCount * 4];

        for (int i = 0; i < springCount; ++i)
        {
            springs[i] = new Spring();
        }

        int j = 0;

        for (int i = 0; i < springCount * 6; )
        {
            triangles[i] = j;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
            triangles[i + 3] = j;
            triangles[i + 4] = j + 2;
            triangles[i + 5] = j + 3;

            j += 4;
            i += 6;
        }

        for (int i = 0; i < springCount * 4; i += 4)
        {
            uvs[i] = new Vector2(1, 1);
            uvs[i + 1] = new Vector2(0, 1);
            uvs[i + 2] = new Vector2(1, 0);
            uvs[i + 3] = new Vector2(0, 0);
        }

        for (int i = 1; i < springCount; ++i)
        {
            vertices[(i - 1) * 4]     = new Vector3(0 - ((float)springCount / 8.0f) + ((float)(i - 1) / 4.0f), springs[i - 1].height, 0);
            vertices[(i - 1) * 4 + 1] = new Vector3(0 - ((float)springCount / 8.0f) + ((float)(i) / 4.0f), springs[i].height, 0);
            vertices[(i - 1) * 4 + 2] = new Vector3(0 - ((float)springCount / 8.0f) + ((float)(i) / 4.0f), -5.5f, 0);
            vertices[(i - 1) * 4 + 3] = new Vector3(0 - ((float)springCount / 8.0f) + ((float)(i - 1) / 4.0f), -5.5f, 0);
        }

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
	}
	
	void Update () {

        for (int i = 0; i < springCount; ++i)
        {
            springs[i].Update();
        }

        float[] leftDeltas = new float[springCount];
        float[] rightDeltas = new float[springCount];

        // do some passes where springs pull on their neighbours
        for (int j = 0; j < 6; j++)
        {
            for (int i = 0; i < springs.Length; i++)
            {
                if (i > 0)
                {
                    leftDeltas[i] = spread * (springs[i].height - springs[i - 1].height);
                    springs[i - 1].velocity += leftDeltas[i];
                }
                if (i < springs.Length - 1)
                {
                    rightDeltas[i] = spread * (springs[i].height - springs[i + 1].height);
                    springs[i + 1].velocity += rightDeltas[i];
                }
            }

            for (int i = 0; i < springs.Length; i++)
            {
                if (i > 0)
                    springs[i - 1].height += leftDeltas[i];
                if (i < springs.Length - 1)
                    springs[i + 1].height += rightDeltas[i];
            }
        }

        CreateVertices();
	}

    void CreateVertices()
    {
        for (int i = 1; i < springCount; ++i)
        {
            vertices[(i - 1) * 4].y = springs[i - 1].height;
            vertices[(i - 1) * 4 + 1].y = springs[i].height;
            vertices[(i - 1) * 4 + 2].y = -5.5f;
            vertices[(i - 1) * 4 + 3].y = -5.5f;
        }

        mesh.vertices = vertices;
    }

    void Splash(int index, float speed)
    {
        if (index >= 0 && index < springCount)
        {
            springs[index].velocity = speed;
        }
    }
    void Splash(float x, float speed)
    {
        int index = (int)((x + 3.2f) * 3.90625f);
        Splash(index, speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            //if a sheep
            Splash(other.transform.position.x, 1.5f);
            AbsorbSheep(other.gameObject);
            spawner.DropBall();

            Instantiate(particle, other.transform.position - new Vector3(0, 0.5f, 0), transform.rotation);
        }
    }

    void AbsorbSheep(GameObject sheep)
    {
        sheep.GetComponent<AbsorbScript>().GetAbsorbed();
    }
}

public class Spring
{
    public float velocity;

    public float height = -4;
    private float targetHeight = -4;

    void Start()
    {
        height = targetHeight;

        velocity = 0.0f;
    }
    public void Update()
    {
        float k = 0.02f; // adjust this value to your liking
        float x = height - targetHeight;
        float acceleration = (-k * x) - (0.15f * velocity);

        height += velocity;
        velocity += acceleration;
    }
}
