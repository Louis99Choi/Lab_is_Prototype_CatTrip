using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public static Player_Movement instance;

    public float speed; //player speed
    public int walkCount; //타일 단위 이동을 할때 pixel per tile = speed * walkCount 
    private int currentWalkCount; //현재 이동 카운트 (walkCount가 되면 0으로 초기화)

    private Vector3 vector; 

    private BoxCollider2D boxCollider;
    public LayerMask layerMask;  //통과가 불가능한 장애물들의 layer 설정
    private Animator animator;

    public float runSpeed;
    private float applyRunSpeed;
    private bool applyRunFlag = false;
    private bool canMove = true;

    private void Start()
    {
        boxCollider = this.GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    IEnumerator MoveCoroutine()
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0) //방향키를 계속 누르고있을때 코루틴이 새로 실행되어 같은 애니매이션을 보이는것을 방지
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                applyRunSpeed = runSpeed;
                applyRunFlag = true;
            }
            else
            {
                applyRunSpeed = 0;
                applyRunFlag = false;
            }

            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z);

            if (vector.x != 0)  //x, y 축 동시 입력 제어
            {
                vector.y = 0;
            }
            else if (vector.y != 0)  //x, y 축 동시 입력 제어
            {
                vector.x = 0;
            }

            /*animator.SetFloat("DirX", vector.x); //vector.x가 인수가 되어 객체의 Animator창에서 설정(x,y의 -1,1 등)값과 비교됨
            animator.SetFloat("DirY", vector.y);*/

            RaycastHit2D hit; //레이저를 쏴서 맞는것이 hit에 저장되는 클래스 객채 생성

            Vector2 start = transform.position; // A지점, 캐릭터의 현재 위치값
            Vector2 end = start + new Vector2(vector.x * speed * walkCount, vector.y * speed * walkCount); // B지점, 캐릭터가 이동하고자 하는 위치 값

            boxCollider.enabled = false; //Raycastd에 플래이어 객체의 콜라이더 값이 들어가는 것을 방지하기위해 콜라이더를 끔

            hit = Physics2D.Linecast(start, end, layerMask); //실제로 레이저를 쏘는 것이 실행되는 코드
            boxCollider.enabled = true;

            if (hit.transform != null) //hit = null 이면 뒤의 움직임 코드 진행
                break;

            /*animator.SetBool("Walking", true);*/

            while (currentWalkCount < walkCount)
            {
                transform.Translate(vector.x * (speed + applyRunSpeed), vector.y * (speed + applyRunSpeed), 0);
                if (applyRunFlag)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f); //타일단위 이동시 픽셀 이동을 보여주기위해 대기시간 부여
            }
            currentWalkCount = 0;

        }
        /*animator.SetBool("Walking", false);*/
        canMove = true;

    }



    // Update is called once per frame
    void Update()
    {

        if (canMove) //코루틴 반복, 다중 실행을 막기 위함
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
        }

    }
}