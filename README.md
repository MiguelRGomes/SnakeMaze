# Snake Maze
Bem-vindo ao Snake Maze, um emocionante jogo onde seu objetivo é guiar a cobra para comer o máximo de maçãs possível. Cada maçã que você comer fará a cobra crescer!

# Como Jogar
Objetivo: Comer o máximo de maçãs possível para fazer a cobra crescer.

# Movimentação: Utilize as teclas A e D para movimentar a cobra.
A: Virar a cobra para a esquerda.
D: Virar a cobra para a direita.

https://github.com/MiguelRGomes/SnakeMaze/assets/81479500/b7455c5b-93b6-476b-b312-a81041e501c5

![MenuSnake](https://github.com/MiguelRGomes/SnakeMaze/assets/81479500/6fba8dff-5b31-49b8-8060-5a74cf7d4454)

![Snake2](https://github.com/MiguelRGomes/SnakeMaze/assets/81479500/ea73251f-5a85-4965-a4e1-20b2102b47a4)

![Snake1](https://github.com/MiguelRGomes/SnakeMaze/assets/81479500/455aeac2-b1f6-481d-92de-2c6a200f64ee)

# Funcionalidades

 - Comportamento esperado
-  Movimento Suave: A cobra se moverá de forma contínua para frente e girará suavemente para a esquerda ou direita conforme o jogador pressiona A ou D.
- Crescimento da Cobra: A cada vez que AddTail() é chamado, a cauda da cobra crescerá um segmento, posicionando o novo segmento na posição correta para seguir a cauda existente.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovment : MonoBehaviour
{

    public float Speed;
    public float RotationSpeed;
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = -0.5f;
    
    public GameObject TailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        tailObjects.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime);

        if(Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up*RotationSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up*-1*RotationSpeed*Time.deltaTime);
        }

    }

    public void AddTail()
    {
        Vector3 newTailPos = tailObjects[tailObjects.Count-1].transform.position;
        newTailPos.z -= z_offset;

        tailObjects.Add(GameObject.Instantiate(TailPrefab,newTailPos,Quaternion.identity) as GameObject);
    }
}

 - Comportamento esperado
- Geração de Alimento: Verifica se há um alimento presente no jogo. Se não houver, ele gera um novo alimento em uma posição aleatória dentro dos limites especificados.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float XSize = 8.8f;
    public float ZSize = 8.8f;
    public GameObject foodPrefab;
    public GameObject curFood;
    public Vector3 curPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab,curPos,Quaternion.identity) as GameObject;
    }
    void RandomPos()
    {
        curPos = new Vector3(Random.Range(XSize*-1, XSize),0.25f, Random.Range(ZSize*-1, ZSize));
    }

    void Update()
    {
        if(!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
