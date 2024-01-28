using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //nhung vi tri tren cung
    public Transform[] startingPostion;
    // loai phong 0 --> ho trai phai; 1 --> ho trai phai duoi; 2 --> ho trai phai tren; 3 -- > ho het
    public GameObject[] Rooms;
    //1 left , 2 right , 3down
    public int direction;
    //khoang cach giua cac phong ( diem tao phong)
    public float moveAmount = 20;
    private float timeBtwRoom;
    public float starttimeBtwRoom = 8f;
    //khong gian gioi han tao phong
    public float MaxX = 30f, MinX = -30f, MinY = -30f;
    //so lan tao phong
    public bool generation = true;
    void Start()
    {
        int randStartingPos = UnityEngine.Random.Range(0, startingPostion.Length);
        transform.position = startingPostion[randStartingPos].position;
        Instantiate(Rooms[1], transform.position, quaternion.identity);
        direction = UnityEngine.Random.Range(1, 4); // random huong di tu 1 - 3
    }

    private void Move()
    {
        // right
        if (direction == 1)
        {
            // check xem co vua qua khong gian tao map ko
            if (transform.position.x < MaxX)
            {
                //sang phai
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;
                //tao room loai 0 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)],transform.position,quaternion.identity);

                //de neu no di sang phai roi thi ko quay lai nua aka: khong sang trai
                direction = UnityEngine.Random.Range(1, 4);
                if (direction == 2)
                {
                    direction = 1;
                }
                //--------------------------------------------------------------------
            }
            else
            {
                // cham vao bien ben phai thi di xuong duoi
                direction = 3;
            }
        }
        // left
        else if (direction == 2)
        {
            // check xem co vua qua khong gian tao map ko
            if (transform.position.x > MinX)
            {
                //sang trai
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
                //tao room loai 0 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)],transform.position,quaternion.identity);
                //de neu no di sang trai roi thi ko quay lai nua aka: khong sang phai
                direction = UnityEngine.Random.Range(1, 4);
                if (direction == 1)
                {
                    direction = 2;
                }
            }
            else
            {
                // cham vao bien ben trai thi di xuong duoi
                direction = 3;
            }

        }
        // down
        else if (direction == 3)
        {
            // check xem co vua qua khong gian tao map ko trong truong hop nay thi ngung tao
            if (transform.position.y > MinY)
            {
                //xuong
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
                //tao room loai 2 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(2, 4)],transform.position,quaternion.identity);

                // xuong lien tiep cung dc
                direction = UnityEngine.Random.Range(1, 4);
            }
            else
            {
                //cham bien day thi ngung tao
                generation = false;
            }
        }
        //tao phong random tu 0 den 3
        Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);
        // direction = UnityEngine.Random.Range(1, 4); // Random direction from 1 to 3
    }

    private void Update()
    {
            if (generation &&timeBtwRoom <= 0)
            {
                Move();
                timeBtwRoom = starttimeBtwRoom;
            }
            else
            {
                timeBtwRoom -= Time.deltaTime;
            }
        }
}