using UnityEngine;
using System.Collections;
using System.IO.Ports;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameSI : MonoBehaviour
{
	bool red_turn;
	public int searchDeapth=4;
	public float waitTime=1;
	public GameObject red;
	public GameObject black;
	public bool twoplayer=true;
	public bool humanIsRed=true;
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
    public static SerialPort sp = new SerialPort("COM4", 9600);
    public static game gameinstance;
    
    public float dumbCompwaitTime = 1;
    public bool checkRed = false;
    public bool checkYellow = false;

    public Text turnText;
    public int counter = 0, counter2 = 0;
    public bool switchTurn = true;
    public int turncount;
    public bool sending = true;


   
	// Use this for initialization
	void Start ()
    {
        PlayerPrefs.SetInt("turncount", 0);
        draw =false;
		victory=0;
		red_turn=true;
		board=new int[7,6];
		reciveInput=true;
		one.callBack+= delegate {buttonFunc(0);};
		two.callBack += delegate {buttonFunc(1);};
		three.callBack += delegate {buttonFunc(2);};
		four.callBack += delegate {buttonFunc(3);};
		five.callBack += delegate {buttonFunc(4);};
		six.callBack += delegate {buttonFunc(5);};
		seven.callBack += delegate {buttonFunc(6);};
		if(humanIsRed==false)
        {
			StartCoroutine(runComputorTurn());
		}
	}
	void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            SpwanObjects(0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpwanObjects(1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SpwanObjects(2);
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
			turn.text="draw";
			return;
		}
		if(victory==0){
			if(red_turn){
				//turn.text="red's turn";
			}
			else{
				//turn.text="black's turn";
			}
		}
		else if(victory==1){
		//	turn.text="Red wins!";
            Debug.Log("RED WON");
			reciveInput=false;
            StartCoroutine(WaitForGameToEnd(4));
            PlayerPrefs.SetInt("Scene", 3);
           
		}
		else{
		//turn.text="Black wins!";
            Debug.Log("BLACK WON");
            reciveInput =false;
            StartCoroutine(WaitForGameToEnd(6));
            PlayerPrefs.SetInt("Scene", 4);
        }

	}
	void buttonFunc(int row){
		if(isRowOpen(row)&& reciveInput && !draw)
        {
			dropChip(row);
			if(red_turn){
				Instantiate(red,new Vector3(row-3,3.6f,1),Quaternion.identity);
			}
			else{
				Instantiate(black,new Vector3(row-3,3.6f,1),Quaternion.identity);
			}
			StartCoroutine(wait());
		}
	}
	IEnumerator runComputorTurn()
    {
		reciveInput=false;
		int row = getComputerMove();
		float elapsed=0;
		while(elapsed<dumbCompwaitTime){
			elapsed+=Time.deltaTime;
			yield return 0;
		}
		dropChip(row);
		if(red_turn){
			Instantiate(red,new Vector3(row-3,3.6f,1),Quaternion.identity);
		}
		else{
			Instantiate(black,new Vector3(row-3,3.6f,1),Quaternion.identity);
		}
		StartCoroutine(wait());
	}
	IEnumerator wait(){
		float elapsed=0;
		reciveInput=false;
		while(elapsed<waitTime){
			elapsed+=Time.deltaTime;
			yield return 0;
		}
		red_turn = !red_turn;
		reciveInput=true;
		if(twoplayer==false && red_turn!=humanIsRed && victory==0 && !draw){
			StartCoroutine(runComputorTurn());
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
		for(int i =0;i<7;i++){
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
		else{
			return true;
		}
	}
	bool checkWin(int x, int y)
    {
		if(board[x,y]==0){
			return false;
	}
	else if(board[x,y]==-1)

            {
            if (lookForFour(x,y,1,-1,0,-1,false))
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
				//Debug.Log("time 2: "+Time.realtimeSinceStartup);
				return false;
			}
		}
		else{
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
			else{
				//Debug.Log("time 2: "+Time.realtimeSinceStartup);
				return false;
               
			}
		}

	}
	bool lookForFour(int x, int y, int directionVert,int directionHor, int count, int lookFor, bool reversed){
		if(x>6 || x<0 || y<0 || y>5 || board[x,y]!=lookFor)
        {
			return false;
		}
		count++;
		if(count==4){
			return true;
		}
		bool next = lookForFour(x+directionHor,y+directionVert,directionVert,directionHor,count,lookFor,reversed);
		if(next==false && !reversed){
			return lookForFour(x,y,-1*directionVert,-1*directionHor,0,lookFor,!reversed);
		}
		else if(next==false && reversed){
			return false;
		}
		else{
			return true;
		}
	}
	void dropChip(int row){
		if(red_turn){
			for(int j=0;j<6;j++){
				if(board[row,j]==0)
                {
					board[row,j]=1;
					Debug.Log("board val after red move: "+C4AI.evalboard(board));
					if(checkWin(row,j))
                    {
						victory=1;
                        red_turn = false;
					}
					draw=isDraw();
					return;
				}
			}
		}
		else{
			for(int j=0;j<6;j++)
            {
				if(board[row,j]==0)
                {
					board[row,j]=-1;
					Debug.Log("board val after black move: "+C4AI.evalboard(board));
					if(checkWin(row,j))
                    {
						victory=-1;
                        red_turn = false;
                        
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
                //player1
                Instantiate(red, new Vector3(index - 3, 3.6f, 1), Quaternion.identity); // spaawn in centre of the screen
            }
            else
            {
                //player2
                Instantiate(black, new Vector3(index - 3, 3.6f, 1), Quaternion.identity); // spaawn in centre of the screen
            }
            StartCoroutine(wait());
        }

    }

    public IEnumerator WaitForGameToEnd(int sceneIndex)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneIndex);

    }
}










