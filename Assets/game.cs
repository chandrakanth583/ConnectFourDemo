using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class game : MonoBehaviour
{
    public static game gameinstance;
    bool red_turn;
    public int searchDeapth = 4;
    public float waitTime = 0.5f;
    public GameObject red;
    public GameObject black;
    public bool twoplayer = true;
    public bool humanIsRed = true;
    public int[,] board;
    bool reciveInput;
    bool draw;
    int victory;
    public smartLable turn;
    public smartButton one;
    public smartButton two;
    public smartButton three;
    public smartButton four;
    public smartButton five;
    public smartButton six;
    public smartButton seven;
    public float dumbCompwaitTime = 1;
    public bool checkRed = false;
    public bool checkYellow = false;

    public Text turnText;
    public bool checkonce = true;
    public int counter=0 , counter2=0;
    public bool switchTurn= false;
    public int turncount;
    public bool sending = true;

    public GameObject isredturnText;
    public GameObject iswhiteturnText;
    public Text playerturn;
    bool playerturntext = false;


    public Animator turnTextAnim;

    // Use this for initialization

    private void Awake()
    {
        PlayerPrefs.SetInt("turncount", 0);
        if (gameinstance == null)                //...set this one to be it...
            gameinstance = this;
        else
       if (gameinstance != this)
            //  Destroy(gameObject);
            gameinstance = this;              // Allowing 2 players

    }
    void Start()
    {
    
        StartCoroutine(waitforRedTurnTextEnd("Red Player Shoot!"));

        draw = false;
        victory = 0;
        red_turn = true;
        board = new int[7, 6];

        reciveInput = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) )
        {
            SpwanObjects(0);
        }
        if (Input.GetKeyDown(KeyCode.S) )
        {
            SpwanObjects(1); //1
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpwanObjects(2); //2
        }
        if (Input.GetKeyDown(KeyCode.F))     
        {
            SpwanObjects(3);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            SpwanObjects(4);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpwanObjects(5);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            SpwanObjects(6);
        }


        if (draw)
        {
            turn.text = "draw";
            return;
        }
        if (victory == 0)
        {
            if (red_turn )
            {
             
            }
            else
            {
                if (checkYellow)
                {
                   
                }                    
            }
        }
        else if (victory == 1)
        {
            //turnText.text = "";
            turn.text = "Red wins!";
            reciveInput = false;
            PlayerPrefs.SetInt("turncount", turncount);
            // StartCoroutine("waitForFewSec");
            StartCoroutine(WiatForGameToEnd(4));
        }
        else
        {
            //turnText.text = "";
            turn.text = "Black wins!";
           PlayerPrefs.SetInt("turncount", turncount);
            reciveInput = false;
            StartCoroutine(WiatForGameToEnd(3));
         }

    }


	IEnumerator runComputorTurn(int value)
    {
		reciveInput=false;
       int row = getComputerMove();
        float elapsed=0;
		while(elapsed<dumbCompwaitTime)
        {
			elapsed+=Time.deltaTime;
			yield return 0;
		}
		dropChip(row);
		if(red_turn)
        {
			//Instantiate(red,new Vector3(row-3,3.6f,1),Quaternion.identity);
		}
		else
        {
			Instantiate(black,new Vector3(value-3,3.6f,1),Quaternion.identity);
		}
		StartCoroutine(wait());
	}
	IEnumerator wait()
    {
		float elapsed=0;
		reciveInput=false;
		while(elapsed<waitTime)
        {
			elapsed+=Time.deltaTime;
			yield return 0;
		}
		red_turn = !red_turn;
		reciveInput=true;

        if (twoplayer == false && red_turn != humanIsRed && victory == 0 && !draw)
        {
            // controls for player 2 
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine(runComputorTurn(0));
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine(runComputorTurn(1));
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine(runComputorTurn(2));
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(runComputorTurn(3));
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                StartCoroutine(runComputorTurn(4));
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                StartCoroutine(runComputorTurn(5));
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                StartCoroutine(runComputorTurn(6));
            }
        }
        yield break;
	}
	int getComputerMove()
    {
		return C4AI.getBestMove(red_turn,board,searchDeapth);
	}
	bool isDraw()
    {
		bool ret=true;
		for(int i =0;i<7;i++)
        {
			if(board[i,5]==0)
            {
				ret=false;
				break;
			}
		}
		return ret;
	}
	bool isRowOpen(int row)
    {
		if(board[row,5]!=0)
        {
			return false;
		}
		else
        {
			return true;
		}
	}
	bool checkWin(int x, int y)
    {
		if(board[x,y]==0)
        {
			return false;
		}
		else if(board[x,y]==-1)
        {
			if(lookForFour(x,y,1,-1,0,-1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,1,0,0,-1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,1,1,0,-1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,0,1,0,-1,false))
            {
				return true;
			}
			else
            {
				return false;
			}
		}
		else
        {
			if(lookForFour(x,y,1,-1,0,1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,1,0,0,1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,1,1,0,1,false))
            {
				return true;
			}
			else if(lookForFour(x,y,0,1,0,1,false))
            {
				return true;
			}
			else
            {
				return false;
			}
		}

	}
	bool lookForFour(int x, int y, int directionVert,int directionHor, int count, int lookFor, bool reversed)
    {
		if(x>6 || x<0 || y<0 || y>5 || board[x,y]!=lookFor)
        {
			return false;
		}
		count++;
		if(count==4)
        {
			return true;
		}
		bool next = lookForFour(x+directionHor,y+directionVert,directionVert,directionHor,count,lookFor,reversed);
		if(next==false && !reversed)
        {
			return lookForFour(x,y,-1*directionVert,-1*directionHor,0,lookFor,!reversed);
		}
		else if(next==false && reversed)
        {
			return false;
		}
		else
        {
			return true;
		}
	}
	void dropChip(int row)
    {
		if(red_turn)
        {
			for(int j=0;j<6;j++)
            {
				if(board[row,j]==0)
                {
					board[row,j]=1;
					Debug.Log("board val after red move: "+C4AI.evalboard(board));
                    if (checkWin(row, j))
                    {
                        victory = 1;
                    }
				draw=isDraw();
				return;
				}
			}
		}
		else
        {
			for(int j=0;j<6;j++)
            {
				if(board[row,j]==0)
                {
					board[row,j]=-1;
					Debug.Log("board val after black move: "+C4AI.evalboard(board));
					if(checkWin(row,j))
                    {
						victory=-1;
					}
					draw=isDraw();
					return;
				}
			}
		}
	}
   
    public void SpwanObjects(int index)
    {
        if (isRowOpen(index) && reciveInput && !draw)
        {
            dropChip(index);
            if (red_turn)
            {
                
                StartCoroutine(waitforRedTurnTextEnd("White Player Shoot!"));
                //player1
                Instantiate(red, new Vector3(index - 3, 3.6f, 1), Quaternion.identity); // spaawn in centre of the screen
                turncount = PlayerPrefs.GetInt("turncountZF");
                turncount = turncount + 1;
                PlayerPrefs.SetInt("turncount", turncount);
                PlayerPrefs.Save();
                Debug.Log(turncount);

            }
            else
            {

                StartCoroutine(waitforRedTurnTextEnd("Red Player Shoot!"));
                //player2
                turncount = PlayerPrefs.GetInt("turncountZF");
                turncount = turncount + 1;
                PlayerPrefs.SetInt("turncount", turncount);
                PlayerPrefs.Save();
                Debug.Log(turncount);
                Instantiate(black, new Vector3(index - 3, 3.6f, 1), Quaternion.identity); // spaawn in centre of the screen
            }
            StartCoroutine(wait());
        }
    }


    IEnumerator waitforRedTurnTextEnd(string shootString)
    {
        yield return new WaitForSeconds(0.5f);
        turnText.text = shootString;
        yield return new WaitForSeconds(1f);
        turnText.text = "";
    }

    IEnumerator WiatForGameToEnd(int ScNumber)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(ScNumber);
    }
}
