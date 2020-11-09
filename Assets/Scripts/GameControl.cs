using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
	GameObject BackCard;
	List<int> faceIndexes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 0, 1, 2, 3, 4, 5, 6, 7 };
	public static System.Random rnd = new System.Random();
	public int shuffleNum = 0;
	int[] visibleFaces = { -1, -2 };
	private void Start()
	{
		int OriginalLength = faceIndexes.Count;
		float yPosition = 2.9f;
		float xPosition = -4.2f;
		for (int i = 0; i < 15; i++)
		{
			shuffleNum = rnd.Next(0, (faceIndexes.Count));
			var temp = Instantiate(BackCard, new Vector3(
				xPosition, yPosition, 0),
				Quaternion.identity);
			temp.GetComponent<MainCard>().faceIndex = faceIndexes[shuffleNum];
			faceIndexes.Remove(faceIndexes[shuffleNum]);
			xPosition = xPosition + 2;
			if (i == (OriginalLength / 2 - 2))
			{
				yPosition = -1.9f;
				xPosition = -6.2f;
			}
		}

		BackCard.GetComponent<MainCard>().faceIndex = faceIndexes[0];
	}

	public bool TwoCardsUp()
	{
		bool cardsUo = false;
		if (visibleFaces[0] >= 0 && visibleFaces[1] >= 0)
		{
			cardsUo = true;
		}
		return cardsUo;

	}

	public void AddVisibleFace(int index)
	{
		if(visibleFaces[0] == -1)
		{
			visibleFaces[0] = index;
		}
		else if (visibleFaces[1] == -2)
		{
			visibleFaces[1] = index;
		}
	}

	public void RemoveVisibleFace(int index)
	{
		if (visibleFaces[0] == index)
		{
			visibleFaces[0] = -1;
		}
		else if (visibleFaces[1] == index)
		{
			visibleFaces[1] = -2;
		}
	}

	public bool CheckMatch()
	{
		bool success = false;
		if (visibleFaces[0] == visibleFaces[1])
		{
			visibleFaces[0] = -1;
			visibleFaces[1] = -2;
			success = true; 

		}
		return success;
	}
	private void Awake()
	{
		BackCard = GameObject.Find("BackCard");
	}
}
