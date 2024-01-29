using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //nhung vi tri tren cung
    public Transform[] startingPostion;
    // loai phong 0 --> ho trai phai (RoomLeftRight); 1 --> ho trai phai duoi(RoomLRB); 
    //2 --> ho trai phai tren(RoomTRL); 3 -- > ho het(RoomF)
    public GameObject[] Rooms;
    //direction: 1 left , 2 right , 3down
    public int direction;
    //khoang cach giua cac phong ( diem tao phong)
    public float moveAmount = 20;

    //khong gian gioi han tao phong
    public float MaxX = 30f, MinX = -30f, MinY = -30f;
    //so lan tao phong
    public bool generation = true;
    //layer mask check de dung cai hitbox
    public LayerMask room;
    private int downcounter;

    private float timeBetweenMoves = 0.4f;  // Adjust this value to control the delay between moves
    private float timer = 0f;
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
                //reset so lan xuong duoi
                downcounter = 0;
                //sang phai
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;
                //tao room loai 0 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);

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
                //reset so lan xuong duoi
                downcounter = 0;
                //sang trai
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;
                //tao room loai 0 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);
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
            //so lan xuong duoi +1
            downcounter++;
            // check xem co vua qua khong gian tao map ko trong truong hop nay thi ngung tao
            if (transform.position.y > MinY)
            {
                //check phia tren xem co ho duoi khong aka ( 1, 3)
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<RoomValidator>().RoomType != 1 && roomDetection.GetComponent<RoomValidator>().RoomType != 3)
                {
                    //neu phai thi xoa
                    roomDetection.GetComponent<RoomValidator>().Delete();
                    // + check xem co xuong 2 lan ko vi 2 cai trai phai duoi = fail ==> tao phong full
                    if (downcounter > 1)
                    {
                        Instantiate(Rooms[3], transform.position, quaternion.identity);
                    }
                    //khong thi phong full hoac phong trai phai duoi cung duoc
                    else
                    {
                        int roomtype = UnityEngine.Random.Range(1, 4);
                        //chuyen loai phong full hoac phong trai phai duoi
                        if (roomtype == 2)
                        {
                            roomtype = 1;
                        }
                        Instantiate(Rooms[roomtype], transform.position, quaternion.identity);
                    }
                }
                //----------------------------------------------------------------
                //xuong
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
                //tao room loai 2 den 3
                Instantiate(Rooms[UnityEngine.Random.Range(2, 4)], transform.position, quaternion.identity);
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
        //Instantiate(Rooms[UnityEngine.Random.Range(0, 4)], transform.position, quaternion.identity);
        // direction = UnityEngine.Random.Range(1, 4); // Random direction from 1 to 3
    }

    private void Update()
    {
        if (generation)
        {
            timer += Time.deltaTime;

            if (timer >= timeBetweenMoves)
            {
                Move();
                timer = 0f;  // Reset the timer after moving
            }
        }
    }
}