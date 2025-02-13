using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using UnityEngine.UI;
using UniRx;

public class CharacterMove : MonoBehaviour
{ 
    #region Move Character
    public Image animator;
    Vector3 moveVelocity = Vector3.zero;
    private Vector3 movedPoint;
    private Vector3 initPos;
    private float moveSpeed = 10.0f;
    #endregion

    public Button RightBtn;
    public Button LeftBtn;
    bool IsBtnDown = false;
    int nDirection = -1;
    int nUpDirection = -1;


    #region CharMove
    int sec;
    int Downsec;
    int secInverse;
    bool move;
    Sprite RabbitMove;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        BindView();
        nDirection = -1;
        nUpDirection = -1;
        IsBtnDown = false;
        Downsec = 0;
        sec = 0;
        secInverse = 0;
    }
    public void PointerDownDown()
    {
        nUpDirection = (int)ZoneType.DOWN;
        IsBtnDown = true;
    }

    public void PointerUpDown()
    {
        nUpDirection = (int)ZoneType.UP;
        IsBtnDown = true;
    }

    public void PointerLeftDown()
    {
        nDirection = (int)ZoneType.LEFT;
        IsBtnDown = true;
        
    }
    public void PointerRightDown()
    {
        
        nDirection = (int)ZoneType.RIGHT;
        IsBtnDown = true;
    }

    void MoveInverse()
    {
        if(nDirection== (int)ZoneType.RIGHT)
        {
            secInverse++;
            if (secInverse == 1)
            {
                if (move == false)
                    RabbitMove = Resources.Load("LeftInverse", typeof(Sprite)) as Sprite;
                else
                    RabbitMove = Resources.Load("RightInverse", typeof(Sprite)) as Sprite;
                move = !move;
            }
            else if (secInverse == 5)
            {
                RabbitMove = Resources.Load("NormInverse", typeof(Sprite)) as Sprite;
                secInverse = 0;
            }
        }
        else if(nDirection == (int)ZoneType.LEFT)
        {
            sec++;
            if (sec == 1)
            {
                if (move == false)
                    RabbitMove = Resources.Load("Left", typeof(Sprite)) as Sprite;
                else
                    RabbitMove = Resources.Load("Right", typeof(Sprite)) as Sprite;
                move = !move;
            }
            else if (sec == 5)
            {
                RabbitMove = Resources.Load("Norm", typeof(Sprite)) as Sprite;
                sec = 0;
            }
        }
        if(nUpDirection==(int)ZoneType.DOWN)
        {
            Downsec++;
            if (Downsec == 1)
            {
                if (move == false)
                    RabbitMove = Resources.Load("Rabbit", typeof(Sprite)) as Sprite;
                else
                    RabbitMove = Resources.Load("Rabbit", typeof(Sprite)) as Sprite;
                move = !move;
            }
            else if (Downsec == 5)
            {
                RabbitMove = Resources.Load("Rabbit", typeof(Sprite)) as Sprite;
                Downsec = 0;
            }
        }
        animator.GetComponent<Image>().sprite = RabbitMove;
    }

    public void PointerUp()
    {
        nDirection = -1;
        nUpDirection = -1;
        IsBtnDown = false;
        nDirection = -1;
    }

    void BindView()
    {
        LeftBtn.OnClickAsObservable()
            .Subscribe(_ =>
            {
                nDirection = (int)ZoneType.LEFT;
                nUpDirection = -1;
                animator.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            })
                .AddTo(gameObject);

        RightBtn.OnClickAsObservable()
            .Subscribe(_ =>
            {
                nDirection = (int)ZoneType.RIGHT;
                nUpDirection = -1;
                animator.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            })
                .AddTo(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.transform.position.y >= -1.0f)
        {
            animator.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
        if (animator.transform.position.y < -4.0f)
            animator.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        if (Mathf.Abs(animator.transform.position.x) >= 9)
        {
            if(animator.transform.position.x<=0)
                animator.transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            else
                animator.transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (IsBtnDown && animator.transform.position.y<=0.0f && Mathf.Abs(animator.transform.position.x)<=9)
        {
            if(nDirection==(int)ZoneType.LEFT)
                animator.transform.position += Vector3.left * moveSpeed * Time.deltaTime;

            else if(nDirection == (int)ZoneType.RIGHT)
                animator.transform.position += Vector3.right * moveSpeed * Time.deltaTime;

            if(nUpDirection == (int)ZoneType.UP)
            {
                Debug.Log(animator.transform.position);
                animator.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            else if (nUpDirection == (int)ZoneType.DOWN)
            {
                Debug.Log(animator.transform.position);
                animator.transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            }
            MoveInverse();
        }
            
    }
}
